using System;
using System.Collections.Generic;
using Behaviours.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Craglex.SimpleUI
{
    public class GameUI : MonoBehaviour
    {
        private List<UIElement> activeElements;
        private UIElement lastTarget = null;
        [Header("Player input related config")]
        [SerializeField] PlayerInput playerInput;
        [SerializeField] string uiActionMapName;
        [SerializeField] string gameActionMapName;

        /// <summary>
        /// Opens a UIElement object, marks target as active and recursively opens any dependency UIElement's. 
        /// Both the target and dependencies are marked as open. if the target has an IUiInitializer, 
        /// it also initializes. Lastly enables UI controls.
        /// </summary>
        /// <param name="target">The target UIElement to open.</param>
        public void OpenUI(UIElement target){

            void CloseUnallowed(){
                foreach (var element in target.nonAllowedElements){
                    if(!activeElements.Contains(element))
                        continue;

                    element.Close(true);
                    activeElements.Remove(element);
                }
            }

            List<UIElement> visitedElements = new();
            lastTarget = target;
            
            if(!activeElements.Contains(target))
                activeElements.Add(target.Open());

            activeElements.AddRange(target.OpenDependencies(visitedElements));
            if(target.nonAllowedElements != null)
                CloseUnallowed();

            target.TryGetComponent(out IUiInitializer Initializer);
            Initializer?.Init();

            playerInput.SwitchCurrentActionMap(uiActionMapName);
        }

        /// <summary>
        /// Closes the target UIElement and its dependencies if they are marked as open.
        /// </summary>
        /// <param name="target"></param>
        public void CloseUI(UIElement target){
            if(!activeElements.Contains(target))
                return;
            target.Close(true);
            activeElements.Remove(target);
        }

        /// <summary>
        /// Closes active UIElement then uses OpenUI() to open the last element of
        /// target. Marks are also applied.
        /// </summary>
        private void ReturnToLastMenu(){
            if(lastTarget.returnElement == null){
                ReturnToGame();
                return;
            }
            
            OpenUI(lastTarget.returnElement);
        }

        /// <summary>
        /// Resets the UI.
        /// </summary>
        private void ResetUI(){
            foreach (var element in activeElements){
                element.Close(true);
            }

            activeElements.Clear();
            lastTarget = null;
        }

        /// <summary>
        /// Resets the UI and disables UI controls.
        /// </summary>
        private void ReturnToGame(){
            ResetUI();
            playerInput.SwitchCurrentActionMap(gameActionMapName);
        }

        public void Start(){
            if (playerInput == null)
                Debug.LogError($"[{gameObject.name}] PlayerInput is not assigned!");

            if (string.IsNullOrWhiteSpace(uiActionMapName))
                Debug.LogError($"[{gameObject.name}] uiActionMapName is empty or not set!");

            if (string.IsNullOrWhiteSpace(gameActionMapName))
                Debug.LogError($"[{gameObject.name}] gameActionMapName is empty or not set!");
        }
    }
}

