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
            //Debug.Log(collision.transform.tag);
            Invoke("SetPlayer", 1f);
            transform.parent.gameObject.SetActive(false);
        }
    }

    private void SetPlayer()
    {
        transform.parent.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {

        }

        if (other.CompareTag("Goal"))
        {

        }
    }
}
