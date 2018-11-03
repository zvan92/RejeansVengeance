using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float health;
    public float healthDrain;
    public int damage;
    private int timeForDrain;

	// Use this for initialization
	void Start ()
    {
        timeForDrain = 60;	
	}

    private void TakeMorphine()
    {

    }
	
    private void TakeDamage(int amount)
    {
        int playerDamage = amount;
        health -= playerDamage;
    }

    private void pickupCocaine()
    {
        healthDrain = healthDrain = 2;
        damage = damage * 2;
    }

    IEnumerator cocaineTimer()
    {
       yield return new WaitForSeconds(5);
        healthDrain = 1;
        damage = damage / 2;
    }

    private void pickupBandaid()
    {
        healthDrain = 0;
        StartCoroutine("Bandaid");
    }

    IEnumerator bandaidTimer()
    {
        yield return new WaitForSeconds(5);
        healthDrain = 1;
    }

	// Update is called once per frame
	void Update ()
    {
        health += healthDrain * Time.deltaTime;
	}
}
