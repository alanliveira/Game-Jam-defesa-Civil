using UnityEngine;

public class WaterRise : MonoBehaviour
{
    public Vector3 StartPosition;
    public Vector3 endPosition;

    public bool canRise = false;
    public float duration = 300f; // segundos

    private float elapsedTime = 0f;

    void Start()
    {
        transform.position = StartPosition;
        canRise = true;
    }

    void Update()
    {
        if (canRise)
        {
            // Atualiza o tempo
            elapsedTime += Time.deltaTime;

            // Calcula o t normalizado (0 -> 1)
            float t = Mathf.Clamp01(elapsedTime / duration);

            // Interpola a posição
            transform.position = Vector3.Lerp(StartPosition, endPosition, t);

            // Se chegou no fim, para
            if (t >= 1f)
            {
                canRise = false;
            }
        }

        // Apenas para visualização no editor
        Debug.DrawLine(StartPosition, endPosition, Color.blue);
    }

    // Retorna a porcentagem da subida da água (0 a 1)
    public float GetWaterRisePercent()
    {
        return Mathf.Clamp01(elapsedTime / duration);
    }
}
