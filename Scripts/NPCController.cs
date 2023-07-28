using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{
    public fisica_ninja_frog playerScript;
    private Rigidbody2D rb;
    private float multiplicadorVelocidadeNPC = 5f;
    private float frequenciaVelocidade = 0.25f;
    private float amplitudeVelocidade = 15f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        float velocidadeNPC = playerScript.velocidade * multiplicadorVelocidadeNPC;

        // Variar a velocidade usando uma função cosseno
        float variacaoVelocidade = amplitudeVelocidade * Mathf.Sin(amplitudeVelocidade * (Mathf.Cos(Mathf.Sin(Time.time * frequenciaVelocidade))));
        velocidadeNPC += variacaoVelocidade;

        // Mover o NPC na direção do jogador com velocidade constante
        Vector2 direcao = (playerScript.transform.position - transform.position).normalized;
        rb.velocity = new Vector2(direcao.x * 0.25f * velocidadeNPC + 6, rb.velocity.y);
    }
}