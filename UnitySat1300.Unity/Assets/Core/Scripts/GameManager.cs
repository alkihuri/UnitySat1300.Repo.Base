using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerCar;                        // Ссылка на машину игрока
    public Vector3 startPostion;                        // Стартовая позиция игрока
    private void Start()
    {
        startPostion = playerCar.transform.position;    // Запоминаем стартовую позицию игрока
    }
    private void OnTriggerExit2D(Collider2D collision)  // Если игрок вышел за пределы дороги
    {
        playerCar.transform.position = startPostion;    // Возвращаем игрока на стартовую позицию
        Debug.Log("Game Over");                         // Выводим сообщение в консоль
    }
}
