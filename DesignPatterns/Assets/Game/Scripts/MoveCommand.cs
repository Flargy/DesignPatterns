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
            // Vector3 position = transform.position;
            // Vector3 newLocation = position + moveAmount;
            // Vector3 direction = newLocation - position;
            // if (newLocation.z < 0.5f || newLocation.z > 11.5f || newLocation.x < -4.5f || newLocation.x > 5.5f)
            // {
            //     return false;
            // }
            // else if (Physics.Raycast(position, direction, 1, ~0))
            // {
            //     return false;
            // }
            transform.Translate(moveAmount);
            //return true;
        }
    }
}