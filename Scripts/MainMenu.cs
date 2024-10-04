using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Agregamos la referencia necesaria

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        // No hay lógica en el método Start por ahora
    }

    void Update()
    {
        // No hay lógica en el método Update por ahora
    }

    public void IniciarJuego() // Cambié el nombre del método para mayor claridad
    {
        SceneManager.LoadScene("SampleScene"); // Corrección del nombre y agrego el punto y coma
    }

    public void SalirDelJuego() // Método para salir del juego
    {
        Debug.Log("Saliendo del juego..."); // Mensaje para ver en el editor
        Application.Quit(); // Cierra la aplicación
    }
}
