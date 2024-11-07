using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;       // Velocidad de movimiento
    public float jumpForce = 10f;      // Fuerza del salto
    public Transform groundCheck;      // Punto de chequeo del suelo
    public LayerMask groundLayer;      // Capa del suelo para detectar si el personaje está tocando el suelo

    private Rigidbody rb;
    private bool isGrounded;           // Indica si el personaje está tocando el suelo
    private float groundCheckRadius = 0.2f; // Radio para detectar el suelo

    private void Start()
    {
        // Obtener el Rigidbody del personaje
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Evitar rotaciones del personaje
    }

    private void Update()
    {
        // Chequear si está tocando el suelo
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        // Movimiento horizontal
        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector3 moveVelocity = new Vector3(moveInput * moveSpeed, rb.velocity.y, 0f);
        rb.velocity = moveVelocity;

        // Animar el personaje (opcional, si tienes animaciones)
        // Animator.SetFloat("Speed", Mathf.Abs(moveInput));

        // Salto
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0f);
        }
    }
}
