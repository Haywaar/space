using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Set in inspector")] 
    public float speed = 10f, fireRate = 0.4f, health = 10, score = 100;

    private BoundsChecker boundsChecker;

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
    }
}
