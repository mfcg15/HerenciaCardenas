using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanguarEnemy : Enemy
{
    [SerializeField] private BoxCollider attack;

    public override void Attack()
    {
        anim.SetTrigger("Punch");
        base.Attack();
    }

    private void ActivateBoxCollaider()
    {
        attack.enabled = true;
    }

    private void DesactivarBoxCollaider()
    {
        attack.enabled = false;
    }
}
