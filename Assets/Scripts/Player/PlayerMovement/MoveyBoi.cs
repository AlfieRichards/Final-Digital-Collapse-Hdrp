using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveyBoi : MonoBehaviour
{
    [Header("Stats")]
    public float moveSpeed;
	public float jumpHeight;
	private bool isGrounded;
    public int inverse = 1;
    public bool direction;
    public string axis;
    public float horizontal;
    private Rigidbody myRB;
    private Vector3 change;
    private Vector3 final;
	private Vector3 jumpVector;
    public Transform customPivot;
    public Animator animations;

    

    void Start()
    {
        myRB = GetComponent<Rigidbody>();
		jumpVector = new Vector3(0.0f,1.0f,0.0f);
        myRB.constraints |= RigidbodyConstraints.FreezeRotationY;
    }

    void FixedUpdate()
    {
        change = Vector3.zero;
        if (direction){
            axis = "x";
            change.x = Input.GetAxisRaw("Horizontal");
            myRB.constraints |= RigidbodyConstraints.FreezePositionZ;
            myRB.constraints &= ~RigidbodyConstraints.FreezePositionX;
        }
        else{
            axis = "z";
            change.z = Input.GetAxisRaw("Horizontal");
            myRB.constraints |= RigidbodyConstraints.FreezePositionX;
            myRB.constraints &= ~RigidbodyConstraints.FreezePositionZ;

        }

        horizontal = Input.GetAxisRaw("Horizontal");
        
        //change.z =Input.GetAxisRaw("Horizontal");
        if(change != Vector3.zero){
            MovePlayer();
            animations.SetBool("Running", true);
        }
        else{
            animations.SetBool("Running", false);
        }

		if(Input.GetKey(KeyCode.Space) && isGrounded){
			Jump();
		}
        if (Input.GetKey("a"))
        {
            flip.FaceLeft(gameObject, true);
        }
        else if (Input.GetKey("d"))
        {
            flip.FaceLeft(gameObject, false);
        }
    }
    void MovePlayer(){
        myRB.MovePosition(transform.position + (change * inverse) * moveSpeed * Time.deltaTime);
    }

	void Jump(){
		 myRB.AddForce(jumpVector* jumpHeight, ForceMode.Impulse);
		 isGrounded = false;
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Ground"){
			isGrounded = true;
            myRB.velocity = Vector3.zero;
            myRB.angularVelocity = Vector3.zero;
		}
	}
    public void Pivot(int degrees){
        transform.RotateAround(customPivot.transform.position, Vector3.down, degrees);
    }

    public void Lock(){
        myRB.constraints |= RigidbodyConstraints.FreezeRotationY;
    }
    public void Unlock(){
        myRB.constraints &= ~RigidbodyConstraints.FreezeRotationY;
    }
}
