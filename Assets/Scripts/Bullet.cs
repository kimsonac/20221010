using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const string ROCK_1 = "Rock_1";
    private const string ROCK_2 = "Rock_2";

    [SerializeField] public GameObject shot_VFX;
    private Rigidbody rd;
    private float speed = 1000f;

    private void Awake()
    {
        rd = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        rd.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Terrain") 
            || other.CompareTag("Ob1") 
            || other.CompareTag("Ob2")
            || other.CompareTag("Item")
            || other.CompareTag("Player"))
        {
            return;
        }

        Destroy(Instantiate(shot_VFX, other.transform.position, Quaternion.identity), 1f);

        if (other.CompareTag("ItemOb1"))
        {
            GameManager.gameManager.SetItem(1);
        }

        if (other.CompareTag("ItemOb2"))
        {
            GameManager.gameManager.SetItem(2);
        }

        StartCoroutine(_DestroyObjects(other.gameObject));

    }

    private IEnumerator _DestroyObjects(GameObject other)
    {
        yield return new WaitForEndOfFrame();

        Destroy(gameObject);
        Destroy(other);
    }

}
