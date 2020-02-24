using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject player;


    private void OnTriggerEnter(Collider other)
    {
        player.transform.position = teleportTarget.transform.position;
        this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
        teleportTarget.GetComponent<CapsuleCollider>().enabled = false;
    }
}
