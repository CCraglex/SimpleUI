using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Craglex.SimpleUI.Actions
{
    public class UISelect : UIActionHandler {
        public UISelect(GameUI gameUI) : base(gameUI){ GameUI = gameUI; }

        public override void HandleAction(InputAction.CallbackContext ctx, UIElement target){

            if(ctx.phase != InputActionPhase.Started)
                return;
            
            GameObject selected = EventSystem.current.currentSelectedGameObject;
            if(selected == null)
                return;

            selected.TryGetComponent(out ISelectable selectable);
            selectable?.OnSelect();
        }
    }
}