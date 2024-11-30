using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame() //загрузать сцену с следкйщим индексом (индексом 1 короче)
    { 
        SceneManager.LoadScene("1"); 
    }
    public void ExitGame() //выход с игры
    {
        Debug.Log("Exit game");
        Application.Quit();
    }

}