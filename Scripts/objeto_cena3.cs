using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class objeto_cena3 : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        // Adiciona um ouvinte de evento para o evento OnEnd do VideoPlayer
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Carrega a próxima cena
        SceneManager.LoadScene("cena_4");
    }
}