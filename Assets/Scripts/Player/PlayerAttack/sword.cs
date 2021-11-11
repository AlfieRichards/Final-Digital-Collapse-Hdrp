using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 10;
    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Enemy"){
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }
}
