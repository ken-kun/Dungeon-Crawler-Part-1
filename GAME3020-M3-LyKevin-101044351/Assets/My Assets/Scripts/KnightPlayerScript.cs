using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightPlayerScript : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float platformSpeed = 1f;
    // [SerializeField] private float rotSpeed = 10f;
    //[SerializeField] GameObject deadZone;
    private PlayerHealth playerHealthScript;
    

    private Rigidbody myRigidBody;
    private Animator anim;

    public GameObject movingPlatform;
    //float mouseX;

    private void Start()
    {
        playerHealthScript = GetComponent<PlayerHealth>();
        myRigidBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        
      
    }

    // Update is called once per frame
    void Update () {
        
		Vector3 offset = Vector3.zero;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //mouseX += Input.GetAxis("Mouse X") * rotSpeed;
        if (playerHealthScript.isAlive)
        {
            if (movingPlatform != null)
            {
                if (Mathf.Abs(h) > 0 || Mathf.Abs(v) > 0)
                {
                    transform.parent = null;
                    myRigidBody.MovePosition(transform.position + (((h * transform.right) + (v * transform.forward)) * moveSpeed * platformSpeed * Time.deltaTime));
                    anim.SetFloat("speed", v);
                    anim.SetFloat("sideSpeed", h);
                    
                    GetInput();
                }
                else
                {
                    transform.parent = movingPlatform.transform;
                }
            }
            else
            {

                myRigidBody.MovePosition(transform.position + (((h * transform.right) + (v * transform.forward)) * moveSpeed * Time.deltaTime));
                anim.SetFloat("speed", v);
                anim.SetFloat("sideSpeed", h);
                //anim.SetFloat("cameraSpeed", mouseX);

                GetInput();
            }
        }




        //      if (Input.GetKey("w"))
        //{ 
        //          myRigidBody.MovePosition(transform.position + (transform.forward * moveSpeed * Time.deltaTime));
        //          //offset += Vector3.forward;
        //      }
        //if (Input.GetKey("s"))
        //{
        //          myRigidBody.MovePosition(transform.position + (-transform.forward * moveSpeed * Time.deltaTime));
        //          //offset += Vector3.back;
        //      }
        //      if (Input.GetKey("a"))
        //      {
        //          myRigidBody.MovePosition(transform.position + (-transform.right * moveSpeed * Time.deltaTime));
        //          //offset += Vector3.left;
        //      }
        //      if (Input.GetKey("d"))
        //      {
        //          myRigidBody.MovePosition(transform.position + (transform.right * moveSpeed * Time.deltaTime));
        //          //offset += Vector3.right;
        //      }
        //      offset = Vector3.Normalize(offset) * moveSpeed * Time.deltaTime;
        //transform.Translate(offset, Space.World);
        //if (offset.magnitude > 0)
        //{
        //	Quaternion rotDir = Quaternion.LookRotation(offset);
        //	transform.rotation = Quaternion.RotateTowards( transform.rotation, rotDir, rotSpeed * Time.deltaTime );
        //}
    }


    void GetInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Attacking();
            
        }
    }


    void Attacking()
    {

        anim.SetTrigger("Attacking");
       
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Death")
        {
            anim.SetTrigger("Dead");
        }

        if(other.gameObject.tag == "Fire")
        {
            playerHealthScript.ChangeHealth(-10.5f);
        }

        

        
    }

    private void OnTriggerStay(Collider other)
    {
        if (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Hit")
        { 
            if (other.tag == "Weapon")
            {
                GameObject enemy = other.transform.parent.gameObject;
                if (enemy.GetComponent<EnemyAttackScript>().canAttack)
                {
                    myRigidBody.AddForce(enemy.transform.forward * 700);
                    anim.SetBool("Hit", true);
                    playerHealthScript.ChangeHealth(-10.0f);
                    enemy.GetComponent<EnemyAttackScript>().canAttack = false;
                    //myRigidBody.AddRelativeForce(-transform.forward);
                    
                }
            }
        }



        
    }

    public void resetHit()
    {
        Debug.Log("Reset Hit");
        anim.SetBool("Hit", false);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "MovingPlatform")
    //    {
    //        parentObject.transform.SetParent(collision.transform);
    //    }
    //}


}
