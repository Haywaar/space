using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private BoundsChecker boundsChecker;

    private void Awake()
    {
        boundsChecker = GetComponent<BoundsChecker>();
    }
    
    void Update()
    {
        if (boundsChecker.offUp)
        {
            Destroy(gameObject);
        }
    }
}
