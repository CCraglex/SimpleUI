using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Craglex.SimpleUI
{
    public class SliderHandler : UIComponent<Slider>
    {
        public SliderHandler(Transform transform) : base(transform) { }

        /// <summary>
        /// Sets the slider value.
        /// </summary>
        public void SetValue(float value)
        {
            Element.value = value;
        }

        /// <summary>
        /// Gets the slider value.
        /// </summary>
        public float GetValue()
        {
            return Element.value;
        }

        /// <summary>
        /// Sets the slider's minimum and maximum values.
        /// </summary>
        public void SetMinMax(float min, float max)
        {
            Element.minValue = min;
            Element.maxValue = max;
        }

        /// <summary>
        /// Adds a listener for value changes.
        /// </summary>
        public void AddValueChangedListener(UnityAction<float> callback)
        {
            Element.onValueChanged.AddListener(callback);
        }

        /// <summary>
        /// Removes a listener for value changes.
        /// </summary>
        public void RemoveValueChangedListener(UnityAction<float> callback)
        {
            Element.onValueChanged.RemoveListener(callback);
        }
    }

}