using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishController : MonoBehaviour
{
    /// ПОДСКАЗКА: создание таймера
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<SimpleCarController>())
        {
            // ПОДСКАЗКА: Старт таймера
            // достигнут финиш
            Debug.Log("Finish " + SceneManager.GetActiveScene().name + " level!");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<SimpleCarController>())
        {
            // ПОДСКАЗКА: Обновление таймера каждый кадр (Time.deltaTime)
            // если машина на финише больше 2 секунд, то переход на следующий уровень
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<SimpleCarController>())
        {
            // ПОДСКАЗКА: Обнуление таймера
        }
    }
}
