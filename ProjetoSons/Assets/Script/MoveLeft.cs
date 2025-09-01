using System;
using UnityEngine;
using UnityEngine.Rendering;

public class MoveLeft : MonoBehaviour
{
    // Vari�vel para definir a velocidade de movimento do objeto
    private float speed = 20;

    // Limite � esquerda, ap�s o qual o objeto ser� destru�do
    private float leftBound = -15;

    // Refer�ncia ao script PlayerController para verificar o estado do jogo
    private PlayerController controller;

    // O m�todo Start � chamado uma vez antes da primeira execu��o do m�todo Update.
    void Start()
    {
        // Obt�m o componente PlayerController anexado ao objeto chamado "Player"
        // Isso permite acessar vari�veis e m�todos do PlayerController
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // O m�todo Update � chamado uma vez por frame.
    void Update()
    {
        // Verifica se o jogo n�o est� em estado de "game over"
        if (controller.gameOver == false)
        {
            // Move o objeto para a esquerda (eixo x negativo) com base na velocidade e no tempo entre frames
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        // Verifica se o objeto passou do limite esquerdo do cen�rio e tem a tag "Obstacle"
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            // Destroi o objeto para liberar mem�ria e evitar poluir o jogo com objetos fora do campo de vis�o
            Destroy(gameObject);
        }
    }
}
