using UnityEngine;


namespace Game.Scripts
{
    public class BaseState : State
    {

        protected Transform[] Players
        {
            get { return owner.Players; }
        }
        
        protected GameObject[] Buttons
        {
            get { return owner.Buttons; }
        }
        
        public Transform CurrentTarget
        {
            get { return owner.CurrentTarget; }
        }
        public CommandInvoker Invoker
        {
            get { return owner.Invoker; }
        }

        protected TurnStateMachine owner;
        
        public override void Initialize(StateMachine owner)
        {
            this.owner = (TurnStateMachine)owner;
            
        }
    }
}