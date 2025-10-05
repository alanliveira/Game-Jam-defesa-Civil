using UnityEngine;
using UnityEngine.SceneManagement;

public class PerguntaUI : MonoBehaviour
{
    public GameObject perguntaUI;

    private static int acertos = 0; // Contador de respostas corretas (mantido entre cenas se necessário)

    public void RespostaCerta()
    {
        acertos++;

        if (acertos >= 3)
        {
            // Garante que o tempo volta ao normal
            Time.timeScale = 1f;

            // Vai para a cena de vitória
            SceneManager.LoadScene("Ganhou");
            return;
        }

        FecharPergunta();

        // Aqui você pode dar pontos, bônus etc.
    }

    public void RespostaErrada()
    {
        // Fecha a pergunta antes de trocar de cena
        perguntaUI.SetActive(false);

        // Garante que o tempo volta ao normal
        Time.timeScale = 1f;

        // Troca para a cena de Game Over
        SceneManager.LoadScene("GameOver");
    }

    private void FecharPergunta()
    {
        perguntaUI.SetActive(false);
        Time.timeScale = 1f;

        // Esconder cursor novamente
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Método para resetar contador, se quiser reiniciar no início da cena, por exemplo
    public static void ResetarAcertos()
    {
        acertos = 0;
    }
}