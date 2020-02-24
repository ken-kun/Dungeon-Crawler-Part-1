using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneScript : MonoBehaviour
{

    [SerializeField] GameObject gameOverScreen;
    // Start is called before the first frame update

    void Update()
    {

    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
