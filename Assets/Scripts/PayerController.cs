using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
//using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
 // Rigidbody of the player.
 private Rigidbody rb; 

 // Variable to keep track of collected "PickUp" objects.
 private int count;

 // Movement along X and Y axes.
 private float movementX;
 private float movementY;

 // Speed at which the player moves.
 public float speed = 0;

 // Quantidade de vidas do jogador.
public int vidas = 3;

 // UI text component to display count of "PickUp" objects collected.
 public TextMeshProUGUI countText;

 // UI object to display winning text.
 public GameObject winTextObject;

 public AudioClip coinCollectSound; // Som de coleta de moeda
private AudioSource audioSource; // Componente de áudio do jogador

 // Variables for the timer
private float tempoDecorrido = 0f;
private bool cronometrando = false;


 // Start is called before the first frame update.
 void Start()
    {
 // Get and store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();

        // Get the AudioSource component attached to the player.
        audioSource = GetComponent<AudioSource>();


 // Initialize count to zero.
        count = 0;

 // Update the count display.
        SetCountText();

 // Initially set the win text to be inactive.
        winTextObject.SetActive(false);

        // Inicia o cronômetro quando o jogo começa
        IniciarCronometro();
    }
 
 // This function is called when a move input is detected.
 void OnMove(InputValue movementValue)
    {
 // Convert the input value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();

 // Store the X and Y components of the movement.
        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }

 // FixedUpdate is called once per fixed frame-rate frame.
 private void FixedUpdate() 
    {
 // Create a 3D movement vector using the X and Y inputs.
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);

 // Apply force to the Rigidbody to move the player.
        rb.AddForce(movement * speed); 

        // Atualiza o tempo decorrido se o cronômetro estiver ativo
        if (cronometrando)
        {
            tempoDecorrido += Time.deltaTime;
        }
    }

    // Método para obter o tempo decorrido formatado
    public string ObterTempoDecorrido()
    {
        int minutos = Mathf.FloorToInt(tempoDecorrido / 60);
        int segundos = Mathf.FloorToInt(tempoDecorrido % 60);
        return string.Format("{0:00}:{1:00}", minutos, segundos);
    }

  // Método para iniciar o cronômetro
    public void IniciarCronometro()
    {
        cronometrando = true;
        tempoDecorrido = 0f; // Reseta o tempo para 0 quando inicia o cronômetro
    }

    // Método para parar o cronômetro
    public void PararCronometro()
    {
        cronometrando = false;
    }

 
 void OnTriggerEnter(Collider other) 
    {
 // Check if the object the player collided with has the "PickUp" tag.
 if (other.gameObject.CompareTag("PickUp")) 
        {
 // Deactivate the collided object (making it disappear).
            other.gameObject.SetActive(false);

 // Increment the count of "PickUp" objects collected.
            count = count + 1;

 // Update the count display.
            SetCountText();
        }
        // Play the coin collection sound.
       if (coinCollectSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(coinCollectSound);
            }
    }

 // Function to update the displayed count of "PickUp" objects collected.
 void SetCountText() 
    {
 // Update the count text with the current count.
        countText.text = "PONTUAÇÃO: " + count.ToString();

 // Check if the count has reached or exceeded the win condition.
 if (count >= 12)
        {
 // Display the win text.
            SceneManager.LoadScene(2);
            winTextObject.SetActive(true);
            PararCronometro(); // Para o cronômetro quando vence o jogo


            // Salvar a pontuação e o tempo nos PlayerPrefs antes de mudar de cena
            PlayerPrefs.SetInt("Pontuacao", count);
            PlayerPrefs.SetString("Tempo", ObterTempoDecorrido());
            PlayerPrefs.Save();

            // Mudar para a cena de vitória (substitua "CenaVitoria" pelo nome correto da sua cena)
            SceneManager.LoadScene("CenaVitoria");
        }
    }
    
}