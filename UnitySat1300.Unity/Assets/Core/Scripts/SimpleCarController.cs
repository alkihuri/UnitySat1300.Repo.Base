using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleCarController : MonoBehaviour
{
    public float speed;
    public float motorForce = 1500f; // Сила, с которой машина будет двигаться
    public float rotationSpeed = 15f; // Скорость вращения машины при движении
    public float maxSpeed = 20f; // Максимальная скорость машины
    public bool isGrounded;
    public float zAngleLimit = 30;
    public float currentZangle = 0;



    public Transform forwardWheel;
    public Transform backWheel;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    float timer = 2;
    void Update()
    {
        // Проверяем, находится ли машина на земле 
        currentZangle = transform.eulerAngles.z;
        if (currentZangle > 180) // Если угол больше 180, то приводим его к отрицательному значению
        {
            currentZangle = currentZangle - 360; // Приводим угол к отрицательному значению
        }
        isGrounded = Mathf.Abs(currentZangle) < Mathf.Abs(zAngleLimit); // Если угол машины меньше 30 градусов, то машина на земле

        if (isGrounded == false) // проверяем перевернулась ли машиша 
        {
            timer = timer - Time.deltaTime; // вычитаем из значения таймера время обработки кадра ¬16мс
            if(timer < 0) // если таймер закончился
            { 
                string currentScene = SceneManager.GetActiveScene().name; // перегружаем сцену
                SceneManager.LoadScene(currentScene);
                timer = 2; // обновляем значение таймера
            }
        }
        else // но если машина не "пролежала" на крыше 2 секунды - то  обнуляем счетчик
        {
            timer = 2;
        }


        float moveInput = Input.GetAxis("Horizontal"); // Ввод с клавиш "A/D" или "стрелки влево/вправо"
        if (isGrounded)
        {
            HandleMovement(moveInput);
        }
        HandleRotation(moveInput);

        speed = rb.velocity.magnitude;
        if (speed > 0)
        {
            RotateWheel();
        }




        #region Debug
        // рисуем линию вектора скорости
        Vector3 velocityDirection = new Vector2(transform.position.x, transform.position.y) + rb.velocity;
        //Debug.Log($"{rb.velocity} = {rb.velocity.magnitude}");
        Debug.DrawLine(transform.position, velocityDirection, Color.red);
        #endregion
    }

    private void RotateWheel()
    {
        // Вращаем переднее колесо
        forwardWheel.eulerAngles = new Vector3(0, 0, -rb.velocity.x);

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
