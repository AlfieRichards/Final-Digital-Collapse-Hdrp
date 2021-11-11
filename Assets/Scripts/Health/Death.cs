using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public int damage;
    private GameObject Player;
    private GameObject Self;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("player");
    }

    // Update is called once per frame
    void OnCollisionEnter2d(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Hit Player");
            // Player.GetComponent<PlayerHealth>().DamagePlayer(damage);

            Destroy(gameObject);

        }
    }
}