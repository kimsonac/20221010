using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.tag);
        if (collision.transform.CompareTag("Terrain"))
        {
            GameManager.gameManager.RespawnPlayer();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") || other.CompareTag("Boundary"))
        {
            GameManager.gameManager.RespawnPlayer();
        }

        if (other.CompareTag("Goal"))
        {
            GameManager.gameManager.GameEnd();
        }

        if (other.CompareTag("Item"))
        {
            GameManager.gameManager.PlayerBoost();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Ob1"))
        {
            GameManager.gameManager.StartInterrubt(1);
        }

        if (other.CompareTag("Ob2"))
        {
            GameManager.gameManager.StartInterrubt(2);
        }
    }

}
