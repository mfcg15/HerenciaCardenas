using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerData", menuName = "Player Data")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private int lifePlayer;
    [SerializeField] private float speed, rotation, timeEnd;

    public int LifePlayer
    {
        get
        {
            return lifePlayer;
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

    public float TimeEnd
    {
        get
        {
            return timeEnd;
        }
    }

}
