using System.Collections; // Permite usar Coroutine e WaitForSeconds
using UnityEngine; // Biblioteca principal da Unity

public class BoasVindasController : MonoBehaviour // Classe principal do script
{
    [Header("UI Inicial")]
    public GameObject painelBoasVindas; // Painel inicial

    [Header("Jogador VR")]
    public GameObject xrOrigin; // Jogador XR

    [Header("Destino Inicial")]
    public Transform pontoChamine; // Primeiro ponto do tour

    [Header("Primeira UI")]
    public GameObject uiChamines; // Interface das Chaminés

    [Header("Fade")]
    public FadeController fadeController; // Controlador do fade

    [Header("Delay")]
    public float teleportDelay = 2f; // Tempo antes do teleporte

    public void IniciarTour() // Função chamada ao clicar no botão
    {
        StartCoroutine(IniciarTourCoroutine()); // Inicia sequência
    }

    IEnumerator IniciarTourCoroutine() // Coroutine da sequência
    {
        // ---------- FADE IN ----------
        if (fadeController != null) // Verifica se existe fade
        {
            yield return StartCoroutine(fadeController.FadeIn()); // Escurece tela
        }

        // ---------- ESCONDE UI INICIAL ----------
        painelBoasVindas.SetActive(false); // Esconde UI inicial

        // ---------- ESPERA ----------
        yield return new WaitForSeconds(teleportDelay); // Espera antes do teleporte

        // ---------- TELEPORTE ----------
        xrOrigin.transform.position = pontoChamine.position; // Move jogador

        xrOrigin.transform.rotation = pontoChamine.rotation; // Ajusta rotação

        // ---------- MOSTRA PRIMEIRA UI ----------
        uiChamines.SetActive(true); // Mostra UI das Chaminés

        // ---------- FADE OUT ----------
        if (fadeController != null) // Verifica se existe fade
        {
            yield return StartCoroutine(fadeController.FadeOut()); // Clareia tela
        }
    }
}