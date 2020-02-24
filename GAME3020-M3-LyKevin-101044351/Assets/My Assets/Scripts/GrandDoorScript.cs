using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandDoorScript : MonoBehaviour
{
    [SerializeField] SwitchScript switchScript1;
    [SerializeField] SwitchScript switchScript2;
    [SerializeField] SwitchScript switchScript3;

    bool isOpen = false;

    public Animation playGate;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(switchScript1.unlock && switchScript2.unlock && switchScript3.unlock)
        {
            if(!isOpen)
            {
                Invoke("OpenGate",3);
            }
        }
    }


    public void OpenGate()
    {
        isOpen = true;
        playGate.Play();
        
    }
}
