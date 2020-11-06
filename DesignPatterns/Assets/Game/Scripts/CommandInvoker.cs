using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Game.Scripts
{

    public class CommandInvoker
    {
        Queue<Command> commands = new Queue<Command>();
        private TurnStateMachine handeler = null;
        private bool toCommand = false;

        public CommandInvoker(TurnStateMachine handeler)
        {
            this.handeler = handeler;
        }

        public void AddCommand(Command command)
        {
            commands.Enqueue(command);
        }

        public void AddCommand(List<Command> commandList)
        {
            for (int i = 0; i < commandList.Count; i++)
            {
                commands.Enqueue(commandList[i]);
            }

            toCommand = true;
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
            if (toCommand)
            {
                handeler.ToCommand();
                toCommand = false;
            }
            else
            {
                handeler.NextRound();
            }
        }
    }
}