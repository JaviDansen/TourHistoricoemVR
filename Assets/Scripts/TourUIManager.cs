using UnityEngine; // Recursos principais da Unity
using TMPro; // Controle de textos TextMeshPro

public class TourUIManager : MonoBehaviour // Gerenciador geral da interface do tour
{
    [Header("HUD")] // Organização visual no Inspector
    [SerializeField] private GameObject hudPanel; // Painel do HUD
    [SerializeField] private TMP_Text objectiveText; // Texto do objetivo atual

    [Header("Quiz")] // Área do quiz
    [SerializeField] private GameObject quizPanel; // Painel do quiz

    [Header("Tela Final")] // Área da tela final
    [SerializeField] private GameObject finalPanel; // Painel final

    [Header("Objetivos")] // Lista de objetivos do tour
    [SerializeField] private string[] objectives; // Objetivos configurados no Inspector

    private int currentObjective = -1; // Índice atual do objetivo

    private void Start()
    {
        // Estado inicial da interface

        objectiveText.text = "Inicie o Tour"; // Texto inicial do HUD

        hudPanel.SetActive(true); // HUD visível

        quizPanel.SetActive(false); // Quiz escondido

        finalPanel.SetActive(false); // Tela final escondida
    }

    public void NextObjective() // Avança para o próximo objetivo
    {
        if (currentObjective < objectives.Length - 1) // Verifica se ainda existem objetivos
        {
            currentObjective++; // Avança índice

            UpdateObjective(); // Atualiza HUD
        }
    }

    private void UpdateObjective() // Atualiza texto do objetivo
    {
        objectiveText.text = objectives[currentObjective]; // Exibe objetivo atual
    }

    public void ShowQuiz() // Mostra o quiz
    {
        hudPanel.SetActive(false); // Esconde HUD

        quizPanel.SetActive(true); // Mostra quiz
    }

    public void ShowFinalScreen() // Mostra tela final
    {
        quizPanel.SetActive(false); // Esconde quiz

        finalPanel.SetActive(true); // Mostra tela final
    }
}