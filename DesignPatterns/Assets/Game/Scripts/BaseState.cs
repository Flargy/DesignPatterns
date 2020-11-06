using System.Collections.Generic;
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

        protected List<Command> ReturnMovement
        {
            get { return owner.ReturnMovement; }
        }
        
        public Transform CurrentTarget
        {
            get { return owner.CurrentTarget; }
        }
        public CommandInvoker Invoker
        {
            get { return owner.Invoker; }
        }

        public Vector3 ProjectedPosition
        {
            get { return owner.ProjectedPosition; }
        }

        protected TurnStateMachine owner;
        
        public override void Initialize(StateMachine owner)
        {
            this.owner = (TurnStateMachine)owner;
            
        }
    }
}