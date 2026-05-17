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

    [Header("HUD")]
    public TourUIManager tourManager; // Sistema de objetivos

    public void IniciarTour() // Função chamada ao clicar no botão
    {
        StartCoroutine(IniciarTourCoroutine()); // Inicia sequência
    }

    IEnumerator IniciarTourCoroutine() // Coroutine da sequência
    {
        painelBoasVindas.SetActive(false); // Esconde UI inicial

        yield return new WaitForSeconds(3f); // Espera antes do teleporte

        xrOrigin.transform.position = pontoChamine.position; // Move jogador

        xrOrigin.transform.rotation = pontoChamine.rotation; // Ajusta rotação

        uiChamines.SetActive(true); // Mostra UI das Chaminés

        tourManager.NextObjective(); // Inicia primeiro objetivo
    }
}