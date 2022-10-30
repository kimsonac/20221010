using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotate : MonoBehaviour
{
    private float speed = 100f;
    private Vector3 vec = new Vector3(0, 0, 0);

    
    // Update is called once per frame
    private void Update()
    {
        vec.y = speed * Time.deltaTime;
        transform.Rotate(vec);
    }
}
