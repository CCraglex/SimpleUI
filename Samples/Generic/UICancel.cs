using UnityEngine.InputSystem;

namespace Craglex.SimpleUI.Actions
{
    public class UICancel : UIActionHandler {
        public UICancel(GameUI gameUI) : base(gameUI){ GameUI = gameUI; }

        public override void HandleAction(InputAction.CallbackContext ctx,UIElement target){
            if(ctx.phase != InputActionPhase.Started)
                return;
            
            if(GameUI.lastTarget != null)
                GameUI.ReturnToLastMenu();

            else GameUI.ReturnToGame();
        }
    }
}