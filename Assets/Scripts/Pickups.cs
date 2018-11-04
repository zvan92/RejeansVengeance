using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pickups : MonoBehaviour
{
    private Text pickupActivatedText;
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
