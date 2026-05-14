using UnityEngine; // Biblioteca principal
using UnityEngine.UI; // Necessário para Image
using System.Collections; // Necessário para Coroutines

public class FadeController : MonoBehaviour // Controla fade da tela
{
    public Image fadeImage; // Imagem preta do fade

    public float fadeSpeed = 2f; // Velocidade do fade

    public IEnumerator FadeIn() // Escurece tela
    {
        float alpha = 0; // Transparência inicial

        while (alpha < 1) // Enquanto não estiver totalmente preto
        {
            alpha += Time.deltaTime * fadeSpeed; // Incrementa alpha

            fadeImage.color = new Color(0, 0, 0, alpha); // Atualiza cor

            yield return null; // Espera próximo frame
        }
    }

    public IEnumerator FadeOut() // Clareia tela
    {
        float alpha = 1; // Começa preto

        while (alpha > 0) // Enquanto ainda estiver visível
        {
            alpha -= Time.deltaTime * fadeSpeed; // Reduz alpha

            fadeImage.color = new Color(0, 0, 0, alpha); // Atualiza cor

            yield return null; // Espera próximo frame
        }
    }
}