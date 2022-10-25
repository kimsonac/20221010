using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCam : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    private Vector3 pos = new Vector3(0, 200f, 0);


    void Update()
    {
        pos.x = player.position.x;
        pos.z = player.position.z;
        
        transform.position = pos;
        transform.localRotation = Quaternion.Euler(90, player.eulerAngles.y, 0);
    }
}
