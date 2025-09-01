using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Tempo de atraso inicial antes de come�ar a gerar obst�culos
    private float startDelay = 2;

    // Tempo entre cada gera��o de obst�culos
    private float repeatRate = 2;

    // Refer�ncia ao script PlayerController para verificar o estado do jogo
    private PlayerController playerController;

    // Prefab do obst�culo que ser� gerado
    public GameObject obstaclePrefab;

    // Posi��o onde os obst�culos ser�o gerados
    private Vector3 spawnPosition = new Vector3(12, 0, 0);

    // O m�todo Start � chamado uma vez antes da primeira execu��o do m�todo Update
    void Start()
    {
        // Configura uma chamada repetitiva ao m�todo SpawnObstacle
        // Come�a ap�s "startDelay" segundos e repete a cada "repeatRate" segundos
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);

        // Obt�m o script PlayerController anexado ao objeto "Player"
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // M�todo chamado repetidamente para gerar obst�culos
    void SpawnObstacle()
    {
        // S� gera obst�culos se o jogo n�o estiver em estado de "game over"
        if (playerController.gameOver == false)
        {
            // Instancia o obst�culo no local definido e com a rota��o do prefab original
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        }
    }
}
