using Game.Scripts;
using UnityEngine;

[CreateAssetMenu(menuName = "States/ResetState")]
public class ResetState : BaseState
{
    public override void Enter()
    {
        // start something that will reset the positions of the players
        // will need a list of commands
        // list of reverse commands
        // transparent prefabs to place to show where you will go.
        // undo button to remove previous command
        owner.Invoker.AddCommand(owner.ReturnMovement);
        owner.Invoker.ExecuteCommands();
    }
}
