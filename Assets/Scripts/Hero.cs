using UnityEngine;

public class Hero : MonoBehaviour
{
    static public Hero solo;
    [Header("Set in inspector")] 
    public float speed = 30f, rollMult = -45, pitchMult = 30;

    public float hp = 3;

    public GameObject projectilePrefab;
    public float projectileSpeed = 60;
    public float gameRestartDelay = 1;

    [Header("Set dynamically")] public float shieldLevel = 1;
    private GameObject lastTrigger;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject projectileGameObject = Instantiate<GameObject>(projectilePrefab);
        projectileGameObject.transform.position = transform.position;
        Rigidbody rigidbody = projectileGameObject.GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.up * projectileSpeed;
    }

    private void OnTriggerEnter(Collider collider)
    {
        Transform rootHere = collider.gameObject.transform.root;
        GameObject go = rootHere.gameObject;
        Debug.Log("Trigger with " + go.name);

        if (go == lastTrigger)
        {
            // Гарантия невозможности повторного столкновения
            return;
        }
        lastTrigger = go; // Обновление перед след вызовом

        if (go.tag == "Enemy")
        {
            hp = hp - 1;
            Destroy(go);
        }
        else
        {
            Debug.Log("Triggered just because");
        }

        if (hp == 0)
        {
            Destroy(gameObject);
            Main.solo.DelayedRestart(gameRestartDelay);
        }
    }
}
