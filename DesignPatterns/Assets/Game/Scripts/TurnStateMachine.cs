using System.Collections.Generic;
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
        public List<Command> ReturnMovement;
        public Vector3 ProjectedPosition;


        [SerializeField] private Transform[] players = new Transform[3];
        [SerializeField] private GameObject[] buttons = new GameObject[5];
        [SerializeField] private GameObject colliderPrefab;
        
        private CommandInvoker invoker;

        private Transform currentTarget;
        private int currentIndex = 0;
        private List<Command> reverseMovement;
        private List<GameObject> colliderList;

        void Awake()
        {
            invoker = new CommandInvoker(this); //fix this once everythign is set up
            currentTarget = players[currentIndex];
            //ProjectedPosition = currentTarget.position;
            HighlightHero();
            ReturnMovement = new List<Command>();
            reverseMovement = new List<Command>();
            colliderList = new List<GameObject>();
            for (int i = 0; i < players.Length; i++)
            {
                GameObject obj = Instantiate(colliderPrefab);
                obj.SetActive(false);
                colliderList.Add(obj);
            }
            base.Awake();
        }
        
        public void SwapHero()
        {
            RemoveHighlight();
            colliderList[currentIndex].SetActive(true);
            colliderList[currentIndex].transform.position = ProjectedPosition;
            currentIndex++;
            reverseMovement.Reverse();
            ReturnMovement.AddRange(reverseMovement);
            reverseMovement.Clear();
            if (currentIndex > players.Length - 1)
            {
                foreach (GameObject obj in colliderList)
                {
                    obj.SetActive(false);
                }
                currentIndex = 0;
                for (int i = 0; i < buttons.Length; i++)
                {
                    TransitionTo<ExecuteState>();
                    currentTarget = players[currentIndex];
                    return;
                }
            }
            
            currentTarget = players[currentIndex];
            ProjectedPosition = currentTarget.position;
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
            TransitionTo<ResetState>();
        }

        public void ToCommand()
        {
            TransitionTo<CommandState>();
        }
        
        public void MoveForward()
        {
            if(AllowMovement(Vector3.forward) == false)
            {
                return;
            }
                invoker.AddCommand(new MoveCommand(currentTarget, Vector3.forward));
                reverseMovement.Add(new MoveCommand(currentTarget, Vector3.back));
        }
    
        public void MoveBackwards()
        {
            if(AllowMovement(Vector3.back) == false)
            {
                return;
            }
            invoker.AddCommand(new MoveCommand(currentTarget, Vector3.back));
            reverseMovement.Add(new MoveCommand(currentTarget, Vector3.forward));

        }
        
        public void MoveLeft()
        {
            if(AllowMovement(Vector3.left) == false)
            {
                return;
            }
            invoker.AddCommand(new MoveCommand(currentTarget, Vector3.left));
            reverseMovement.Add(new MoveCommand(currentTarget, Vector3.right));

        }
        
        public void MoveRight()
        {
            if(AllowMovement(Vector3.right) == false)
            {
                return;
            }
            invoker.AddCommand(new MoveCommand(currentTarget, Vector3.right));
            reverseMovement.Add(new MoveCommand(currentTarget, Vector3.left));

        }
        
        public void Attack()
        {
            invoker.AddCommand(new AttackCommand(currentTarget));
            SwapHero();
            
        }

        private bool AllowMovement(Vector3 moveAmount)
        {
            Vector3 position = ProjectedPosition;
            Vector3 newLocation = position + moveAmount;
            Vector3 direction = newLocation - position;
            if (newLocation.z < 0.5f || newLocation.z > 11.5f || newLocation.x < - 4.5f || newLocation.x > 5.5f)
            {
                return false;
            }
            else if(Physics.Raycast(position, direction, 1, ~0))
            {
                Debug.Log("its a hit");
                return false;
            }
            ProjectedPosition += moveAmount;
            return true;
        }
        
        // handeler specific things should be in here
        // make the different states
        // currently need 2-3 states, CommandState, ExecuteState, BaseState and (possibly) ResetState
    }
}