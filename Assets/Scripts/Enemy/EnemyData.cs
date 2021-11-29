using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyData", menuName = "Enemy Data")]
public class EnemyData : ScriptableObject
{
    [SerializeField] private string enemyName;
    [SerializeField] private float speed, rotation, rangeOfView;
    [SerializeField] private string typeAttack;
    [SerializeField] private bool arm;
    [SerializeField] private int countArm;
    [SerializeField] private float attackDistance , timeAttack;

    public string EnemyName
    {
        get
        {
            return enemyName;
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }
    }

    public float Rotation
    {
        get
        {
            return rotation;
        }
    }

    public float RangoOfView
    {
        get
        {
            return rangeOfView;
        }
    }

    public string TypeAttack
    {
        get
        {
            return typeAttack;
        }
    }

    public bool Arm
    {
        get
        {
            return arm;
        }
    }

    public int CountArm
    {
        get
        {
            return countArm;
        }
    }

    public float AttackDistance
    {
        get
        {
            return attackDistance;
        }
    }

    public float TimeAttack
    {
        get
        {
            return timeAttack;
        }
    }

}
