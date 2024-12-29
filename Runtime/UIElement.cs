using System.Collections.Generic;
using UnityEngine;

namespace Craglex.SimpleUI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class UIElement : MonoBehaviour
    {
        public CanvasGroup canvas;
        public UIElement returnElement;
        public List<UIElement> nonAllowedElements = new();
        public List<UIElement> dependencyElements = new();

        private void Awake(){
            if (canvas != null) return;
            
            Debug.LogWarning("No CanvasGroup set. Getting the one in the same object.",gameObject);
            canvas = GetComponent<CanvasGroup>();
        }

        /// <summary>
        /// Opens UIElement, and makes it interactable.
        /// </summary>
        /// <returns></returns>
        public UIElement Open(){
            if(canvas.interactable){
                Debug.LogWarning("UIElement is already open.",gameObject);
                return null;
            }

            
            canvas.alpha = 1;
            canvas.blocksRaycasts = true;
            canvas.interactable = true;
            
            return this;
        }
        /// <summary>
        /// Opens all the dependencies via Open() if it is not marked in a recursive way.
        /// </summary>
        /// <param name="visitedElements">previousliy visited elements.</param>
        /// <returns></returns>
        public List<UIElement> OpenDependencies(List<UIElement> visitedElements){
            List<UIElement> retVal = new();

            if(dependencyElements == null)
                return retVal;

            foreach (var element in dependencyElements)
            {
                if(visitedElements.Contains(element))
                    continue;

                visitedElements.Add(element);
                var addedElement = element.Open();
                List<UIElement> extraDependencies = null;
                if(addedElement != null){
                    retVal.Add(addedElement);
                    extraDependencies = addedElement.OpenDependencies(visitedElements);
                }

                if(extraDependencies != null)
                    retVal.AddRange(extraDependencies);
            }

            return retVal;
        }

        /// <summary>
        /// Closes UIElement.
        /// </summary>
        /// <param name="isRecursive">Should the function run recursively or not?</param>
        public virtual void Close(bool isRecursive){
            canvas.alpha = 0;
            canvas.blocksRaycasts = false;
            canvas.interactable = false;

            if(dependencyElements.Count == 0 || !isRecursive)
                return;
            
            foreach (UIElement element in dependencyElements)
                element.Close(false);
        }
    }
}