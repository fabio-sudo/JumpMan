using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Variável para armazenar a posição inicial do objeto
    private Vector3 startPosition;

    // Variável para armazenar a largura necessária para o reposicionamento
    private float repeatWidth;

    // O método Start é chamado uma vez antes da primeira execução do método Update.
    void Start()
    {
        // Armazena a posição inicial do objeto na variável startPosition
        startPosition = transform.position;

        // Calcula a largura de repetição utilizando o tamanho do BoxCollider do objeto
        // Dividimos por 2 para alinhar corretamente a repetição com a metade do tamanho
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // O método Update é chamado uma vez por frame.
    void Update()
    {
        // Verifica se a posição x do objeto está menor do que (posição inicial - largura de repetição)
        if (transform.position.x < startPosition.x - repeatWidth)
        {
            // Se a condição for verdadeira, redefine a posição do objeto para sua posição inicial
            transform.position = startPosition;
        }
    }
}
