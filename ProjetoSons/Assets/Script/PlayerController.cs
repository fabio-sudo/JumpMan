using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    // Refer�ncia ao componente Rigidbody do jogador
    private Rigidbody playerRb;
    // Modificador de gravidade para controlar a intensidade da gravidade aplicada ao jogador
    public float gravityModifier = 1f;
    // For�a de impulso para o salto do jogador
    public float jumpForce = 10f;
    // Booleano que indica se o jogador est� no ch�o
    public bool isOnGround = true;
    public bool gameOver;

    //Particulas de anima��o
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    private Animator playerAnim;

    private AudioSource playerAudioSource;

    // Start � chamado uma vez antes da primeira execu��o do Update ap�s a cria��o do MonoBehaviour
    void Start()
    {
        // Obt�m o componente Rigidbody associado ao objeto em que este c�digo est� sendo executado
        playerRb = GetComponent<Rigidbody>();

        //Obtendo o componente anima��o
        playerAnim = GetComponent<Animator>();

        playerAudioSource = GetComponent<AudioSource>();

        // Modifica a gravidade global com o fator gravityModifier
        FixedUpdate();
    }

    // Update � chamado uma vez por frame
    void Update()
    {
        // Verifica se a tecla de espa�o foi pressionada e se o jogador est� no ch�o
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            Jump();
        }     
        // Verifica se h� toque na tela
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Jump();
            }
    }


    private void Jump()
    {
            playerAudioSource.PlayOneShot(jumpSound, 1);

            // Aplica uma for�a para cima para o salto, usando o modo de impulso para uma for�a instant�nea
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false; // Define isOnGround como falso, j� que o jogador est� no ar

            //Dispara trigger da anima��o
            playerAnim.SetTrigger("Jump_trig");

            //Ativa anima��o particulas
            dirtParticle.Stop();
        }
    

    // M�todo chamado quando o jogador colide com outro objeto
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {  // Define isOnGround como verdadeiro quando o jogador toca o ch�o novamente
            isOnGround = true;
            
            //Particulas de anima��o
            dirtParticle.Play();
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            //Particulas de anima��o
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
