using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Animator anim;
    private GameObject player;
    private bool seeThePlayer, placePlayer, isAttack = false, ability;
    private float resetTime;
    protected bool arm;
    [SerializeField] protected EnemyData information;
    [SerializeField] private GameObject hitPoint;
    private float timeAttack;

    virtual public void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player");
        timeAttack = information.TimeAttack;
        resetTime = timeAttack;
        arm = information.Arm;
    }

    void FixedUpdate()
    {
        MoveTowards();
        LookAtPlayer();
    }


    private void MoveTowards()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;

        if ((Vector3.Distance(player.transform.position, transform.position) >= information.RangoOfView))
        {
            anim.SetFloat("SpeedY", 0f);
            seeThePlayer = true;
        }
        else
        {

            if (Vector3.Distance(player.transform.position, transform.position) <= information.AttackDistance)
            {
                anim.SetFloat("SpeedY", 0f);
                placePlayer = true;
            }
            else
            {
                transform.position += information.Speed * direction * Time.deltaTime;
                anim.SetFloat("SpeedY", 1f);
                seeThePlayer = false;
                placePlayer = false;
            }

            if (placePlayer == true && arm == false)
            {
                RaycastHitAttack(hitPoint.transform);
                isAttack = true;
            }
            else
            {
                isAttack = false;
            }
        }

    }

    private void LookAtPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, information.Rotation * Time.deltaTime);
    }

    private void RaycastHitAttack(Transform point)
    {
        RaycastHit hit;
        if (Physics.Raycast(point.position, point.TransformDirection(Vector3.forward), out hit, information.AttackDistance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                if (timeAttack == resetTime)
                {   
                    Attack();
                    ability = true;
                }

                if (ability)
                {
                    timeAttack -= Time.deltaTime;

                    if (timeAttack <= 0)
                    {
                        timeAttack = resetTime;
                    }
                }
            }
        }
    }

    private void DrawRay(Transform point)
    {
        Gizmos.color = Color.blue;
        Vector3 direction = point.TransformDirection(Vector3.forward) * information.AttackDistance;
        Gizmos.DrawRay(point.position, direction);
    }

    private void DrawRaycast()
    {
        DrawRay(hitPoint.transform);
    }

    private void OnDrawGizmos()
    {

        if (seeThePlayer)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }

        Gizmos.DrawWireSphere(transform.position, information.RangoOfView);

        if (isAttack)
        {
            DrawRaycast();
        }
    }

    public virtual void Attack()
    {
        Debug.Log(information.EnemyName + " ha utlizado " + information.TypeAttack);
    }

}
