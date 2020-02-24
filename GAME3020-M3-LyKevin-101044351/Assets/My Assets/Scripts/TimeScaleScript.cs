using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleScript : MonoBehaviour {

    public GameObject startScreen;



    private void Start()
    {
        Time.timeScale = 0.0f;
    }
    public void TimeScale()
    {
        Time.timeScale = 1.0f;
        startScreen.SetActive(false);

    }
}
