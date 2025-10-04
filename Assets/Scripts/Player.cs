using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float velocidadePlayer;
    public float velocidadeCorrida = 10;
    public float velocidadeAndar = 5;
    public Camera cameraPlayer;
    private Animator anim;
    private Rigidbody rb;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        // Define a velocidade de acordo com a corrida
        velocidadePlayer = isRunning ? velocidadeCorrida : velocidadeAndar;

        // Direções da câmera
        Vector3 forward = cameraPlayer.transform.forward;
        Vector3 right = cameraPlayer.transform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        // Calcula a direção
        Vector3 moveDirection = (forward * inputZ + right * inputX).normalized;

        if (moveDirection.magnitude > 0.1f)
        {
            // Move usando física
            Vector3 newPosition = rb.position + moveDirection * velocidadePlayer * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);

            // Gira o personagem
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, 10f * Time.fixedDeltaTime));

            // Animações
            anim.SetBool("walk", true);
            anim.SetBool("run", isRunning);
        }
        else
        {
            anim.SetBool("walk", false);
            anim.SetBool("run", false);
        }
    }
}