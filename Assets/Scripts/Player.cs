﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    const float cHealthDrain = -3.0f;
    const float totalHealth = 100;

    public int lightDamage;
    public int heavyDamage;
    private GameObject enemy;

    [SerializeField] private float health;
    [SerializeField] private float healthDrain;
    [SerializeField] private Text HealthText;
    [SerializeField] private Text MorphineText;
    [SerializeField] private Image healthBar;

    private float speed;
    private int morphine;
	// Use this for initialization
	void Start ()
    {
       health = totalHealth;
        healthDrain = cHealthDrain;
        
    }

    public void AddHealth()
    {
        health += 10.0f;
    }

    private void TakeMorphine()
    {
        //there is a input.keydown == m in the update funtcion of the same script
        morphine = 0;
        MorphineText.text = "morphine: " + morphine;
        Debug.Log("Mighty Morphine Power Rangers!");
        // Whatever else it does
    }

    public void TakeDamage(int amount)
    {
        int playerDamage = amount;
        health -= playerDamage;
        healthBar.fillAmount = health / totalHealth;
    }

    public void pickupCocaine()
    {
        healthDrain = cHealthDrain * 2;
        lightDamage = lightDamage * 2;
        heavyDamage = heavyDamage * 2;
        StartCoroutine("CocaineTimer");
    }

    IEnumerator CocaineTimer()
    {
       yield return new WaitForSeconds(5);
        healthDrain = cHealthDrain;
        lightDamage = lightDamage / 2;
        heavyDamage = heavyDamage / 2;
    }

    public void pickupBandaid()
    {
        healthDrain = cHealthDrain * 0;
        StartCoroutine("BandaidTimer");
    }

    IEnumerator BandaidTimer()
    {
        yield return new WaitForSeconds(5);
        healthDrain = cHealthDrain;
    }

	// Update is called once per frame
	void Update ()
    {
        health += healthDrain * Time.deltaTime;
        healthBar.fillAmount = health / totalHealth;
        HealthText.text = health.ToString("F");         // if you guys can make it at integer value that'd be great

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("Pressed primary button.");

            //draws a raycast and checks if it is range
            RaycastHit ray;
            //draws a raycast and checks if it is range
            if (Physics.Raycast(transform.position, fwd, out ray, 3))
            {
                //calls the punched function to the enemy to apply the damage
                enemy = ray.collider.gameObject;
                enemy.GetComponent<EnemyScript>().Punched(lightDamage);
            }
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            Debug.Log("Pressed secondary button.");
            RaycastHit ray;
            //draws a raycast and checks if it is range
            if (Physics.Raycast(transform.position, fwd, out ray, 3))
            {
                //calls the punched function to the enemy to apply the damage
                enemy = ray.collider.gameObject;
                enemy.GetComponent<EnemyScript>().Punched(heavyDamage);
            }
        }


        if (Input.GetKeyDown(KeyCode.M))
        {
            TakeMorphine();
        }
    }
}
