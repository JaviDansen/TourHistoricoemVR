using System.Collections; // Permite usar Coroutine e WaitForSeconds
using UnityEngine; // Biblioteca principal da Unity

public class BoasVindasController : MonoBehaviour // Classe principal do script
{
    public GameObject painelBoasVindas; // Painel da UI que será escondido
    public GameObject xrOrigin; // Jogador XR que será teleportado
    public Transform pontoChamine; // Ponto para onde o jogador irá

    public void IniciarTour() // Função chamada ao clicar no botão
    {
        StartCoroutine(IniciarTourCoroutine()); // Inicia sequência com delay
    }

    IEnumerator IniciarTourCoroutine() // Coroutine da sequência
    {
        painelBoasVindas.SetActive(false); // Esconde UI

        yield return new WaitForSeconds(3f); // Espera 3 segundos

        xrOrigin.transform.position = pontoChamine.position; // Teleporta jogador
    }
}