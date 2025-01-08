using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Craglex.SimpleUI
{
    public class SimpleUIHandler : MonoBehaviour
    {
        private HashSet<UIElement> activeElements = new();
        internal UIElement lastTarget = null;
        [Header("Player input related config")]
        [SerializeField] PlayerInput playerInput;
        [SerializeField] string uiMap;
        [SerializeField] string gameMap;

        public void Awake(){
            if (playerInput == null)
                Debug.LogError($"[{gameObject.name}] PlayerInput is not assigned!");

            if (string.IsNullOrWhiteSpace(uiMap))
                Debug.LogError($"[{gameObject.name}] uiActionMapName is empty or not set!");

            if (string.IsNullOrWhiteSpace(gameMap))
                Debug.LogError($"[{gameObject.name}] gameActionMapName is empty or not set!");
        }


        public static GameObject CreateElement(GameObject Prefab){
            GameObject newObj = Instantiate(Prefab);
            bool isUIElement = newObj.TryGetComponent(typeof(UIElement),out _);
            if(isUIElement == false){
                newObj.AddComponent<RectTransform>();
                newObj.AddComponent<UIElement>();
            }

            return newObj;
        }

        public static GameObject CreateElement(){
            GameObject newElement = new();
            newElement.AddComponent<RectTransform>();
            newElement.AddComponent<UIElement>();
            return newElement;
        }



        /// <summary>
        /// Opens a UIElement object, marks target as active and recursively opens any dependency UIElement's. 
        /// Both the target and dependencies are marked as open. if the target has an IUiInitializer, 
        /// it also initializes. Lastly enables UI controls.
        /// </summary>
        /// <param name="target"></param>
        public void OpenUI(UIElement target){
            if(target.grabAttention)
                lastTarget = target;
            
            activeElements.Add(target.Open());
            HashSet<UIElement> dependencies = new();
            target.GetDependencies(ref dependencies);

            foreach (var element in dependencies)
                activeElements.Add(element.Open());
        }

        /// <summary>
        /// Closes the target UIElement and its dependencies if they are marked as open.
        /// </summary>
        /// <param name="target"></param>
        public void CloseUI(UIElement target){
            HashSet<UIElement> dependencies = new();
            target.GetDependencies(ref dependencies);
            foreach (var element in dependencies)
                activeElements.Remove(element.Close());
            
            target.Close();
            if(target.returnElement != null)
                OpenUI(target.returnElement);
        }

        /// <summary>
        /// Sets a certain UIElement as the active target.
        /// </summary>
        /// <param name="target"></param>
        public void SetActive(UIElement target){
            if(target.isOpen)
                return;
            
            lastTarget = target;
        }

        /// <summary>
        /// Closes active UIElement then uses OpenUI() to open the last element of
        /// target. Marks are also applied.
        /// </summary>
        public void ReturnToLastMenu(){
            if(lastTarget.returnElement == null){
                ReturnToGame();
                return;
            }
            
            OpenUI(lastTarget.returnElement);
        }

        /// <summary>
        /// Resets the UI.
        /// </summary>
        public void ResetUI(){
            foreach (var element in activeElements){
                element.Close();
            }

            activeElements.Clear();
            lastTarget = null;
        }

        /// <summary>
        /// Resets the UI and disables UI controls.
        /// </summary>
        public void ReturnToGame(){
            ResetUI();
            //playerInput.SetMap(gameMap);
        }
    }
}

