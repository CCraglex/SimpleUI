using TMPro;
using UnityEngine;

namespace Craglex.SimpleUI
{
    public class TMProHandler : UIComponent<TextMeshProUGUI>
    {
        public TMProHandler(Transform transform) : base(transform) { }

        /// <summary>
        /// Sets the text content.
        /// </summary>
        public void SetText(string content)
        {
            if (Element != null)
                Element.text = content;
        }

        /// <summary>
        /// Gets the current text content.
        /// </summary>
        public string GetText()
        {
            return Element != null ? Element.text : string.Empty;
        }

        /// <summary>
        /// Sets the font size.
        /// </summary>
        public void SetFontSize(float size)
        {
            if (Element != null)
                Element.fontSize = size;
        }

        /// <summary>
        /// Sets the font color.
        /// </summary>
        public void SetColor(Color color)
        {
            if (Element != null)
                Element.color = color;
        }

        /// <summary>
        /// Toggles the visibility of the text.
        /// </summary>
        public void SetVisibility(bool isVisible)
        {
            if (CanvasGroup != null){
                CanvasGroup.alpha = isVisible ? 1 : 0;
                CanvasGroup.blocksRaycasts = isVisible;
            }
        }

        /// <summary>
        /// Enables or disables raycast targeting.
        /// </summary>
        public void EnableRaycast(bool isEnabled)
        {
            if (Element != null)
                Element.raycastTarget = isEnabled;
        }

        /// <summary>
        /// Sets the text alignment.
        /// </summary>
        public void SetAlignment(TextAlignmentOptions alignment)
        {
            if (Element != null)
                Element.alignment = alignment;
        }

        /// <summary>
        /// Sets the text to bold, italic, or other styles.
        /// </summary>
        public void SetFontStyle(FontStyles style)
        {
            if (Element != null)
                Element.fontStyle = style;
        }
    }
}
