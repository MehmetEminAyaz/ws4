using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float aggroRadius = 5f;
    public float attackSpeed = 3f;
    public Transform player;
    private bool isAggroed = false;

    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAggroed)
        {
            Vector3 direciton = (player.position - transform.position).normalized;
            transform.position += direciton * attackSpeed * Time.deltaTime;
            transform.LookAt(player);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) { isAggroed = true;}
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) { isAggroed = false;}
    }
}
