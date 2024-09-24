using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Usado para exibir texto na tela, se estiver usando TextMesh Pro

public class GameController : MonoBehaviour
{
    public int vidas = 3; // Número inicial de vidas
    public int pontuacao = 0; // Pontuação inicial do jogador
    public TextMeshProUGUI pontuacaoText; // Texto para exibir a pontuação
    public TextMeshProUGUI vidasText; // Texto para exibir as vidas
    public GameObject gameOverTela; // Tela de Game Over
    public Transform pontoDeRespawn; // Ponto de respawn para o jogador

     private int pontuacaoAtual = 0;

    public GameOverManager gameOverManager; // Referência ao GameOverManager

    //public GameManager gameManager; // Referência ao GameManager

    void Start()
    {
        AtualizarUI(); // Atualiza a UI no início do jogo
        gameOverTela.SetActive(false); // Esconde a tela de Game Over no início
    }

    // Método para detectar quando o jogador cai fora do mapa
    public void JogadorCaiu()
    {
        vidas--; // Reduz uma vida
        AtualizarUI(); // Atualiza a UI com a nova contagem de vidas

        if (vidas <= 0)
        {
            //GameOver(); // Mostra a tela de Game Over
            SceneManager.LoadScene(3);
            
        }
        else
        {
            // Teletransporta o jogador para uma posição segura (ponto de respawn)
            ReposicionarJogador();
        }
    }

    // Método para adicionar pontuação
    public void AdicionarPontos(int pontos)
    {
        pontuacao += pontos; // Adiciona pontos à pontuação
        AtualizarUI(); // Atualiza a UI com a nova pontuação
    }

    // Atualiza o texto de UI para pontuação e vidas
    void AtualizarUI()
    {
        pontuacaoText.text = "Pontuação: " + pontuacao;
        vidasText.text = "Vidas: " + vidas;
    }

    // Método para reposicionar o jogador para o ponto de respawn
    void ReposicionarJogador()
    {
        GameObject jogador = GameObject.FindWithTag("Player"); // Encontra o jogador pela tag
        if (jogador != null && pontoDeRespawn != null)
        {
            jogador.transform.position = pontoDeRespawn.position; // Teletransporta o jogador para o ponto de respawn
        }
    }

    // Método para mostrar a tela de Game Over
    
    // Método para reiniciar o jogo
    public void RecomeçarJogo()
    {
        Time.timeScale = 1; // Retorna o tempo ao normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarrega a cena atual
    }

    // Método para voltar ao menu inicial
    public void VoltarAoMenu()
    {
        Time.timeScale = 1; // Retorna o tempo ao normal
        SceneManager.LoadScene("MenuInicial"); // Carrega a cena do menu inicial
    }
}
