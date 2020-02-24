using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public Transform movingPlatform;
    public Transform position1;
    public Transform position2;
    public Transform position3;
    public Transform position4;
    public Transform position5;

    public Vector3 newPosition;
    public string currentState;
    public float smooth;
    public float distance;

    bool isMoving = false;

    void Start()
    {
        ChangeTarget();
    }

    void Update()
    {
        if (Vector3.Distance(movingPlatform.position, newPosition) < distance)
        {
            ChangeTarget();
        }
    }
    void FixedUpdate()
    {
        if (isMoving)
        {
            if (Vector3.Distance(movingPlatform.position, newPosition) < 3)
            {
                movingPlatform.position = Vector3.Lerp(movingPlatform.position, newPosition, smooth * 4 * Time.deltaTime);
            }
            else
            {
                movingPlatform.position = Vector3.Lerp(movingPlatform.position, newPosition, smooth * Time.deltaTime);
            }
        }
           


        
    }

    void ChangeTarget()
    {
        if(currentState == "")
        {
            currentState = "Moving to Position 2";
            newPosition = position2.position;
        }
        else if(currentState == "Moving to Position 2")
        {
            currentState = "Moving to Position 3";
            newPosition = position3.position;
        }
        else if (currentState == "Moving to Position 3")
        {
            currentState = "Moving to Position 4";
            newPosition = position4.position;
        }
        else if (currentState == "Moving to Position 4")
        {
            currentState = "Moving to Position 5";
            newPosition = position5.position;
        }
        else if (currentState == "Moving to Position 5")
        {
            currentState = "";
            newPosition = position1.position;
        }
        //Invoke("ChangeTarget",resetTime);

        
    }

    void ChangeState()
    {
        isMoving = !isMoving;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("ChangeState", 1.0f);
            collision.transform.parent = gameObject.transform;
            collision.gameObject.GetComponent<KnightPlayerScript>().movingPlatform = gameObject;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Invoke("ChangeState", 1.0f);
            collision.transform.parent = null;
        }
    }


}
