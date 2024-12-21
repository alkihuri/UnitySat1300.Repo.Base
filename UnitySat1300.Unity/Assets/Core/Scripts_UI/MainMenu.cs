using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Playlevel1() //загрузать сцену с следкйщим индексом (индексом 1 короче)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Playlevel2()
    {
        SceneManager.LoadScene ("2");
    }
    public void Playlevel3()
    {
        SceneManager.LoadScene("3");
    }
    public void ExitGame() //выход с игры
    {
        Debug.Log("exit game");
        Application.Quit();
    }

}