using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Craglex.SimpleUI
{
    public class ButtonHandler : UIComponent<Button>
    {
        public ButtonHandler(Transform transform) : base(transform) { }

        /// <summary>
        /// Adds a click listener to the button.
        /// </summary>
        public void AddClickListener(UnityAction callback)
        {
            Element.onClick.AddListener(callback);
        }

        /// <summary>
        /// Removes a click listener from the button.
        /// </summary>
        public void RemoveClickListener(UnityAction callback)
        {
            Element.onClick.RemoveListener(callback);
        }

        /// <summary>
        /// Sets whether the button is interactable.
        /// </summary>
        public void SetInteractable(bool interactable)
        {
            Element.interactable = interactable;
        }
    }
}