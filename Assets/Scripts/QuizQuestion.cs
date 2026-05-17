public class QuizQuestion // Estrutura de uma pergunta
{
    public string question; // Texto da pergunta

    public string[] answers; // Lista de respostas

    public int correctAnswer; // Índice da resposta correta

    public QuizQuestion(string question, string[] answers, int correctAnswer)
    {
        this.question = question;

        this.answers = answers;

        this.correctAnswer = correctAnswer;
    }
}