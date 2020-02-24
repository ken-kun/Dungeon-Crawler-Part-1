using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	public Transform healthBar;
	public Slider healthFill;

	public float currentHealth;
	public float maxHealth;
	public static float enemyHealth = 100;

	public float healthBarYOffset = 6;
	//public static int turretNumber = 10;

	public bool isAlive = true;
	//[SerializeField] GameObject explosionPrefab;


	
	// Update is called once per frame
	void Update () {
		PositionHealthBar ();
	}

	public void ChangeHealth(int amount)
	{
		
		currentHealth += amount;
		currentHealth = Mathf.Clamp (currentHealth, 0, maxHealth);

		healthFill.value = currentHealth / maxHealth;

		if (currentHealth <= 0 && isAlive) {
			isAlive = false;
			//turretNumber--;
			//EnemyNumber (turretNumber);


			Destroy (gameObject);
			//GameObject explosionInst = Instantiate (explosionPrefab, transform.position, transform.rotation) as GameObject;
		}
	}

	private void PositionHealthBar() 
	{
		Vector3 currentPos = transform.position;

		healthBar.position = new Vector3 (currentPos.x, currentPos.y + healthBarYOffset, currentPos.z);

		//healthBar.LookAt (Camera.main.transform);
	}
}
