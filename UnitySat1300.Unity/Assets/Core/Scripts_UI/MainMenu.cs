using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame() //��������� ����� � ��������� �������� (�������� 1 ������)
    { 
        SceneManager.LoadScene("1"); 
    }
    public void ExitGame() //����� � ����
    {
        Debug.Log("Exit game");
        Application.Quit();
    }

}