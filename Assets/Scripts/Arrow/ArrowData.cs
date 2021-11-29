using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ArrowData", menuName = "Arrow Data")]
public class ArrowData : ScriptableObject
{
    [SerializeField] private float speed;

    public float Speed
    {
        get
        {
            return speed;
        }
    }
}
