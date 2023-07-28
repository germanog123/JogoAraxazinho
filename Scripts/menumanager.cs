using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menumanager : MonoBehaviour
{
    public void jogar()
    {
        SceneManager.LoadScene("cena_1");
    }

    public void sair()
    {
        Application.Quit();
    }
}
