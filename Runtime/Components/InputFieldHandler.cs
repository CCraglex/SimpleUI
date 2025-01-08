    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.Events;

namespace Craglex.SimpleUI
{
    public class InputFieldHandler : UIComponent<InputField>
    {
        public InputFieldHandler(Transform transform) : base(transform) { }

        /// <summary>
        /// Sets the input field text.
        /// </summary>
        public void SetText(string text)
        {
            Element.text = text;
        }

        /// <summary>
        /// Gets the input field text.
        /// </summary>
        public string GetText()
        {
            return Element.text;
        }

        /// <summary>
        /// Adds a listener for when the text changes.
        /// </summary>
        public void AddValueChangedListener(UnityAction<string> callback)
        {
            Element.onValueChanged.AddListener(callback);
        }

        /// <summary>
        /// Adds a listener for when editing ends.
        /// </summary>
        public void AddEndEditListener(UnityAction<string> callback)
        {
            Element.onEndEdit.AddListener(callback);
        }

        /// <summary>
        /// Removes a listener for text changes.
        /// </summary>
        public void RemoveValueChangedListener(UnityAction<string> callback)
        {
            Element.onValueChanged.RemoveListener(callback);
        }

        /// <summary>
        /// Removes a listener for when editing ends.
        /// </summary>
        public void RemoveEndEditListener(UnityAction<string> callback)
        {
            Element.onEndEdit.RemoveListener(callback);
        }
    }

}