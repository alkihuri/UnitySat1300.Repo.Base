using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcitveButton : MonoBehaviour
{
    public GameObject Restartbutton;
    public bool isOpened;

    private void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isOpened = !isOpened;

            Restartbutton.SetActive(isOpened);

        }
    }
}
