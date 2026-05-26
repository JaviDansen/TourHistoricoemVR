using UnityEngine; // Importa funcionalidades da Unity
using UnityEngine.UI; // Importa UI da Unity

public class PlayNarration : MonoBehaviour // Classe principal
{
    public AudioSource audioSource; // Referência do áudio

    public Text buttonText; // Texto do botão

    private bool estaTocando = false; // Controla estado do áudio

    public void AlternarNarracao()
    {
        if(audioSource == null) // Verifica áudio
        {
            Debug.LogError("AudioSource não atribuída!"); // Mostra erro
            return; // Interrompe
        }

        if(buttonText == null) // Verifica texto
        {
            Debug.LogError("Texto do botão não atribuído!"); // Mostra erro
            return; // Interrompe
        }

        if(estaTocando == false) // Se não estiver tocando
        {
            audioSource.Play(); // Toca áudio

            buttonText.text = "Pause"; // Troca texto

            estaTocando = true; // Atualiza estado
        }
        else // Se já estiver tocando
        {
            audioSource.Pause(); // Pausa áudio

            buttonText.text = "Play"; // Troca texto

            estaTocando = false; // Atualiza estado
        }
    }

    public void PararNarracao()
    {
        if(audioSource != null) // Verifica áudio
        {
            audioSource.Stop(); // Para áudio
        }

        if(buttonText != null) // Verifica texto
        {
            buttonText.text = "Play"; // Reseta texto
        }

        estaTocando = false; // Reseta estado
    }
}