using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Craglex.SimpleUI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class UIElement : MonoBehaviour
    {
        [SerializeField] List<UIElement> dependencyElements;
        private CanvasGroup canvas;
        public bool isOpen;
        public bool grabAttention;
        public UIElement returnElement;

        public virtual void Awake(){
            canvas = GetComponent<CanvasGroup>();
        }
        public virtual UIElement Open(){
            canvas.alpha = 1;
            canvas.blocksRaycasts = true;
            canvas.interactable = true;
            isOpen = true;
            return this;
        }
        public virtual UIElement Close(){
            if(isOpen == false)
                return null;
            
            canvas.alpha = 0;
            canvas.blocksRaycasts = false;
            canvas.interactable = false;
            isOpen = false;
            return this;
        }        
        public UIElement Restart(){
            return Open();
        }
        public void AddElement<T>() where T : Graphic{
            UIComponent<T> newElement = new(transform);
        }
        public void GetDependencies(ref HashSet<UIElement> visitedElements){
            HashSet<UIElement> retVal = new();

            if(dependencyElements == null)
                return;

            foreach (var element in dependencyElements)
            {
                if(visitedElements.Contains(element))
                    continue;
                visitedElements.Add(element);
                element.GetDependencies(ref visitedElements);
            }
        }
    }
}