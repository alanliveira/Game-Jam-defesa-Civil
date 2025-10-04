using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditosManager : MonoBehaviour
{
    [Header("Imagens dos Créditos")]
    public Image imagemCredito;
    public Sprite[] imagensCreditos; // arraste suas imagens aqui

    [Header("Configurações")]
    public float tempoEntreImagens = 3f; // tempo que cada imagem fica na tela
    [SerializeField] private string Menu = "MenuPrincipal"; // cena para voltar

    private int indiceAtual = 0;

    void Start()
    {
        if (imagensCreditos.Length > 0)
        {
            StartCoroutine(TrocarImagens());
        }
        else
        {
            Debug.LogWarning("Nenhuma imagem atribuída em CreditosManager!");
        }
    }

    IEnumerator TrocarImagens()
    {
        while (indiceAtual < imagensCreditos.Length)
        {
            imagemCredito.sprite = imagensCreditos[indiceAtual];
            yield return new WaitForSeconds(tempoEntreImagens);
            indiceAtual++;
        }

        // Quando terminar todas as imagens, volta ao menu
        SceneManager.LoadScene("Menu");
    }
}