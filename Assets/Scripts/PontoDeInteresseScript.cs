using UnityEngine; // Importa funcionalidades da Unity

public class PontoDeInteresseScript : MonoBehaviour
{
    public GameObject PontoDeInteresse; // UI
    public PlayNarration playNarration; // Controle do áudio

    private void Start()
    {
        PontoDeInteresse.SetActive(false); // Começa escondido
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("MainCamera")) // Detecta jogador
        {
            PontoDeInteresse.SetActive(true); // Mostra UI
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("MainCamera")) // Detecta saída
        {
            playNarration.PararNarracao(); // Para áudio
            PontoDeInteresse.SetActive(false); // Esconde UI
        }
    }
}