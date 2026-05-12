using UnityEngine; // Recursos básicos da Unity
using TMPro; // Controle de textos TextMeshPro

public class TourObjectiveManager : MonoBehaviour // Classe principal do sistema de objetivos
{
    [SerializeField] private TMP_Text objectiveText; // Referência do texto do HUD

    [SerializeField] private string[] objectives; // Lista de objetivos do tour

    private int currentObjective = -1; // Índice do objetivo atual

    private void Start(){
        objectiveText.text = "Inicie o Tour"; // Define texto inicial antes do tour começar
    }

    public void NextObjective(){ // Avança para o próximo objetivo
        if (currentObjective < objectives.Length - 1) // Verifica se ainda existem objetivos
        {
            currentObjective++; // Avança índice

            UpdateObjective(); // Atualiza HUD
        }
    }

    private void UpdateObjective() // Atualiza texto na tela
    {
        objectiveText.text = objectives[currentObjective]; // Exibe objetivo atual
    }
}