using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTiler : MonoBehaviour
{
    public Material material;
    public float speedCoef=2f;
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        float offset = material.mainTextureOffset.y;
        material.mainTextureOffset = new Vector2(0, offset+Time.deltaTime*speedCoef);
    }
}
