using UnityEngine;

public class IsoPlayer : MonoBehaviour
{
    public float velocidadeCorrida = 10f;
    public float velocidadeAndar = 5f;

    public GameObject playerModel;  // aqui você arrasta o "Model3D"
    public Transform cam;           // aqui você arrasta a câmera (ou o cameraPivot, se preferir)

    private Animator anim;
    private float velocidadePlayer;

    void Start()
    {
        anim = playerModel.GetComponent<Animator>();
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputZ = Input.GetAxisRaw("Vertical");

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        velocidadePlayer = isRunning ? velocidadeCorrida : velocidadeAndar;

        // direção bruta
        Vector3 moveDirection = new Vector3(inputX, 0f, inputZ).normalized;

        if (moveDirection.magnitude >= 0.1f)
        {
            // pega vetores da câmera
            Vector3 camForward = cam.forward;
            Vector3 camRight = cam.right;

            camForward.y = 0f;
            camRight.y = 0f;
            camForward.Normalize();
            camRight.Normalize();

            // direção final de movimento (em relação à câmera)
            Vector3 finalDirection = camForward * inputZ + camRight * inputX;

            // move PlayerController (pai)
            transform.position += finalDirection.normalized * velocidadePlayer * Time.deltaTime;

            // gira apenas o modelo visual (Model3D)
            if (playerModel != null)
            {
                Quaternion targetRotation = Quaternion.LookRotation(finalDirection);
                playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, targetRotation, 10f * Time.deltaTime);
            }

            // animações
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
