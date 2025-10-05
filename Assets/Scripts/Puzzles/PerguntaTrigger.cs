using UnityEngine;

public class PerguntaTrigger : MonoBehaviour
{
    public GameObject perguntaUI;
    public bool pausarJogo = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            perguntaUI.SetActive(true);

            // Pausar o jogo (se configurado)
            if (pausarJogo)
                Time.timeScale = 0f;

            // Mostrar cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}