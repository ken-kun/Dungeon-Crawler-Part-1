using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public Transform healthBar;
	public Slider healthFill;

	public float currentHealth;
	public float maxHealth;
	public static float playerHealth = 100;

	public float healthBarYOffset = 6;

	public bool isAlive = true;
    public GameObject gameOver;

	//[SerializeField] string levelToLoad;

    void Start()
    {

    }

	
	// Update is called once per frame
	void Update () {
		//PositionHealthBar ();
	}


	public void ChangeHealth(float amount)
	{
		Debug.Log ("Health");
		currentHealth += amount;
		currentHealth = Mathf.Clamp (currentHealth, 0, maxHealth);

		healthFill.value = currentHealth / maxHealth;

		if (currentHealth <= 0 && isAlive) {
			isAlive = false;
            GetComponent<Animator>().SetTrigger("Dead");
			//transform.root.GetComponent<PlayerController> ().enabled = false;
			Invoke ("GameOver",3.0f);




		}

	}

	//private void PositionHealthBar() 
	//{
		//Vector3 currentPos = transform.position;

		//healthBar.position = new Vector3 (currentPos.x, currentPos.y + healthBarYOffset, currentPos.z);


	//}

	public void GameOver()
	{
        gameOver.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0.0f;
        

	}

}
