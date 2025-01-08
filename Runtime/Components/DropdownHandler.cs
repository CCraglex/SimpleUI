using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Craglex.SimpleUI
{
    public class DropdownHandler : UIComponent<Dropdown>
    {
        public DropdownHandler(Transform transform) : base(transform) { }

        /// <summary>
        /// Adds an option to the dropdown.
        /// </summary>
        public void AddOption(string option)
        {
            Element.options.Add(new Dropdown.OptionData(option));
        }

        /// <summary>
        /// Removes an option by name.
        /// </summary>
        public void RemoveOption(string option)
        {
            Element.options.RemoveAll(opt => opt.text == option);
        }

        /// <summary>
        /// Clears all options from the dropdown.
        /// </summary>
        public void ClearOptions()
        {
            Element.options.Clear();
        }

        /// <summary>
        /// Gets the currently selected option index.
        /// </summary>
        public int GetSelectedIndex()
        {
            return Element.value;
        }

        /// <summary>
        /// Gets the currently selected option text.
        /// </summary>
        public string GetSelectedOption()
        {
            return Element.options[Element.value].text;
        }

        /// <summary>
        /// Adds a listener for selection changes.
        /// </summary>
        public void AddValueChangedListener(UnityAction<int> callback)
        {
            Element.onValueChanged.AddListener(callback);
        }

        /// <summary>
        /// Removes a listener for selection changes.
        /// </summary>
        public void RemoveValueChangedListener(UnityAction<int> callback)
        {
            Element.onValueChanged.RemoveListener(callback);
        }
    }

}