using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GanhouManager : MonoBehaviour
{
    public string proximaCena = "Menu"; // Nome da cena para ir depois de 10 segundos
    public float tempoDeEspera = 10f;

    void Start()
    {
        StartCoroutine(EsperarParaMudarCena());
    }

    IEnumerator EsperarParaMudarCena()
    {
        yield return new WaitForSeconds(tempoDeEspera);
        SceneManager.LoadScene(proximaCena);
    }
}