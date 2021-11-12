using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;

    public GameObject thePlayer;
    public float killDelay;
    public bool isEnemy;
    public HealthBar healthBar;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        if(!isEnemy){
            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0){
                thePlayer.SetActive(false);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Debug.Log("PlayerDied");
            }
        }
        else{
            if (currentHealth <= 0f){
                Invoke("Destroy", killDelay);
            }
        }
    }
    private void Destroy()
    {
        gameObject.SetActive(false);
    }
    private void Start() {
        currentHealth = startingHealth;
        if(!isEnemy){
            healthBar.SetMaxHealth(startingHealth);
        }
    }
}
