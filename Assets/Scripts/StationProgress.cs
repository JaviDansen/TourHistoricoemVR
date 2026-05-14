using UnityEngine; // Recursos básicos da Unity
using System.Collections; // Permite usar Coroutine e WaitForSeconds

public class StationProgress : MonoBehaviour // Controla a progressão entre estações
{
    [Header("UI Atual")] // Organização visual no Inspector
    public GameObject currentUI; // Objeto lógico da estação atual

    [Header("Canvas Atual")] // Organização visual no Inspector
    public GameObject currentCanvas; // Canvas visual da estação atual

    [Header("Próxima UI")] // Organização visual no Inspector
    public GameObject nextUI; // Objeto lógico da próxima estação

    [Header("Próximo Canvas")] // Organização visual no Inspector
    public GameObject nextCanvas; // Canvas visual da próxima estação

    [Header("Destino")] // Organização visual no Inspector
    public Transform nextPoint; // Ponto para onde o jogador será teleportado

    [Header("XR Origin")] // Organização visual no Inspector
    public Transform xrOrigin; // Referência do jogador VR

    [Header("Tour Manager")] // Organização visual no Inspector
    public TourObjectiveManager tourManager; // Gerenciador da HUD

    [Header("Fade")] // Organização visual no Inspector
    public FadeController fadeController; // Controlador do fade

    [Header("Delay")] // Organização visual no Inspector
    public float teleportDelay = 2f; // Tempo antes do teleporte

    private bool completed = false; // Evita múltiplas execuções

    public void CompleteStation() // Função chamada pelo botão Continuar
    {
        if (completed) return; // Impede múltiplos cliques

        completed = true; // Marca estação como concluída

        StartCoroutine(TeleportWithDelay()); // Inicia sequência
    }

    private IEnumerator TeleportWithDelay() // Executa transição completa
    {
        if (fadeController != null) // Verifica se existe fade
        {
            yield return StartCoroutine(fadeController.FadeIn()); // Escurece tela
        }

        yield return new WaitForSeconds(teleportDelay); // Espera antes do teleporte

        xrOrigin.position = nextPoint.position; // Move jogador

        xrOrigin.rotation = nextPoint.rotation; // Ajusta rotação

        if (currentCanvas != null) // Verifica canvas atual
        {
            currentCanvas.SetActive(false); // Esconde canvas antigo
        }

        if (nextUI != null) // Verifica próxima UI
        {
            nextUI.SetActive(true); // Ativa próxima lógica
        }

        if (nextCanvas != null) // Verifica próximo canvas
        {
            nextCanvas.SetActive(true); // Mostra próximo canvas
        }

        if (tourManager != null) // Verifica HUD
        {
            tourManager.NextObjective(); // Atualiza objetivo
        }

        if (fadeController != null) // Verifica fade
        {
            yield return StartCoroutine(fadeController.FadeOut()); // Clareia tela
        }

        Debug.Log("Jogador teleportado"); // Debug
    }
}