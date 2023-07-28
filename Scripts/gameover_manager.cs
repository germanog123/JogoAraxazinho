using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover_manager : MonoBehaviour
{
    // Método para tentar novamente
    public void tentar_novamente()
    {
        SceneManager.LoadScene("cena_1");
    }

    // Método para sair do jogo
    public void sair()
    {
        Application.Quit();
    }
}

