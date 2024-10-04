using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    void Start()
    {
       
    }

    void Update()
    {
        
    }

    public void IniciarJuego() 
    {
        SceneManager.LoadScene("SampleScene"); 
    }

    public void SalirDelJuego() 
    {
        Debug.Log("Saliendo del juego..."); 
        Application.Quit(); 
    }
}
