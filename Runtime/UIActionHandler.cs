
using UnityEngine.InputSystem;

namespace Craglex.SimpleUI
{
    public abstract class UIActionHandler{
        protected GameUI GameUI;
        public abstract void HandleAction(InputAction.CallbackContext ctx, UIElement target);

        public UIActionHandler(GameUI gameUI){
            GameUI = gameUI;
        }
    }
}