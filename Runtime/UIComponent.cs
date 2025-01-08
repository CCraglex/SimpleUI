using UnityEngine;
using UnityEngine.UI;

namespace Craglex.SimpleUI
{
    public class UIComponent<T> where T : Graphic{

        protected Transform Transform;
        protected CanvasGroup CanvasGroup;
        protected T Element;

        public UIComponent(Transform transform){
            Transform = transform;
            Element   = transform.GetComponent<T>();
            CanvasGroup = transform.GetComponent<CanvasGroup>();
        }
    }
}