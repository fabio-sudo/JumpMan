using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Tempo de atraso inicial antes de começar a gerar obstáculos
    private float startDelay = 2;

    // Tempo entre cada geração de obstáculos
    private float repeatRate = 2;

    // Referência ao script PlayerController para verificar o estado do jogo
    private PlayerController playerController;

    // Prefab do obstáculo que será gerado
    public GameObject obstaclePrefab;

    // Posição onde os obstáculos serão gerados
    private Vector3 spawnPosition = new Vector3(12, 0, 0);

    // O método Start é chamado uma vez antes da primeira execução do método Update
    void Start()
    {
        // Configura uma chamada repetitiva ao método SpawnObstacle
        // Começa após "startDelay" segundos e repete a cada "repeatRate" segundos
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);

        // Obtém o script PlayerController anexado ao objeto "Player"
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Método chamado repetidamente para gerar obstáculos
    void SpawnObstacle()
    {
        // Só gera obstáculos se o jogo não estiver em estado de "game over"
        if (playerController.gameOver == false)
        {
            // Instancia o obstáculo no local definido e com a rotação do prefab original
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        }
    }
}
