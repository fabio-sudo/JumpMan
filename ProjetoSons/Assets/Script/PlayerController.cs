using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    // Referência ao componente Rigidbody do jogador
    private Rigidbody playerRb;
    // Modificador de gravidade para controlar a intensidade da gravidade aplicada ao jogador
    public float gravityModifier = 1f;
    // Força de impulso para o salto do jogador
    public float jumpForce = 10f;
    // Booleano que indica se o jogador está no chão
    public bool isOnGround = true;
    public bool gameOver;

    //Particulas de animação
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    private Animator playerAnim;

    private AudioSource playerAudioSource;

    // Start é chamado uma vez antes da primeira execução do Update após a criação do MonoBehaviour
    void Start()
    {
        // Obtém o componente Rigidbody associado ao objeto em que este código está sendo executado
        playerRb = GetComponent<Rigidbody>();

        //Obtendo o componente animação
        playerAnim = GetComponent<Animator>();

        playerAudioSource = GetComponent<AudioSource>();

        // Modifica a gravidade global com o fator gravityModifier
        FixedUpdate();
    }

    // Update é chamado uma vez por frame
    void Update()
    {
        // Verifica se a tecla de espaço foi pressionada e se o jogador está no chão
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            Jump();
        }     
        // Verifica se há toque na tela
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Jump();
            }
    }


    private void Jump()
    {
            playerAudioSource.PlayOneShot(jumpSound, 1);

            // Aplica uma força para cima para o salto, usando o modo de impulso para uma força instantânea
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false; // Define isOnGround como falso, já que o jogador está no ar

            //Dispara trigger da animação
            playerAnim.SetTrigger("Jump_trig");

            //Ativa animação particulas
            dirtParticle.Stop();
        }
    

    // Método chamado quando o jogador colide com outro objeto
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {  // Define isOnGround como verdadeiro quando o jogador toca o chão novamente
            isOnGround = true;
            
            //Particulas de animação
            dirtParticle.Play();
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            //Particulas de animação
            playerAudioSource.PlayOneShot(crashSound, 1.0f);
            explosionParticle.Play();
            dirtParticle.Stop();


            gameOver = true;
            Debug.Log("Game Over!");

            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int",1);


        }
    }


    void FixedUpdate()
    {
        playerRb.AddForce(Vector3.down * (gravityModifier - 1) * Physics.gravity.magnitude, ForceMode.Acceleration);
    }
}
