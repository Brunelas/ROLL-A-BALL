using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo; // Nome da cena do jogo, pode ser "Minigame" ou similar.
    [SerializeField] private GameObject painelMenuInicial; // Painel do menu inicial
    [SerializeField] private GameObject painelOpcoes; // Painel de opções

    // Função chamada ao clicar no botão "Jogar"
    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo); // Carrega a cena do jogo
    }

    // Função chamada ao clicar no botão "Opções"
    public void AbrirOpcoes()
    {
        painelMenuInicial.SetActive(false); // Esconde o menu inicial
        painelOpcoes.SetActive(true); // Mostra o painel de opções
    }

    // Função chamada ao clicar no botão "Voltar"
    public void FecharOpcoes()
    {
        painelOpcoes.SetActive(false); // Esconde o painel de opções
        painelMenuInicial.SetActive(true); // Mostra o menu inicial
    }
}
