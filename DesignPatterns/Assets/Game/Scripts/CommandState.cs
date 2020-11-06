using Game.Scripts;
using UnityEngine;

[CreateAssetMenu(menuName = "States/CommandState")]
public class CommandState : BaseState
{
    public override void Enter()
    {
        ActivateAndDeactivateButtons(true);
        owner.HighlightHero();
        owner.ReturnMovement.Clear();
        owner.ProjectedPosition = owner.CurrentTarget.position;
    }

    public override void Exit()
    {
        ActivateAndDeactivateButtons(false);
    }

    private void ActivateAndDeactivateButtons(bool condition)
    {
        foreach (GameObject obj in Buttons)
        {
            obj.SetActive(condition);
        }
    }
    
    
}
