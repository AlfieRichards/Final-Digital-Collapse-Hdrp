using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corners : MonoBehaviour
{
    private GameObject player;
    private MoveyBoi playerScript;
    public bool plane;
    public bool axis;
    
    // Start is called before the first frame update
    //When i go round the corner the controls end up backwards which means theyre like impossible to use, a possible fix is to just invert the controls but idk how 10/22/21 11:44
    //I tried sticking a - in front of it and adding random stuff on but still doesnt work
    //trigger enter get horizontyal movement if itsd lesss than 0 go left if its mroe than 0 go right, then just change the publc variable change.Whatever
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<MoveyBoi>();
    }

    //get player from trigger enter, if player.rb.velocity.x < 0 rotate by however much etc. 
    //if direction is true z plane false is x
    //horizontal 1 is right, -1 is left


    // Update is called once per frame
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            playerScript.Unlock();
            if (playerScript.direction){
                if (plane){
                    playerScript.direction = false;
                    if (!axis){
                        playerScript.inverse = 1;
                        if(playerScript.horizontal == 1){
                            playerScript.Pivot(90);
                        }
                        else{
                            playerScript.Pivot(-90);
                        }
                    }
                    else{
                        playerScript.inverse = -1;
                        if(playerScript.horizontal == -1){
                            playerScript.Pivot(-90);
                        }
                        else{
                            playerScript.Pivot(90);
                        }
                    }
                }
                else{
                    playerScript.direction = false;
                    playerScript.inverse = -1;
                    if (!axis){
                        playerScript.inverse = 1;
                        if(playerScript.horizontal == 1){
                            playerScript.Pivot(90);
                        }
                        else{
                            playerScript.Pivot(-90);
                        }
                        
                    }
                    else{
                        playerScript.inverse = -1;
                        if(playerScript.horizontal == -1){
                            playerScript.Pivot(-90);
                        }
                        else{
                            playerScript.Pivot(90);
                        }
                    }
                }
            }
            else{
                if (plane){
                    playerScript.direction = true;
                    if (!axis){
                        playerScript.inverse = -1;
                        if(playerScript.horizontal == 1){
                            playerScript.Pivot(90);
                        }
                        else{
                            playerScript.Pivot(-90);
                        }
                    }
                    else{
                        playerScript.inverse = 1;
                        if(playerScript.horizontal == -1){
                            playerScript.Pivot(-90);
                        }
                        else{
                            playerScript.Pivot(90);
                        }
                    }
                }
                else{
                    playerScript.direction = true;
                    if (!axis){
                        playerScript.inverse = 1;
                        if(playerScript.horizontal == 1){
                            playerScript.Pivot(90);
                        }
                        else{
                            playerScript.Pivot(-90);
                        }
                    }
                    else{
                        playerScript.inverse = -1;
                        if(playerScript.horizontal == -1){
                            playerScript.Pivot(-90);
                        }
                        else{
                            playerScript.Pivot(90);
                        }
                    }
                }
            }
            playerScript.Lock();
        }
    }
}
