using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public int health;
    public int range;
    public float attackRate;
    UnityEngine.AI.NavMeshAgent agent;
    private Transform player;
    private float timeLastAttacked;
    private bool isDead;

    // Use this for initialization
    void Start()
    {
        isDead = false;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }

        //Makes the robot face the player
        transform.LookAt(player);

        //Makes the robot go to the player, using the navmesh
        agent.SetDestination(player.position);
        //if (Vector3.Distance(transform.position, player.position) < range && Time.time - timeLastAttacked > attackRate)
        //The enemy attacks the player when they enter the collider of Hitbox
        {
            //Calls the attack function and resets the timeLastAttacked
            timeLastAttacked = Time.time;
            attack();
        }
    }

    private void attack()
    {
        Debug.Log("Fire");
    }
}