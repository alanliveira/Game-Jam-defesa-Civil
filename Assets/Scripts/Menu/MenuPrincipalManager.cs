using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private string Creditos; // <-- adicionei isso
    [SerializeField] private GameObject painelMenuInicial;

    // Botão "Jogar"
    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }

    // Botão "Créditos"
    public void AbrirCreditos()
    {
        SceneManager.LoadScene(Creditos);
    }

    // Botão "Sair"
    public void SairJogo()
    {
        Application.Quit();
    }
}