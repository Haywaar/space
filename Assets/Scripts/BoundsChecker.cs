using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsChecker : MonoBehaviour
{
    [Header("Set in inspector")] 
    public float radius = 1f;

    public bool keepOnScreen = true;

    [Header("Set dynamically")] 
    public float cameraWidth, cameraHeight;

    public bool isOnScreen = true;
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
        }
        if (position.x < -cameraWidth + radius)
        {
            position.x = -cameraWidth + radius;
            isOnScreen = false;
        }
        if (position.y > cameraHeight - radius)
        {
            position.y = cameraHeight - radius;
            isOnScreen = false;
        }
        if (position.y < -cameraHeight + radius)
        {
            position.y = -cameraHeight + radius;
            isOnScreen = false;
        }

        if (keepOnScreen && !isOnScreen)
        {
            transform.position = position;
            isOnScreen = true;
        }
    }

    private void OnDrawGizmos() // Нарисуем границы игровой области
    {
        if(!Application.isPlaying) return;
        Vector3 boundSize = new Vector3(cameraWidth * 2, cameraHeight * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize);
    }
}
