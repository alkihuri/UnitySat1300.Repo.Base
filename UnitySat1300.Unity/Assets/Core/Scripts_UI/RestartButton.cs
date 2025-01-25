using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void RestarLevel()
    {
        SceneManager.LoadScene(0); // Перезагружаем игру
    }
}
