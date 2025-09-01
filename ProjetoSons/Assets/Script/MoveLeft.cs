using System;
using UnityEngine;
using UnityEngine.Rendering;

public class MoveLeft : MonoBehaviour
{
    // Variável para definir a velocidade de movimento do objeto
    private float speed = 20;

    // Limite à esquerda, após o qual o objeto será destruído
    private float leftBound = -15;

    // Referência ao script PlayerController para verificar o estado do jogo
    private PlayerController controller;

    // O método Start é chamado uma vez antes da primeira execução do método Update.
    void Start()
    {
        // Obtém o componente PlayerController anexado ao objeto chamado "Player"
        // Isso permite acessar variáveis e métodos do PlayerController
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // O método Update é chamado uma vez por frame.
    void Update()
    {
        // Verifica se o jogo não está em estado de "game over"
        if (controller.gameOver == false)
        {
            // Move o objeto para a esquerda (eixo x negativo) com base na velocidade e no tempo entre frames
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        // Verifica se o objeto passou do limite esquerdo do cenário e tem a tag "Obstacle"
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            // Destroi o objeto para liberar memória e evitar poluir o jogo com objetos fora do campo de visão
            Destroy(gameObject);
        }
    }
}
