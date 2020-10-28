using UnityEngine;

namespace Game.Scripts
{
    public class MoveCommand : Command
    {
        private Transform transform = null;
        Vector3 moveAmount = Vector3.zero;

        public MoveCommand(Transform transform, Vector3 moveAmount)
        {
            this.transform = transform;
            this.moveAmount = moveAmount;
        }

        public override void Execute()
        {
            transform.Translate(moveAmount);
        }
    }
}