
using UnityEngine.InputSystem;

namespace Craglex.SimpleUI
{
    public abstract class UIActionHandler{
        protected SimpleUIHandler SimpleUI;
        public abstract void HandleAction(InputAction.CallbackContext ctx, UIElement target);

        public UIActionHandler(SimpleUIHandler simpleUI){
            SimpleUI = simpleUI;
        }
    }
}