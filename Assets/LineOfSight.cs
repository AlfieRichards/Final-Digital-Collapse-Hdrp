using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{

    private GameObject player;
    public bool visible;
    // Start is called before the first frame update
    void Start()
    {
        visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other) {

        if(other.gameObject.name == "Player"){
            //other.gameObject.GetComponent<PlayerMovement>().DamagePlayer(damage);
            visible = true;
        }
        
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.name == "Player"){
            //other.gameObject.GetComponent<PlayerMovement>().DamagePlayer(damage);
            visible = false;
        }
    }
}
