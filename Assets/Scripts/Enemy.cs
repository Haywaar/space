using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Set in inspector")] 
    public float speed = 60f, fireRate = 0.4f, health = 10, score = 100;

    public float projectileSpeed = 30f;
    public GameObject projectilePrefab;
    private BoundsChecker boundsChecker;
    private float _nextFire;
    private void Awake()
    {
        boundsChecker = GetComponent<BoundsChecker>();
    }

    public Vector3 position
    {
        get
        {
            return this.transform.position;
        }
        set
        {
            this.transform.position = value;
        }
    }

    public virtual void Move() // Перемещение
    {
        Vector3 tempPosition = position;
        tempPosition.y -= speed * Time.deltaTime;
        position = tempPosition;
    }

    void Update()
    {
        Move();
        if (boundsChecker != null && boundsChecker.offDown)
        {
            Destroy(gameObject); // Теперь не дублируется функционал
        }
        
        if (_nextFire > 0)
        {
            _nextFire -= Time.deltaTime;
        }
        else
        {
            Fire();
            _nextFire = fireRate;
        }
    }

    private void Fire()
    {
        GameObject projectileGameObject = Instantiate<GameObject>(projectilePrefab);
        projectileGameObject.transform.position = transform.position;
        Rigidbody rigidbody = projectileGameObject.GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.down * projectileSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.tag == "ProjectileHero")
        {
            Destroy(other);
            Main.solo.EnemyDestroyed(score);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("hit non enemy");
        }
    }
}
