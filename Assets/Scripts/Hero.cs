using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    static public Hero solo;
    [Header("Set in inspector")] 
    public float speed = 30f, rollMult = -45, pitchMult = 30;

    [Header("Set dynamically")] public float shieldLevel = 1;

    void Awake()
    {
        if (solo == null)
        {
            solo = this;
        }
        else
        {
            Debug.LogError("Hero.Awake()"); // Защита от двойного экземпляра героя
        }
    }

    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal"); // Извлечь инфу из класса Input
        float yAxis = Input.GetAxis("Vertical");

        Vector3 position = transform.position;
        position.x += xAxis * speed * Time.deltaTime;
        position.y += yAxis * speed * Time.deltaTime;
        transform.position = position;
        
        // Поворот в бок при управлении
        transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * rollMult, 0); 
    }


}
