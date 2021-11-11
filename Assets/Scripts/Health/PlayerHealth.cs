using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;
    public GameObject thePlayer;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        healthBar.SetMaxHealth(startingHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            thePlayer.SetActive(false);
        }

        healthBar.SetHealth(currentHealth);

    }

    public void DamagePlayer(int damage)
    {
        currentHealth -= damage;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("OW");
        }

        Debug.Log("TouchedPlayer");
    }

}