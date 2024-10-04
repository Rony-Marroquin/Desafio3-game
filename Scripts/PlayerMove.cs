using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 7;
    public float rotationSpeed = 250;
    public Animator animator;
    public AudioSource audioSource;  // Asigna tu AudioSource en el Inspector

    private float x, y;
    public Rigidbody rb;
    public float jump = 3;

    public Transform groundcheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask; // Corregido: typo 'grounfMask' por 'groundMask'
    bool isGrounded;

    void Update()
    {
        // Obtener las entradas del jugador
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        // Movimiento y rotación
        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, y * Time.deltaTime * runSpeed);

        // Parámetros de movimiento en el Animator
        animator.SetFloat("VeX", x);
        animator.SetFloat("VeY", y);

        // Activar animación de baile
        if (Input.GetKey("b"))
        {   
            animator.SetBool("baile", false);
            animator.Play("dance");  
        }

        // Activar animación de golpe
        if (Input.GetKey("m"))
        {   
            animator.SetBool("golpe", false);
            animator.Play("punch");  
        }

        // Revertir animaciones si hay movimiento
        if (x != 0 || y != 0)
        {
            animator.SetBool("baile", true);
            animator.SetBool("golpe", true);
            animator.SetBool("salto", true);
        }

        // Comprobar si está en el suelo
        isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);

        // Mostrar si el personaje está en el suelo en la consola (para depuración)
        Debug.Log("Is Grounded: " + isGrounded);

        // Activar animación de salto
       if (Input.GetKey(KeyCode.Space) && isGrounded)
               {
            animator.Play("Jump up");
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }
       
    

        // Cambiar a la escena del menú al presionar la tecla "Escape"
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main-Menu"); 
        }
    }

    // Detectar colisiones con objetos etiquetados
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fresa"))
        {
            Destroy(other.gameObject);
        }

        if (other.CompareTag("banana"))
        {
            Destroy(other.gameObject);
        }

        if (other.CompareTag("chile"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("cofre"))
        {
            Destroy(other.gameObject);
        }
    }
}
