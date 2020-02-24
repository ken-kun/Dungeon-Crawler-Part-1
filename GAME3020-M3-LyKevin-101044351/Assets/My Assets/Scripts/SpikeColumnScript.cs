using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeColumnScript : MonoBehaviour
{
    enum columnDirection { LeftToRight, RightToLeft, UpToDown, DownToUp }

    [SerializeField] columnDirection Direction;
    [SerializeField] GameObject Column;
    [SerializeField] float speed = 5;
    [SerializeField] float minValue;
    [SerializeField] bool isMoving = false;
    


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isMoving = true;
        }
    }


    void MoveColumn()
    {
        switch (Direction)
        {
            case columnDirection.LeftToRight:
                if (isMoving)
                {
                    if (Column.transform.position.x > minValue)
                    {
                        Column.transform.Translate(-0.1f *speed , 0, 0);
                    }
                }
                break;

            case columnDirection.RightToLeft:
                if (isMoving)
                {
                    if (Column.transform.position.x < minValue)
                        Column.transform.Translate(0.1f * speed, 0, 0);
                }
                break;
            case columnDirection.UpToDown:
                if (isMoving)
                {
                    if (Column.transform.position.y > minValue)
                    {
                        Column.transform.Translate(0, -0.1f, 0);
                    }
                }
                break;
        }
            
     }

    private void Update()
    {
        MoveColumn();
    }
}
