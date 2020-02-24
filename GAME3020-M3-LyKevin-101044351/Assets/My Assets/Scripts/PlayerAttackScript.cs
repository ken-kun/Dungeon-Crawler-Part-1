using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour
{
    public bool canAttack;

    
   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
    void Attack(int state)
    {
        if(state == 0)
        {
            canAttack = true;
            Debug.Log(canAttack);
            

        }
        else
        {
            canAttack = false;
            Debug.Log(canAttack);
        }
    }
}
