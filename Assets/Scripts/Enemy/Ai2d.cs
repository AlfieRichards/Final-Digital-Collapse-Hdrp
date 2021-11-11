using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai2d : MonoBehaviour
{
    public Transform thePlayer;

    public float agroRange;

    public float moveSpeed;

    Rigidbody myRB;
    public Animator anim;

    public int damage;

    public GameObject aimCone;
    public GameObject gun;
    public float left;
    public float right;

    //plane off is z, on is x
    public bool plane;
    //inverse on is front, off is back
    public bool inverse;
    public bool visible;
    public LineOfSight sightScript;
    public GunsAI gunScript;
    private Vector3 origin;
    public bool doPath = true;

    public float accelerationTime = 2f;
    public float maxSpeed = 5f;
    private Vector3 movement;
    private float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        sightScript = aimCone.GetComponent<LineOfSight>();
        gunScript = gun.GetComponent<GunsAI>();
        origin = transform.position;
        doPath = true;
    }

    // Update is called once per frame
    void Update()
    {
        //distance between the player
        float distToPlayer = Vector3.Distance(transform.position, thePlayer.position);
        //Debug.Log("Distbeteenplayer:" + distToPlayer);
        visible = sightScript.visible;
        if (visible){
            if (distToPlayer < agroRange){
                gunScript.Shoot();
            }
        }
        if(plane){
            if(inverse){
                if(transform.position.x > left && transform.position.x < right){
                    if(visible){
                    chasePlayer();
                    }
                    else{
                        StopChasePlayer();
                        //anim.SetBool("isRunning", false);
                    }
                } 
            }
            else{
                if(transform.position.x < left && transform.position.x > right){
                    if(visible){
                    chasePlayer();
                    }
                    else{
                        StopChasePlayer();
                        //anim.SetBool("isRunning", false);
                    }
                } 
            }
        }
        else{
            if(inverse){
                if(transform.position.z > left && transform.position.z < right){
                    if(visible){
                    chasePlayer();
                    }
                    else{
                        StopChasePlayer();
                        //anim.SetBool("isRunning", false);
                    }
                } 
            }
            else{
                if(transform.position.z < left && transform.position.z > right){
                    if(visible){
                    chasePlayer();
                    }
                    else{
                        StopChasePlayer();
                        //anim.SetBool("isRunning", false);
                    }
                } 
            }
        }

        //flip based on direction
        if(myRB.velocity.x < 0 || myRB.velocity.z < 0){
            transform.localScale = new Vector3(1, 1, -1);
        }
        else{
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void chasePlayer(){
        if(plane){
            if(transform.position.x < thePlayer.position.x){
                myRB.velocity = new Vector3(moveSpeed, 0, 0);
                transform.localScale = new Vector3(1, 1, 1);
            }
            else{
                myRB.velocity = new Vector3(-moveSpeed, 0, 0);
                transform.localScale = new Vector3(1, 1, -1);
            }
        }
        else{
            if(transform.position.z < thePlayer.position.z){
                myRB.velocity = new Vector3(0, 0, moveSpeed);
                transform.localScale = new Vector3(1, 1, 1);
            }
            else{
                myRB.velocity = new Vector3(0, 0, -moveSpeed);
                transform.localScale = new Vector3(1, 1, -1);
            }
        }

        //anim.SetBool("isRunning", true);
    }

    private void StopChasePlayer(){

        if (doPath){
            RandomMove();
        }
    }

    private void RandomMove(){
        doPath = false;
        if (plane){
            myRB.velocity = new Vector3(Random.Range(-5f, 5f), 0,  0);
        }
        else{
            myRB.velocity = new Vector3(0, 0,  Random.Range(-5f, 5f));
        }
        Invoke("Delay", 1.0f);
    }

    private void Delay(){
        doPath = true;
    }
}
