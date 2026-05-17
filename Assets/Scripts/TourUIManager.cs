using UnityEngine; // Recursos principais da Unity

public class TourUIManager : MonoBehaviour // Gerenciador geral da interface do tour
{
    [Header("Quiz")] // Área do quiz
    [SerializeField] private GameObject quizPanel; // Painel do quiz

    [Header("Tela Final")] // Área da tela final
    [SerializeField] private GameObject finalPanel; // Painel final

    [Header("Objetivos")] // Controle interno do progresso
    [SerializeField] private string[] objectives; // Lista de objetivos do tour

    private int currentObjective = -1; // Índice atual do objetivo

    private void Start()
    {
        // Estado inicial da interface

        quizPanel.SetActive(false); // Quiz começa escondido

        finalPanel.SetActive(false); // Tela final começa escondida
    }

    public void NextObjective() // Avança objetivo internamente
    {
        if (currentObjective < objectives.Length - 1) // Verifica limite
        {
            currentObjective++; // Avança índice
        }
    }

    public void ShowQuiz() // Mostra o quiz
    {
        quizPanel.SetActive(true); // Exibe quiz
    }

    public void ShowFinalScreen() // Mostra tela final
    {
        quizPanel.SetActive(false); // Esconde quiz

        finalPanel.SetActive(true); // Exibe tela final
    }
}