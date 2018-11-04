using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public int health;
    public int range;
    public int attackDamage;
    public float attackRate;
    UnityEngine.AI.NavMeshAgent agent;
    private Transform player;
    private float timeLastAttacked;
    private bool isDead;
    private EnemySpawn spawn;
    private Player heal;

    // Use this for initialization
    void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("EnemySpawn").GetComponent<EnemySpawn>();
        //spawn = GetComponent<EnemySpawn>();
        isDead = false;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        heal = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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
     }
    //The enemy attacks the player when they enter the collider of Hitbox
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.GetComponent<Player>() != null && collider.gameObject.tag == "Player")
        {
            if (Time.time - timeLastAttacked > attackRate)
            {
                timeLastAttacked = Time.time;
                attack();
                collider.gameObject.GetComponent<Player>().TakeDamage(attackDamage);
            }
        }
    }

    private void attack()
    {
        Debug.Log("Enemy attacked");
        Debug.Log(attackDamage);
        
    }

    public void Punched(int amount)
    {
        health -= amount;
        if (health < 0)
        {
            
            Die();      
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        heal.AddHealth();
        spawn.EnemyKilled();
        
    }
}