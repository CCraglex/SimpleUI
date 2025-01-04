using UnityEngine.InputSystem;

namespace Craglex.SimpleUI.Actions
{
    public class UIBuildEnter : UIActionHandler{
        public UIBuildEnter(GameUI gameUI) : base(gameUI){ GameUI = gameUI; }

        public override void HandleAction(InputAction.CallbackContext ctx,UIElement target){
            if(ctx.phase != InputActionPhase.Started)
                return;
            
            if(GameUI.lastTarget == null){
                GameUI.OpenUI(target);
            }
        }
    }
}