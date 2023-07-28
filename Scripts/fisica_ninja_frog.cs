using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class fisica_ninja_frog : MonoBehaviour
{
    public float velocidade = 5f;
    public float forcaDoPulo = 5f;
    public int pulosMaximos = 2; // Limite máximo de pulos
    public Text scoreTxt;
    private int score;
    public GameObject audioMoeda;

    private bool isSpeedRunning = false;
    private float speedRunDuration = 10f;
    private float speedRunMultiplier = 3f;
    private float normalSpeed;

    private int pulosRealizados; // Contador de pulos realizados
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        score = 0;
        normalSpeed = velocidade;
        pulosRealizados = 0; // Inicializa o contador de pulos realizados
    }

    private void Update()
    {
        float movimentoVertical = Input.GetAxis("Vertical");

        scoreTxt.text = score.ToString();

        rb.velocity = new Vector2(velocidade, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && pulosRealizados < pulosMaximos)
        {
            if (rb.velocity.y == 0f)
            {
                rb.AddForce(new Vector2(0f, forcaDoPulo), ForceMode2D.Impulse);
                pulosRealizados = 1; // Incrementa o contador de pulos realizados
            }
            else if (rb.velocity.y > 0f && rb.velocity.y < forcaDoPulo)
            {
                rb.AddForce(new Vector2(0f, forcaDoPulo - rb.velocity.y), ForceMode2D.Impulse);
                pulosRealizados = 2; // Define o contador de pulos realizados como 2 (máximo)
            }
        }

        if (rb.velocity.y == 0f)
        {
            pulosRealizados = 0; // Zera o contador de pulos realizados quando estiver no chão
        }

        if (rb.velocity.x <= 0f)
        {
            rb.velocity = new Vector2(velocidade, rb.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("coletavel"))
        {
            score = score + 1;
            Destroy(other.gameObject, 0.1f);
            GameObject audioInstance = Instantiate(audioMoeda, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
        else if (other.CompareTag("arbusto"))
        {
            //acionar o gameover
            Game_Over();
        }
        else if (other.CompareTag("checkpoint1"))
        {
            gameObject.SetActive(false); // Desativa o jogador
            SceneManager.LoadScene("cena_2"); // Muda para a segunda cena
        }
        else if (other.CompareTag("checkpoint2"))
        {
            gameObject.SetActive(false); // Desativa o jogador
            SceneManager.LoadScene("cena_3"); // Muda para a terceira cena
        }
        else if (other.CompareTag("speedrun"))
        {
            StartCoroutine(ActivateSpeedRun());
            Destroy(other.gameObject);
        }
    }

    private IEnumerator ActivateSpeedRun()
    {
        if (!isSpeedRunning)
        {
            isSpeedRunning = true;
            velocidade *= speedRunMultiplier;

            yield return new WaitForSeconds(speedRunDuration);

            velocidade = normalSpeed;
            isSpeedRunning = false;
        }
    }

    private void Game_Over()
    {
        SceneManager.LoadScene("gameOver");
    }
}
