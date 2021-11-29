using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherEnemy : Enemy
{
    [SerializeField] private GameObject arrowAnimation, arrow;
    private int countArrow ;
    [SerializeField] private Transform position;

    public override void Start()
    {
        base.Start();
        countArrow = information.CountArm;
    }

    public override void Attack()
    {
          if(countArrow ==0)
          {
              Debug.Log(information.EnemyName+" ya no tiene flechas");
              arm = true;
          }
          else
          {
              anim.SetTrigger("Shoot");
              countArrow--;
          } 
      }

    private void ActivateAttack()
    {
        arrowAnimation.SetActive(true);
    }

    private void DesactivarAttack()
    {
        arrowAnimation.SetActive(false);
    }

    private void Shoot()
    {
        Instantiate(arrow, position);
        base.Attack();
    }
}
