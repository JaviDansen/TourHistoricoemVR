using UnityEngine; // Recursos principais da Unity
using TMPro; // Controle de textos TextMeshPro
using UnityEngine.UI; // Controle de botões da UI

public class QuizManager : MonoBehaviour // Classe principal do Quiz
{
    [Header("UI")] // Organização visual no Inspector

    [SerializeField] private TMP_Text questionText; // Texto da pergunta

    [SerializeField] private TMP_Text feedbackText; // Texto de feedback

    [SerializeField] private Button[] answerButtons; // Lista dos 4 botões

    [Header("Tela Final")] // Área da tela final

    [SerializeField] private GameObject quizPanel; // Painel do quiz

    [SerializeField] private GameObject finalPanel; // Painel final

    [SerializeField] private TMP_Text finalScoreText; // Texto da pontuação final

    private int currentQuestion = 0; // Índice da pergunta atual

    private int score = 0; // Quantidade de acertos

    private bool answered = false; // Impede múltiplos cliques na mesma pergunta

    // Estrutura das perguntas
    private QuizQuestion[] questions =
    {
        new QuizQuestion(
            "Qual era a principal função dos armazéns do Trapiche?",
            new string[]
            {
                "Servir como escola",
                "Guardar e movimentar mercadorias",
                "Funcionar como hospital",
                "Ser apenas área residencial"
            },
            1
        ),

        new QuizQuestion(
            "O que as chaminés representam no Trapiche?",
            new string[]
            {
                "Um monumento moderno",
                "Uma área de lazer",
                "O passado industrial e portuário",
                "Uma torre de observação"
            },
            2
        ),

        new QuizQuestion(
            "O que os destroços ajudam a representar?",
            new string[]
            {
                "O crescimento urbano moderno",
                "A passagem do tempo e deterioração histórica",
                "Elementos decorativos",
                "Construções recentes"
            },
            1
        ),

        new QuizQuestion(
            "Qual tecnologia tornou o tour mais imersivo?",
            new string[]
            {
                "Áudio narrativo espacial",
                "Teclado físico",
                "Chat online",
                "Sistema de corrida"
            },
            0
        ),

        new QuizQuestion(
            "Qual o principal objetivo do projeto Trapiche Conectado?",
            new string[]
            {
                "Criar jogo competitivo",
                "Simular cidade futurista",
                "Promover educação patrimonial em VR",
                "Criar aplicativo de mapas"
            },
            2
        )
    };

    private void Start()
    {
        feedbackText.text = ""; // Limpa feedback inicial

        ShowQuestion(); // Exibe primeira pergunta
    }

    private void ShowQuestion() // Atualiza pergunta atual
    {
        answered = false; // Libera resposta para nova pergunta

        QuizQuestion question = questions[currentQuestion]; // Obtém pergunta atual

        questionText.text = question.question; // Atualiza texto da pergunta

        // Atualiza textos dos botões
        for (int i = 0; i < answerButtons.Length; i++)
        {
            TMP_Text buttonText = answerButtons[i].GetComponentInChildren<TMP_Text>();

            buttonText.text = question.answers[i];

            int index = i; // Evita problema de referência no botão

            answerButtons[i].onClick.RemoveAllListeners(); // Limpa eventos antigos

            answerButtons[i].onClick.AddListener(() => CheckAnswer(index)); // Adiciona novo evento
        }
    }

    private void CheckAnswer(int answerIndex) // Verifica resposta selecionada
    {
        if (answered) return; // Bloqueia spam de clique

        answered = true; // Marca pergunta como respondida

        QuizQuestion question = questions[currentQuestion]; // Obtém pergunta atual

        // Verifica se acertou
        if (answerIndex == question.correctAnswer)
        {
            score++; // Soma pontuação

            feedbackText.text = "Resposta correta!";
        }
        else
        {
            feedbackText.text = "Resposta incorreta!";
        }

        Invoke(nameof(NextQuestion), 1.5f); // Aguarda antes de avançar
    }

    private void NextQuestion() // Avança pergunta
    {
        feedbackText.text = ""; // Limpa feedback

        currentQuestion++; // Avança índice

        // Verifica se ainda existem perguntas
        if (currentQuestion < questions.Length)
        {
            ShowQuestion(); // Mostra próxima pergunta
        }
        else
        {
            FinishQuiz(); // Finaliza quiz
        }
    }

    private void FinishQuiz() // Final do quiz
    {
        quizPanel.SetActive(false); // Esconde quiz

        finalPanel.SetActive(true); // Mostra tela final

        finalScoreText.text =
            "Você acertou " + score + " de " + questions.Length + " perguntas!";
    }
}