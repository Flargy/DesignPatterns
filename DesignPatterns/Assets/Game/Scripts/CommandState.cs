using Game.Scripts;
using UnityEngine;

[CreateAssetMenu(menuName = "States/CommandState")]
public class CommandState : BaseState
{
    public override void Enter()
    {
        ActivateAndDeactivateButtons(true);
        owner.HighlightHero();
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
