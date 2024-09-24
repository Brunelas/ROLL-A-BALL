using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameOverManager gameOverManager; // Referência ao GameOverManager
    private int pontuacaoAtual = 0;

    void Awake()
    {
        // Garante que apenas um GameManager exista
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Método para adicionar pontos
    public void AdicionarPontos(int pontos)
    {
        pontuacaoAtual += pontos;
    }

    // Método para reiniciar o jogo
    public void ReiniciarJogo()
    {
        pontuacaoAtual = 0; // Reinicia a pontuação
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Método para finalizar o jogo e mostrar a tela de Game Over
    public void GameOver()
    {
        if (gameOverManager != null)
        {
            gameOverManager.MostrarGameOver(pontuacaoAtual);
        }
    }

    // Método para voltar ao menu inicial
    public void VoltarMenuInicial()
    {
        SceneManager.LoadScene("MenuInicial");
    }
}
