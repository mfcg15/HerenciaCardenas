using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private ArrowData dataArrow;

    void Start()
    {
        player = GameObject.Find("Goal");
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.position += dataArrow.Speed * direction * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }

}
