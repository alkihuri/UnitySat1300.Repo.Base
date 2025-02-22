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

    public LayerMask groundLayer;


    public Transform forwardWheel;
    public Transform backWheel;

    private Rigidbody2D rb;

    [SerializeField] private InputHandler inputHandler;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    float timer = 2;
    void Update()
    {
        //// Проверяем, находится ли машина на земле 
        //currentZangle = transform.eulerAngles.z;
        //if (currentZangle > 180) // Если угол больше 180, то приводим его к отрицательному значению
        //{
        //    currentZangle = currentZangle - 360; // Приводим угол к отрицательному значению
        //}

        ////isGrounded = Mathf.Abs(currentZangle) < Mathf.Abs(zAngleLimit); // Если угол машины меньше 30 градусов, то машина на земле

        Vector2 raycastDirection = new Vector2(0, -1);
        Vector2 relativeDirection = transform.TransformDirection(raycastDirection);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, relativeDirection, 1.5f, groundLayer);

        if (hit.collider != null)
        {
            isGrounded = hit.distance < 1.5f; // Если дистанция до земли меньше 1.5, то машина на земле

        }
        else
        {
            isGrounded = false;
        }

        if (isGrounded == false) // проверяем перевернулась ли машиша 
        {
            timer = timer - Time.deltaTime; // вычитаем из значения таймера время обработки кадра ¬16мс
            if (timer < 0) // если таймер закончился
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


        float moveInput;
        if (inputHandler != null) // Если InputHandler не равен null, то используем его
        {
            moveInput = inputHandler.Horizontal; // Получаем значение Horizontal из InputHandler
        }
        else
        {
            moveInput = Input.GetAxis("Horizontal"); // иначе получаем значение Horizontal из Input
            inputHandler = FindObjectOfType<InputHandler>(); // ищем InputHandler в сцене   
        }

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
        float speed = rb.velocity.magnitude;
        // Вращаем переднее колесо
        if (rb.velocity.x > 1) // Если машина движется вправо
        {
            forwardWheel.localEulerAngles   -= new Vector3(0, 0, 1 * speed);
            backWheel.localEulerAngles      -= new Vector3(0, 0, 1 * speed);
        }
        else if (rb.velocity.x < 1) // Если машина движется влево   
        {
            forwardWheel.localEulerAngles   += new Vector3(0, 0, 1 * speed);
            backWheel.localEulerAngles      += new Vector3(0, 0, 1 * speed);
        }

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
