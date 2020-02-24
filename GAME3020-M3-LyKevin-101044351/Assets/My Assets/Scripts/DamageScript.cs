using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour {

    [SerializeField] float damagePoints;

	private void OnTriggerEnter(Collider other)
	{
		PlayerHealth health;
		if (health = other.GetComponent<PlayerHealth> ()) {
			health.ChangeHealth (damagePoints);
		}
	}
}
