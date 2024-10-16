using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SimpleCarController : MonoBehaviour
{
    public float motorForce = 1500f; // Сила, с которой машина будет двигаться
    public float rotationSpeed = 15f; // Скорость вращения машины при движении
    public float maxSpeed = 20f; // Максимальная скорость машины

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal"); // Ввод с клавиш "A/D" или "стрелки влево/вправо"
        HandleMovement(moveInput);
        HandleRotation(moveInput);
    }

    // Движение машины вперёд и назад
    void HandleMovement(float moveInput)
    {
        if (Mathf.Abs(rb.velocity.x) < maxSpeed) // Ограничиваем максимальную скорость
        {
            rb.AddForce(new Vector2(moveInput * motorForce * Time.deltaTime, 0));
        }
    }

    // Вращение машины (наклон вперёд и назад)
    void HandleRotation(float moveInput)
    {
        if (moveInput != 0)
        {
            rb.AddTorque(-moveInput * rotationSpeed * Time.deltaTime); // Поворачиваем машину
        }
    }
}
