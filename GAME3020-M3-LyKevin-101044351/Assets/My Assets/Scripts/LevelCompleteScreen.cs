using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteScreen : MonoBehaviour
{

    [SerializeField] GameObject winScreen;
    

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "Player")
        {
            winScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    
}
