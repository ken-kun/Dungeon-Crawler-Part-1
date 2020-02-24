using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private Animator anim;

	[SerializeField] private Transform targetObj;
	[SerializeField] private float moveSpeed;
    [SerializeField] private float wanderSpeed;
	[SerializeField] private float rotSpeed;
	[SerializeField] private float slowDist; 
	[SerializeField] private float stopDist;
    [SerializeField] private float seekDist;
    private EnemyHealth enemyHealth;
    private Rigidbody enemyRBody;

    private bool isMoving; // This flag controls whether or not the actor is moving. Set false when arrived.
    private bool isWandering; //cpmtrols wheather actor is wondering 
	private Vector3 destVect; // Direction to target. Calculated each frame in Update.
	private Quaternion destRot; // Desired rotation to target. Calculated each frame in Update.
	private float distTo; // Distance to target. Calculated each frame in Update.

	void Start()
	{
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
		SetMoving(true);
        SetWandering(true);
        GetNewDest();
        enemyRBody = GetComponent<Rigidbody>();
	}

	void Update () {
        ///calculations
		destVect = targetObj.position - transform.position;
		
		distTo = Vector3.Distance(transform.position, targetObj.position);


		if (isMoving) { 

            if (isWandering)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, destRot, rotSpeed * Time.deltaTime);
                if (transform.rotation == destRot)
                {
                    GetNewDest();
                }


            }
            else
            {

                destRot = Quaternion.LookRotation(destVect);
                //chase behavour
                transform.rotation = Quaternion.RotateTowards(transform.rotation, destRot, rotSpeed * Time.deltaTime);
                transform.eulerAngles = new Vector3(0.0F, transform.eulerAngles.y, 0.0F); // Zeroing out all but Y rotation. 2.5D
                
            }
            
            //Move along Z...
            transform.Translate(Vector3.forward * ((isWandering ? wanderSpeed : moveSpeed) * Mathf.Clamp((distTo / slowDist), 0.0F, 1.0F) * Time.deltaTime));
            anim.speed = 0.2f * (isWandering ? wanderSpeed : moveSpeed) * Mathf.Clamp((distTo / slowDist), 0.0F, 1.0F);
        }



        if (distTo <= seekDist)
        {
            SetWandering(false);
        }

        if ( distTo <= stopDist ) //distance checking 
		{
			SetMoving(false);
            anim.SetTrigger("Attacking");
		}
		
        if (distTo > stopDist)
		{
			SetMoving(true);
		}
        
        if (distTo > seekDist)
        {
            SetWandering(true);
            SetMoving(true);
        }
	}



	public void SetMoving(bool toggle)
	{
		isMoving = toggle; //for motion
		anim.SetBool("isMoving", toggle); //for animation
	}

    public void SetWandering(bool toggle)
    {
        isWandering = toggle;
    }

    void GetNewDest()
    {
        destRot = this.transform.rotation;
        destRot *= Quaternion.Euler(0, Random.Range(-90, 90), 0);

    }

    private void OnTriggerStay(Collider other)
    {
        if (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Hit")
        {
            if (other.tag == "PlayerWeapon")
            {
                GameObject enemy = other.transform.parent.gameObject;
                if (enemy.GetComponent<PlayerAttackScript>().canAttack)
                {
                    enemyRBody.AddForce(enemy.transform.forward * 500);
                    //SetMoving(false);
                    anim.SetBool("Hit", true);
                    enemyHealth.ChangeHealth(-10);
                    enemy.GetComponent<PlayerAttackScript>().canAttack = false;
                }
            }
        }




    }

    public void resetHit()
    {
        Debug.Log("Reset Hit");
        anim.SetBool("Hit", false);
        //SetMoving(true);
    }

}
