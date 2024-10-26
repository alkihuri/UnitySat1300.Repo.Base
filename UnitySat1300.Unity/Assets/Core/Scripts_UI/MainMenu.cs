using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame() //��������� ����� � ��������� �������� (�������� 1 ������)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ExitGame() //����� � ����
    {
        Debug.Log("exit game");
        Application.Quit();
    }

}