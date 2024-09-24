using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private bool movendoParaDireita = true; // Direção inicial do movimento

    public GameController gameController; // Referência ao GameController




    public float speed = 5f; // Velocidade de movimento do inimigo
    public float range = 20f; // Amplitude total do movimento

    private float startX; // Posição inicial do inimigo no eixo X

    // Som de colisão
    public AudioClip collisionSound; // Som a ser tocado na colisão
    private AudioSource audioSource; // Componente de áudio do inimigo

    void Start()
    {
        // Armazena a posição inicial do objeto
        startX = transform.position.x;

        // Obtém o componente AudioSource anexado ao inimigo
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Calcula a nova posição baseada na velocidade e no tempo
        float movement = Mathf.PingPong(Time.time * speed, range);

        // Define a posição do objeto, alternando entre os extremos da faixa
        transform.position = new Vector3(startX + movement - (range / 2), transform.position.y, transform.position.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Verifica se colidiu com o jogador
        {
            // Chama o método JogadorCaiu do GameController
            if (gameController != null)
            {
                gameController.JogadorCaiu(); // Reduz uma vida e reposiciona o jogador
            }
            // Toca o som de colisão
            if (collisionSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(collisionSound);
            }

        }
    }
}
