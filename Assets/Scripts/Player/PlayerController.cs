using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rbPlayer;
    private float moveVertical, timeEnd;
    private bool isLife;

    [SerializeField] int lifePlayer;
    [SerializeField] bool shield;
    [SerializeField] PlayerData dataPlayer;

    void Start()
    {
        anim = GetComponent<Animator>();
        rbPlayer = GetComponent<Rigidbody>();
        lifePlayer = dataPlayer.LifePlayer;
        timeEnd = dataPlayer.TimeEnd;
        isLife = true;
    }

    void FixedUpdate()
    {
        if(isLife)
        {
            Move();
            Rotation();

            if (Input.GetKey(KeyCode.Z))
            {
                anim.SetTrigger("Shield");
                shield = true;
            }
            else
            {
                shield = false;
            }
        }
        else
        {

            timeEnd -= Time.deltaTime;

            if (timeEnd <= 0)
            {
                Debug.Log("Fin del juego");
                Debug.Break();
            }
        }
    }

    private void Move()
    {
        moveVertical = Input.GetAxis("Vertical");
        transform.Translate(0, 0, moveVertical * Time.deltaTime * dataPlayer.Speed);
        anim.SetFloat("SpeedY", moveVertical);
    }

    private void Rotation()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0.0f, Time.deltaTime * -(dataPlayer.Rotation), 0.0f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0.0f, Time.deltaTime * dataPlayer.Rotation, 0.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Arrow" || other.gameObject.tag == "Fist")
        {

            if (shield == false)
            {
                lifePlayer--;

                if (other.gameObject.tag == "Arrow")
                {
                    anim.SetTrigger("HitArrow");

                    if(lifePlayer == 0)
                    {
                        anim.SetTrigger("DeathArrow");
                        isLife = false;
                    }
                }

                if (other.gameObject.tag == "Fist")
                {
                    anim.SetTrigger("HitPunch");
                    if (lifePlayer == 0)
                    {
                        anim.SetTrigger("DeathPunch");
                        isLife = false;
                    }
                }
            }
        }
    }

}
