using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Usado para exibir texto na tela, se estiver usando TextMesh Pro

public class VitoriaManager : MonoBehaviour
{


    public TextMeshProUGUI tempoText; // Texto para exibir o tempo
    public TextMeshProUGUI pontuacaoText; // Texto para exibir a pontuação

    private void Start()
    {
        // Carregar os dados dos PlayerPrefs
        int pontuacao = PlayerPrefs.GetInt("Pontuacao", 0);
        string tempo = PlayerPrefs.GetString("Tempo", "00:00");

        // Exibir os dados nos textos
        tempoText.text = "Tempo: " + tempo;
        pontuacaoText.text = "Pontuação: " + pontuacao;
    }
    // Start is called before the first frame update
    public void Recomecar()
    {
        Time.timeScale = 1; // Retorna o tempo ao normal
        SceneManager.LoadSceneAsync(1);
    }

    // Update is called once per frame
    public void Menu()
    {
         Time.timeScale = 1; // Retorna o tempo ao normal
        SceneManager.LoadSceneAsync(0);
    }
}
