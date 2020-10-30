using UnityEngine;

namespace Game.Scripts
{

    public class TurnStateMachine : StateMachine
    
    {
        public Transform[] Players
        {
            get { return players; }
        }
        public GameObject[] Buttons
        {
            get { return buttons; }
        }
        
        public Transform CurrentTarget
        {
            get { return currentTarget; }
        }
        public CommandInvoker Invoker
        {
            get { return invoker; }
        }


        [SerializeField] private Transform[] players = new Transform[3];
        [SerializeField] private GameObject[] buttons = new GameObject[5];
        
        
        private CommandInvoker invoker;

        private Transform currentTarget;
        private int currentIndex = 0;


        void Awake()
        {
            invoker = new CommandInvoker(this); //fix this once everythign is set up
            currentTarget = players[currentIndex];
            HighlightHero();
            base.Awake();
        }
        
        public void SwapHero()
        {
            RemoveHighlight();
            currentIndex++;
            if (currentIndex > players.Length - 1)
            {
                currentIndex = 0;
                for (int i = 0; i < buttons.Length; i++)
                {
                    TransitionTo<ExecuteState>();
                    currentTarget = players[currentIndex];
                    return;
                }
            }
            
            currentTarget = players[currentIndex];
            HighlightHero();
        }
        
        public void HighlightHero()
        {
            currentTarget.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }

        public void RemoveHighlight()
        {
            currentTarget.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        }

        public void NextRound()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                TransitionTo<CommandState>();
            }
        }
        
        public void MoveForward()
        {
            invoker.AddCommand(new MoveCommand(currentTarget, Vector3.forward));
        }
    
        public void MoveBackwards()
        {
            invoker.AddCommand(new MoveCommand(currentTarget, Vector3.back));
        }
        
        public void MoveLeft()
        {
            invoker.AddCommand(new MoveCommand(currentTarget, Vector3.left));
        }
        
        public void MoveRight()
        {
            invoker.AddCommand(new MoveCommand(currentTarget, Vector3.right));
        }
        
        public void Attack()
        {
            invoker.AddCommand(new AttackCommand(currentTarget));
            SwapHero();
            
        }
        
        // handeler specific things should be in here
        // make the different states
        // currently need 2-3 states, CommandState, ExecuteState, BaseState and (possibly) ResetState
    }
}