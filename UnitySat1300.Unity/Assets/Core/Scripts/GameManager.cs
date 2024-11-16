using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerCar;                        // Ссылка на машину игрока
    public Vector3 startPostion;                        // Стартовая позиция игрока
    public Vector3 startRotation;                       // Стартовое вращение игрока    
    private void Start()
    {
        startPostion = playerCar.transform.position;    // Запоминаем стартовую позицию игрока
        startRotation = playerCar.transform.eulerAngles; // Запоминаем стартовое вращение игрока
    }
    private void OnTriggerExit2D(Collider2D collision)  // Если игрок вышел за пределы дороги
    {
        playerCar.transform.position = startPostion;                        // Возвращаем игрока на стартовую позицию
        playerCar.transform.eulerAngles = startRotation;                    // Возвращаем игрока на стартовое вращение
        Rigidbody2D rigidbody2D = playerCar.GetComponent<Rigidbody2D>();    // Получаем Rigidbody2D игрока
        rigidbody2D.velocity = Vector2.zero;                                // Обнуляем скорость игрока
        rigidbody2D.angularVelocity = 0;                                    // Обнуляем угловую скорость игрока
        Debug.Log("Game Over");                                              // Выводим сообщение в консоль
    }
}
