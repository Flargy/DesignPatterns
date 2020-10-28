using UnityEngine;
using Game.Scripts;


public class AttackCommand : Command
{
    private Transform transform = null;

    public AttackCommand(Transform transform)
    {
        this.transform = transform;
    }

    public override void Execute()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.5f, LayerMask.GetMask("Enemy")))
        {
            hit.collider.GetComponent<EnemyBehaviour>().TakeDamage(1);
            DamageText.SpawnText(hit.point + Vector3.up, 1);
        }
    }
}
