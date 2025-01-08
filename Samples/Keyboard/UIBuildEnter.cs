using UnityEngine.InputSystem;

namespace Craglex.SimpleUI.Actions
{
    public class UIBuildEnter : UIActionHandler{
        public UIBuildEnter(SimpleUIHandler simpleUI) : base(simpleUI){ simpleUI = SimpleUI; }

        public override void HandleAction(InputAction.CallbackContext ctx,UIElement target){
            if(ctx.phase != InputActionPhase.Started)
                return;
            
            if(SimpleUI.lastTarget == null){
                SimpleUI.OpenUI(target);
            }
        }
    }
}