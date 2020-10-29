using UnityEngine;

namespace Game.Scripts
{

    public class State : ScriptableObject
    {
        public int Index { get; set; }
        
        public virtual void Initialize(StateMachine owner){}
        
        public virtual void Enter(){}
        
        public virtual void Exit(){}
        
        
    }
}