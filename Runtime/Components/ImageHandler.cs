using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Craglex.SimpleUI{
    public class ImageHandler : UIComponent<Image>
    {
        public ImageHandler(Transform transform) : base(transform) { }

        /// <summary>
        /// Set color of image
        /// </summary>
        /// <param name="cVal"></param>
        public void SetColor(Color cVal)
        {
            Element.color = cVal;
        }

        /// <summary>
        /// Set alpha of image
        /// </summary>
        /// <param name="fVal"></param>
        public void SetAlpha(float fVal)
        {
            var C = Element.color;
            C.a = fVal;
            Element.color = C;
        }

        /// <summary>
        /// Set sprite of image
        /// </summary>
        /// <param name="sprite"></param>
        public void SetSprite(Sprite sprite)
        {
            Element.sprite = sprite;
        }

        /// <summary>
        /// Set material of image
        /// </summary>
        /// <param name="material"></param>
        public void SetMaterial(Material material)
        {
            Element.material = material;
        }

        /// <summary>
        /// Set fill aomunt of image
        /// </summary>
        /// <param name="fillAmount"></param>
        public void SetFillAmount(float fillAmount)
        {
            Element.fillAmount = Mathf.Clamp01(fillAmount);
        }

        /// <summary>
        /// Set raycast target of image
        /// </summary>
        /// <param name="value"></param>
        public void SetRaycastTarget(bool value)
        {
            Element.raycastTarget = value;
        }

        /// <summary>
        /// Sets image to native size
        /// </summary>
        public void SetNativeSize()
        {
            Element.SetNativeSize();
        }

        /// <summary>
        /// Sets preseve aspect of image to value
        /// </summary>
        /// <param name="value"></param>
        public void SetPreserveAspect(bool value)
        {
            Element.preserveAspect = value;
        }

        /// <summary>
        /// Mulitplies image color with tint
        /// </summary>
        /// <param name="tint"></param>
        public void SetColorTint(Color tint)
        {
            var currentColor = Element.color;
            Element.color = currentColor * tint;
        }

        /// <summary>
        /// Flips image
        /// </summary>
        /// <param name="horizontal"></param>
        /// <param name="vertical"></param>
        public void FlipImage(bool horizontal, bool vertical)
        {
            var scale = Element.rectTransform.localScale;
            if (horizontal) scale.x = -scale.x;
            if (vertical) scale.y = -scale.y;
            Element.rectTransform.localScale = scale;
        }

        /// <summary>
        /// Defaults the image color, scale and sprite.
        /// </summary>
        public void ResetImage()
        {
            SetColor(Color.white); // Reset to default color
            SetAlpha(1f); // Reset to fully opaque
            SetSprite(null); // Reset sprite
        }
    }
}