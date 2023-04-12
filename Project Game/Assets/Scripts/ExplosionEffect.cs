using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 0.8f);
    }
}
