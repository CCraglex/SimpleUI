using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Craglex.SimpleUI{
    public interface IImageHandler : IUiComponentHandler<Image>
    {
        /// <summary>
        /// Set color of image
        /// </summary>
        /// <param name="cVal"></param>
        public void SetColor(Color cVal)
        {
            Value.color = cVal;
        }

        /// <summary>
        /// Set alpha of image
        /// </summary>
        /// <param name="fVal"></param>
        public void SetAlpha(float fVal)
        {
            var C = Value.color;
            C.a = fVal;
            Value.color = C;
        }

        /// <summary>
        /// Set sprite of image
        /// </summary>
        /// <param name="sprite"></param>
        public void SetSprite(Sprite sprite)
        {
            Value.sprite = sprite;
        }

        /// <summary>
        /// Set material of image
        /// </summary>
        /// <param name="material"></param>
        public void SetMaterial(Material material)
        {
            Value.material = material;
        }

        /// <summary>
        /// Set fill aomunt of image
        /// </summary>
        /// <param name="fillAmount"></param>
        public void SetFillAmount(float fillAmount)
        {
            Value.fillAmount = Mathf.Clamp01(fillAmount);
        }

        /// <summary>
        /// Set raycast target of image
        /// </summary>
        /// <param name="value"></param>
        public void SetRaycastTarget(bool value)
        {
            Value.raycastTarget = value;
        }

        /// <summary>
        /// Sets image to native size
        /// </summary>
        public void SetNativeSize()
        {
            Value.SetNativeSize();
        }

        /// <summary>
        /// Sets preseve aspect of image to value
        /// </summary>
        /// <param name="value"></param>
        public void SetPreserveAspect(bool value)
        {
            Value.preserveAspect = value;
        }

        /// <summary>
        /// Fades the image alpha to targetAlpha in duration
        /// </summary>
        /// <param name="targetAlpha"></param>
        /// <param name="duration"></param>
        public void FadeImage(float targetAlpha, float duration)
        {
            Value.DOFade(targetAlpha,duration);
        }

        /// <summary>
        /// Mulitplies image color with tint
        /// </summary>
        /// <param name="tint"></param>
        public void SetColorTint(Color tint)
        {
            var currentColor = Value.color;
            Value.color = currentColor * tint;
        }

        /// <summary>
        /// Flips image
        /// </summary>
        /// <param name="horizontal"></param>
        /// <param name="vertical"></param>
        public void FlipImage(bool horizontal, bool vertical)
        {
            var scale = Value.rectTransform.localScale;
            if (horizontal) scale.x = -scale.x;
            if (vertical) scale.y = -scale.y;
            Value.rectTransform.localScale = scale;
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