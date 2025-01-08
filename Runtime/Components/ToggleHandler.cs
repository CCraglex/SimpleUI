using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Craglex.SimpleUI
{
    public class ToggleHandler : UIComponent<Toggle>
    {
        public ToggleHandler(Transform transform) : base(transform) { }

        /// <summary>
        /// Sets whether the toggle is on.
        /// </summary>
        public void SetIsOn(bool isOn)
        {
            Element.isOn = isOn;
        }

        /// <summary>
        /// Gets whether the toggle is on.
        /// </summary>
        public bool IsOn()
        {
            return Element.isOn;
        }

        /// <summary>
        /// Adds a listener for value changes.
        /// </summary>
        public void AddValueChangedListener(UnityAction<bool> callback)
        {
            Element.onValueChanged.AddListener(callback);
        }

        /// <summary>
        /// Removes a listener for value changes.
        /// </summary>
        public void RemoveValueChangedListener(UnityAction<bool> callback)
        {
            Element.onValueChanged.RemoveListener(callback);
        }
    }

}