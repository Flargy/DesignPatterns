using System.Collections;
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
            get
            {
                return buttons;

            }
        }


        [SerializeField] private Transform[] players = new Transform[3];
        [SerializeField] private GameObject[] buttons = new GameObject[5];
        
        
        private CommandInvoker invoker;

        private Transform currentTarget;
        private int currentIndex = 0;


        void Awake()
        {
            //invoker = new CommandInvoker(this); //fix this once everythign is set up
            currentTarget = players[currentIndex];
        }
        
        // handeler specific things should be in here
        // make the different states
        // currently need 2-3 states, CommandState, ExecuteState, BaseState and (possibly) ResetState
    }
}