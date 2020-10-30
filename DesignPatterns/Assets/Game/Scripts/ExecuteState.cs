using Game.Scripts;
using UnityEngine;

[CreateAssetMenu(menuName = "States/ExecuteState")]
public class ExecuteState : BaseState
{
    public override void Enter()
    {
        Invoker.ExecuteCommands();
    }

    
}
