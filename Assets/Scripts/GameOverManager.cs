using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    public string proximaCena = "Menu"; // Nome da cena para onde vai depois dos 10 segundos
    public float tempoDeEspera = 10f;   // Tempo de espera em segundos

    void Start()
    {
        // Inicia a contagem de tempo assim que a cena começa
        StartCoroutine(EsperarParaMudarCena());
    }

    IEnumerator EsperarParaMudarCena()
    {
        yield return new WaitForSeconds(tempoDeEspera);

        // Carrega a próxima cena
        SceneManager.LoadScene(proximaCena);
    }
}