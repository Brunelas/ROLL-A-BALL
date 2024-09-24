using UnityEngine;
using TMPro; // Usado para manipular textos UI com TextMesh Pro

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Referência ao texto do timer na UI
    private float tempoDecorrido = 0f; // Variável para armazenar o tempo decorrido

    void Update()
    {
        // Incrementa o tempo decorrido com o tempo do frame atual
        tempoDecorrido += Time.deltaTime;

        // Calcula minutos e segundos a partir do tempo decorrido
        int minutos = Mathf.FloorToInt(tempoDecorrido / 60);
        int segundos = Mathf.FloorToInt(tempoDecorrido % 60);

        // Atualiza o texto do timer na UI
        timerText.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    // Método para obter o tempo decorrido
    public string ObterTempoDecorrido()
    {
        
        return string.Format("{0:00}:{1:00}", Mathf.FloorToInt(tempoDecorrido / 60), Mathf.FloorToInt(tempoDecorrido % 60));
    }

    // Método para reiniciar o cronômetro, se necessário
    public void ReiniciarTimer()
    {
        tempoDecorrido = 0f;
    }
}
