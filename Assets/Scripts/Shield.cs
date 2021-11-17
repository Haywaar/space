using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [Header("Set in inspector")] 
    public float rotationPerSecond = 0.3f;

    [Header("Set dynamically")] 
    public int levelShown = 0;

    private Material material;
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        int currentLevel = Mathf.FloorToInt(Hero.solo.shieldLevel);
        if (levelShown != currentLevel)
        {
            levelShown = currentLevel;
            //смещение в текстуре
           // material.mainTextureOffset = new Vector2(0.2f * levelShown, 0);
        }

        float rZ = (rotationPerSecond * Time.time * 360) % 360f; // поворот поля
        transform.rotation = Quaternion.Euler(0,0,rZ);
    }
}
