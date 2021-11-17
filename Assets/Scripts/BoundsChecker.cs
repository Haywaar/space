using UnityEngine;

public class BoundsChecker : MonoBehaviour
{
    [Header("Set in inspector")] 
    public float radius = 1f;

    public bool keepOnScreen = true;

    [Header("Set dynamically")] 
    public float cameraWidth, cameraHeight;

    public bool isOnScreen = true;

    [HideInInspector] public bool offRight, offLeft, offUp, offDown; // Пересечение границ экрана
    private void Awake()
    {
        cameraHeight = Camera.main.orthographicSize; // Вернуть число из поля size
        cameraWidth = cameraHeight * Camera.main.aspect; // Отношение ширины к высоте поля зрения камеры
    }

    private void LateUpdate()
    {
        isOnScreen = true;
        Vector3 position = transform.position;
        if (position.x > cameraWidth - radius)
        {
            position.x = cameraWidth - radius;
            isOnScreen = false;
            offRight = true;
        }
        if (position.x < -cameraWidth + radius)
        {
            position.x = -cameraWidth + radius;
            isOnScreen = false;
            offLeft = true;
        }
        if (position.y > cameraHeight - radius)
        {
            position.y = cameraHeight - radius;
            isOnScreen = false;
            offUp = true;
        }
        if (position.y < -cameraHeight + radius)
        {
            position.y = -cameraHeight + radius;
            isOnScreen = false;
            offDown = true;
        }

        isOnScreen = !(offUp || offDown || offLeft || offRight);
        if (keepOnScreen && !isOnScreen)
        {
            transform.position = position;
            isOnScreen = true;
            offDown = offLeft = offRight = offUp = false;
        }
    }

    private void OnDrawGizmos() // Нарисуем границы игровой области
    {
        if(!Application.isPlaying) return;
        Vector3 boundSize = new Vector3(cameraWidth * 2, cameraHeight * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize);
    }
}
