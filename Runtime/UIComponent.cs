using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Craglex.SimpleUI
{
    public class UIComponent<T> where T : Component{
        protected Transform Transform;
        protected CanvasGroup CanvasGroup;
        public T Element;

        public UIComponent(Transform transform){
            Transform = transform;
            Element   = transform.GetComponent<T>();
            if(transform.TryGetComponent(out Element) == false)
                Element = Transform.gameObject.AddComponent<T>();
        }
    }
}