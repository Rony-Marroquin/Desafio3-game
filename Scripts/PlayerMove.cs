using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 7;
    public float rotationSpeed = 250;
    public Animator animator;
    public AudioSource audioSource;  

    private float x, y;
    public Rigidbody rb;
    public float jump = 3;

    public Transform groundcheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask; 
    bool isGrounded;

    void Update()
    {
        
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

      
        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, y * Time.deltaTime * runSpeed);

      
        animator.SetFloat("VeX", x);
        animator.SetFloat("VeY", y);

      
        if (Input.GetKey("b"))
        {   
            animator.SetBool("baile", false);
            animator.Play("dance");  
        }

        
        if (Input.GetKey("m"))
        {   
            animator.SetBool("golpe", false);
            animator.Play("punch");  
        }

       
        if (x != 0 || y != 0)
        {
            animator.SetBool("baile", true);
            animator.SetBool("golpe", true);
            animator.SetBool("salto", true);
        }

   
        isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);


        Debug.Log("Is Grounded: " + isGrounded);

      
       if (Input.GetKey(KeyCode.Space) && isGrounded)
               {
            animator.Play("Jump up");
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }
       
    

       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main-Menu"); 
        }
    }

 
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
