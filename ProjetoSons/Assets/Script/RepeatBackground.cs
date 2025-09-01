using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Vari�vel para armazenar a posi��o inicial do objeto
    private Vector3 startPosition;

    // Vari�vel para armazenar a largura necess�ria para o reposicionamento
    private float repeatWidth;

    // O m�todo Start � chamado uma vez antes da primeira execu��o do m�todo Update.
    void Start()
    {
        // Armazena a posi��o inicial do objeto na vari�vel startPosition
        startPosition = transform.position;

        // Calcula a largura de repeti��o utilizando o tamanho do BoxCollider do objeto
        // Dividimos por 2 para alinhar corretamente a repeti��o com a metade do tamanho
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // O m�todo Update � chamado uma vez por frame.
    void Update()
    {
        // Verifica se a posi��o x do objeto est� menor do que (posi��o inicial - largura de repeti��o)
        if (transform.position.x < startPosition.x - repeatWidth)
        {
            // Se a condi��o for verdadeira, redefine a posi��o do objeto para sua posi��o inicial
            transform.position = startPosition;
        }
    }
}
