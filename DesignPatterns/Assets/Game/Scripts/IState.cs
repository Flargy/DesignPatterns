
namespace Game.Scripts
{
    public interface IState
    {
        TurnStateMachine Owner { get; set; }
        
        void Enter();

        void Exit();
    }
}