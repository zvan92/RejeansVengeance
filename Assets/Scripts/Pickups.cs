using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pickups : MonoBehaviour
{
    private Player player;
    
    // finds player on instantiation
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Cocaine"))
            {
                player.pickupCocaine();
            }
            if (gameObject.CompareTag("Bandaid"))
            {
                player.pickupBandaid();
            }
            Destroy(gameObject);
        }
    }
}
