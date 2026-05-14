using UnityEngine; // Importa funcionalidades da Unity
using TMPro; // Importa TextMeshPro

public class PlayNarration : MonoBehaviour // Classe principal
{
    public AudioSource audioSource; // Referência do áudio
    public TextMeshProUGUI buttonText; // Texto do botão

    private bool estaTocando = false; // Controla estado do áudio

    public void AlternarNarracao()
    {
        if(estaTocando == false) // Se não estiver tocando
        {
            audioSource.Play(); // Inicia áudio
            buttonText.text = "Pause"; // Troca texto do botão
            estaTocando = true; // Atualiza estado
        }
        else // Se já estiver tocando
        {
            audioSource.Pause(); // Pausa áudio
            buttonText.text = "Play"; // Volta texto
            estaTocando = false; // Atualiza estado
        }
    }

    public void PararNarracao()
    {
        audioSource.Stop(); // Para totalmente o áudio
        buttonText.text = "Play"; // Reseta botão
        estaTocando = false; // Reseta estado
    }
}