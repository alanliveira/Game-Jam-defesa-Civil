using UnityEngine;

public class IsoCamera : MonoBehaviour
{
    public Transform player;   // arraste o Player aqui no Inspector
    public Vector3 offset = new Vector3(0, 50, -20); // posição relativa da câmera
    public float smoothSpeed = 5f; // suavidade do movimento

    void LateUpdate()
    {
        if (player == null) return;

        // Posição desejada da câmera em relação ao player
        Vector3 desiredPosition = player.position + offset;

        // Suaviza o movimento da câmera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;

        // Faz a câmera olhar para o player
        transform.LookAt(player.position);
    }
}