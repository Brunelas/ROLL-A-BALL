using UnityEngine;

public class FallDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Avisa o GameController que o jogador caiu
            GameController gameController = FindObjectOfType<GameController>();
            gameController.JogadorCaiu(); // Chama o método de queda no GameController
        }
    }
}
