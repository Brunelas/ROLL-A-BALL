using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Adicione se você estiver usando TextMesh Pro

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI pontuacaoText; // Campo para exibir a pontuação
    private int pontuacaoFinal; // Pontuação final do jogador

    

    public GameTimer gameTimer; // Referência ao script GameTimer
    public TextMeshProUGUI tempoText; // Campo para exibir o tempo


    void Start()
    {
        // Desativa a tela de Game Over inicialmente
        gameObject.SetActive(false);
    }

    public void MostrarGameOver(int pontuacao)
{
    pontuacaoFinal = pontuacao;
    pontuacaoText.text = pontuacaoFinal + " PONTOS"; // Atualiza o texto da pontuação

    
    
    if (gameTimer != null)
    {
        tempoText.text = "Tempo: " + gameTimer.ObterTempoDecorrido(); // Atualiza o texto do tempo
    }

    gameObject.SetActive(true); // Mostra a tela de Game Over
}


    // Adicione estes métodos ao final do script
    public void Recomeçar()
    {
        GameManager.instance.ReiniciarJogo();
    }

    public void MenuInicial()
    {
        GameManager.instance.VoltarMenuInicial();
    }
}
