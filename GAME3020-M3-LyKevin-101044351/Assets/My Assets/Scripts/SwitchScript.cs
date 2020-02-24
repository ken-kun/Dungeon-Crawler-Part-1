using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    [SerializeField] GameObject lockedDoor;
    public bool unlock = false;
    private Animation playLock;
    



    // Start is called before the first frame update
    void Start()
    {
        playLock = lockedDoor.GetComponent<Animation>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            this.GetComponent<Renderer>().material.color = Color.red;
            unlock = true;
            playLock.Play();
        }
    }
}
