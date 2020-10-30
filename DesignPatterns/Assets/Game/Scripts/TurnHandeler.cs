using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts
{
    public class TurnHandeler : MonoBehaviour
    {
        [SerializeField] private Transform[] transforms = new Transform[3];
        [SerializeField] private GameObject[] buttons = new GameObject[5];
        
        private CommandInvoker invoker;

        private Transform currentTarget;
        private int currentIndex = 0;
        
        // Start is called before the first frame update
        void Awake()
        {
            //invoker = new CommandInvoker(this);
            currentTarget = transforms[currentIndex];
        }

        private void Start()
        {
            HighlightHero();
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

        private void SwapHero()
        {
            RemoveHighlight();
            currentIndex++;
            if (currentIndex > transforms.Length - 1)
            {
                currentIndex = 0;
                invoker.ExecuteCommands();
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].gameObject.SetActive(false);
                }
            }
            
            currentTarget = transforms[currentIndex];
            HighlightHero();
        }

        private void HighlightHero()
        {
            currentTarget.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }

        private void RemoveHighlight()
        {
            currentTarget.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        }

        public void NextRound()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetActive(true);
            }
        }
    }
}