using UnityEngine; // Biblioteca principal da Unity
using UnityEngine.UI; // Biblioteca da UI

public class QuizManager : MonoBehaviour // Classe principal do Quiz
{
    [System.Serializable] // Permite visualizar perguntas no Inspector
    public class Question // Estrutura da pergunta
    {
        public string pergunta; // Texto da pergunta

        public string[] alternativas = new string[4]; // Alternativas A B C D

        public int respostaCorreta; // Índice da resposta correta
    }

    [Header("Perguntas")]
    public Question[] questions; // Lista de perguntas do quiz

    [Header("UI Quiz")]
    public Text questionText; // Texto da pergunta

    public Text feedbackText; // Texto de feedback

    [Header("Botões")]
    public Button btnA; // Botão A

    public Button btnB; // Botão B

    public Button btnC; // Botão C

    public Button btnD; // Botão D

    [Header("Textos dos Botões")]
    public Text txtA; // Texto botão A

    public Text txtB; // Texto botão B

    public Text txtC; // Texto botão C

    public Text txtD; // Texto botão D

    [Header("Canvases")]
    public GameObject canvasQuiz; // Canvas do quiz

    public GameObject canvasFinal; // Canvas final

    [Header("Tela Final")]
    public Text finalScoreText; // Texto da pontuação final

    private int currentQuestion = 0; // Índice da pergunta atual

    private int score = 0; // Quantidade de acertos

    private bool answered = false; // Impede spam de clique

    private void Start() // Inicialização do quiz
    {
        canvasFinal.SetActive(false); // Garante tela final escondida

        feedbackText.text = ""; // Limpa feedback inicial

        ShowQuestion(); // Mostra primeira pergunta

        // Liga botões às respostas
        btnA.onClick.AddListener(() => CheckAnswer(0)); // Botão A

        btnB.onClick.AddListener(() => CheckAnswer(1)); // Botão B

        btnC.onClick.AddListener(() => CheckAnswer(2)); // Botão C

        btnD.onClick.AddListener(() => CheckAnswer(3)); // Botão D
    }

    void ShowQuestion() // Mostra pergunta atual
    {
        answered = false; // Libera resposta da nova pergunta

        Question q = questions[currentQuestion]; // Obtém pergunta atual

        questionText.text = q.pergunta; // Atualiza pergunta

        txtA.text = q.alternativas[0]; // Atualiza alternativa A

        txtB.text = q.alternativas[1]; // Atualiza alternativa B

        txtC.text = q.alternativas[2]; // Atualiza alternativa C

        txtD.text = q.alternativas[3]; // Atualiza alternativa D

        feedbackText.text = ""; // Limpa feedback anterior
    }

    void CheckAnswer(int respostaSelecionada) // Verifica resposta escolhida
    {
        if (answered) return; // Impede múltiplos cliques

        answered = true; // Marca pergunta como respondida

        Question q = questions[currentQuestion]; // Obtém pergunta atual

        if (respostaSelecionada == q.respostaCorreta) // Se acertou
        {
            feedbackText.text = "Resposta Correta!"; // Mostra feedback positivo

            score++; // Soma ponto
        }
        else // Se errou
        {
            feedbackText.text = "Resposta Errada!"; // Mostra feedback negativo
        }

        currentQuestion++; // Avança pergunta

        if (currentQuestion < questions.Length) // Ainda existem perguntas
        {
            Invoke("ShowQuestion", 1.5f); // Mostra próxima pergunta
        }
        else // Se terminou o quiz
        {
            Invoke("ShowFinalScreen", 1.5f); // Mostra tela final
        }
    }

    void ShowFinalScreen() // Mostra tela final
    {
        canvasQuiz.SetActive(false); // Esconde quiz

        canvasFinal.SetActive(true); // Mostra tela final

        finalScoreText.text =
        "Você acertou " + score + " de " + questions.Length + " perguntas!"; // Mostra pontuação final
    }
}