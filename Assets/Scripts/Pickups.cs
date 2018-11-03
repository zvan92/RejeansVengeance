using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour {

    public Player player;
	// Use this for initialization
	
    private void OnTriggerEnter(Collider other)
    {
       
        if (CompareTag("Cocaine"))
        {
            player.pickupCocaine();
        }
        if (CompareTag("Bandaid"))
        {
            player.pickupBandaid();
        }
        Destroy(gameObject);
    }

}
