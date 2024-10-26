using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Делаем переменную публичной, чтобы она отображалась в инспекторе
    public Transform target; // Машина, за которой будет следовать камера 
    public Vector3 offset = new Vector3(0, 2, -10); // Смещение камеры
    public float smoothSpeed = 0.125f; // Скорость сглаживания

    void LateUpdate()
    {
        if (target != null)
        {
            // Позиция камеры относительно машины + смещение
            Vector3 desiredPosition = target.position + offset;

            // Плавное перемещение камеры
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Обновляем позицию камеры
            transform.position = smoothedPosition;
        }
    }
}
