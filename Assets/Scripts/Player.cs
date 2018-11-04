using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    const float cHealthDrain = -3.0f;
    const float totalHealth = 100;

    [SerializeField] private int damage;
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
       
    }

    private void TakeMorphine()
    {
        //there is a input.keydown == m in the update funtcion of the same script
        MorphineText.text = morphine.ToString("Morphine: " + morphine);
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
        healthDrain = cHealthDrain;
        damage = damage * 2;
    }

    IEnumerator cocaineTimer()
    {
       yield return new WaitForSeconds(5);
        healthDrain = cHealthDrain * 2;
        damage = damage / 2;
    }

    public void pickupBandaid()
    {
        healthDrain = cHealthDrain * 0;
        StartCoroutine("Bandaid");
    }

    IEnumerator bandaidTimer()
    {
        yield return new WaitForSeconds(5);
        healthDrain = cHealthDrain;
    }

	// Update is called once per frame
	void Update ()
    {
        health += cHealthDrain * Time.deltaTime;
        healthBar.fillAmount = health / totalHealth;
        HealthText.text = health.ToString("F");         // if you guys can make it at integer value that'd be great

        if (Input.GetKeyDown(KeyCode.M))
        {
            TakeMorphine();
        }
    }
}
