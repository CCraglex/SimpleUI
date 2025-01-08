using UnityEngine.InputSystem;

namespace Craglex.SimpleUI.Actions
{
    public class UICancel : UIActionHandler {
        public UICancel(SimpleUIHandler simpleUI) : base(simpleUI){ SimpleUI = simpleUI; }

        public override void HandleAction(InputAction.CallbackContext ctx,UIElement target){
            if(ctx.phase != InputActionPhase.Started)
                return;
            
            if(SimpleUI.lastTarget != null)
                SimpleUI.ReturnToLastMenu();

            else SimpleUI.ReturnToGame();
        }
    }
}