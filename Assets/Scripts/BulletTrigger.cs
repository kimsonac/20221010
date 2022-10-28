using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    private void OnParticleTrigger()
    {
        Destroy(transform.parent);
    }
}
