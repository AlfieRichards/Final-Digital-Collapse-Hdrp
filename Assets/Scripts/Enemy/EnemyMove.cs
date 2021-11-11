using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : Enemies
{
    public float followRadius;
    public float attackRadius;
    public float speed;
    public GameObject player;
    public bool inFollow = false;
    public bool inAttack = false;

    //movement
    //end
    public Transform playerTransform;
    public Animator enemyAnim;
    SpriteRenderer enemySR;



    void Start()
    {
      //get the player transform   
        playerTransform = player.transform;
      //enemy animation and sprite renderer 
        enemyAnim = gameObject.GetComponent<Animator>();
        enemySR = GetComponent<SpriteRenderer>();
        
      //set the variables
    }

    // Update is called once per frame

    //if player in radius move toward him 
    public void checkFollowRadius(float playerPosition, float enemyPosition)
    {
        if(Mathf.Abs(playerPosition -enemyPosition) < followRadius)
        {
            //player in range
            inFollow = true;
        }
        else
        {
            inFollow = false;
        }
    }

    //if player in radius attack him
    public void checkAttackRadius(float playerPosition, float enemyPosition)
    {
        if (Mathf.Abs(playerPosition - enemyPosition) < attackRadius)
        {
            //in range for attack
            inAttack = true;
        }
        else
        {
            inAttack = false;
        }
    }
    void Update()
    {
        if (inFollow)
        {
            //if player in front of the enemies
            if (playerTransform.position.x < transform.position.x)
            {

                if (inAttack)
                {
                    //for attack animation
                    //enemyAnim.SetBool("AttackA", true);
                }
                else
                {
                    this.transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
                    //for attack animation
                    //enemyAnim.SetBool("AttackA", false);
                    //walk
                    //enemyAnim.SetBool("Walking", true);
                    enemySR.flipX = true;
                }

            }
            //if player is behind enemies
            else if(playerTransform.position.x > transform.position.x)
            {
                if (inAttack)
                {
                    //for attack animation
                    //enemyAnim.SetBool("AttackA", true);
                }
                else
                {
                    this.transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
                    //for attack animation
                    //enemyAnim.SetBool("AttackA", false);
                    //walk
                    //enemyAnim.SetBool("Walking", true);
                    enemySR.flipX = false;
                }


            }
        }
        else
        {
            //enemyAnim.SetBool("Walking", false);
        }


    }
}