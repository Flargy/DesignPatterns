﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts
{

    public class CommandInvoker
    {
        Queue<Command> commands = new Queue<Command>();
        private TurnHandeler handeler = null;
        
        public CommandInvoker(TurnHandeler handeler)
        {
            this.handeler = handeler;
        }

        public void AddCommand(Command command)
        {
            commands.Enqueue(command);
        }

        public void ExecuteCommands()
        {
            handeler.StartCoroutine(CommandExecution());
        }

        private IEnumerator CommandExecution()
        {
            foreach (Command com in commands)
            {
                com.Execute();
                yield return new WaitForSeconds(0.2f);
            }
            
            commands.Clear();
            handeler.NextRound();
        }
    }
}