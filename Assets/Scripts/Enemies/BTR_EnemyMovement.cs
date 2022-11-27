using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class BTR_EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    public BTR_XpManager exp;

    [Header("XP to give")]
    public int Xp;

    [Header("Enemy Health")] public int health;

    void Start()
    {
        exp = FindObjectOfType<BTR_XpManager>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        agent.destination = player.transform.position;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        if (other.CompareTag("PunchHitBox"))
        {
            exp.addXP(Xp);
            TakeDMG(50);
        }
        
        if (other.CompareTag("SpinHitBox"))
        {
            exp.addXP(Xp);
            TakeDMG(200);
        }
        
        if (other.CompareTag("Projectile"))
        {
            exp.addXP(Xp);
            TakeDMG(100);
        }
    } // Later Delete

    public void TakeDMG(int dmg)
    {
        health -= dmg;
    }
}
