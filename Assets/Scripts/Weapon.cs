using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    standard,
    blaster,
    spreadFire
}

[System.Serializable]
public class WeaponConcept
{
    public WeaponType type = WeaponType.standard;
    public string letter; // буква бонуса
    public  Color color = Color.white, projectileColor = Color.white;
    public GameObject projectilePrefab;
    public float damage = 0, delayBetweenShots = 0, velocity = 40;
}

public class Weapon : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
