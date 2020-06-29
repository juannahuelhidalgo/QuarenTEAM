using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.SceneManagement;

public class adminJuego : MonoBehaviour
{
    int EscenaActual;
    public static int semanaActual = -1;
    int pacientesTotales = 0;
    static int pacientesAtendidos = 0;
    public bool buildeo = false;
    public bool cerrarJ = false;
    static int numeroSemanas = 0;

    void Start()
    {
        EscenaActual = SceneManager.GetActiveScene().buildIndex;
        buildeo = true;
        // Debug.Log("DEBUG DE ADMINISTRADOR DE ESCENA -La escena es: " + EscenaActual);
    }

    public void cargarEscenaSiguiente()
    {

        if (getNumeroEscenaActual() == 0 || getNumeroEscenaActual() == 1)
        {
            sumarSemana();
            Debug.Log("la semana actual: " + semanaActual);
            SceneManager.LoadScene(EscenaActual + 1);
        }
        if (getNumeroEscenaActual() == 2)
        {
            SceneManager.LoadScene(3);

        }
        if (getNumeroEscenaActual() == 3)
        {
            SceneManager.LoadScene(1);

        }
        if (getNumeroEscenaActual() == 3 && semanaActual == 5)
        {
                SceneManager.LoadScene(4);
   
        }
    }

    public void sumarSemana()
    {
        semanaActual++;
    }

    public int getSemanaActual()
    {
        return semanaActual;
    }


    public void cargarEscenaAnterior()
    {
        SceneManager.LoadScene(EscenaActual - 1);
    }

    public int getNumeroEscenaActual()
    {
        return EscenaActual;
    }

    public void cerrarJuego()
    {
        Debug.Log("estoy cerrando el juego");
        cerrarJ = true;
        Application.Quit();
    }

    public void setCargarEscena(int num)
    {
        SceneManager.LoadScene(num);
    }


    public void setSemana(int n)
    {
        semanaActual = n;
    }

    public bool getBuideado()
    {
        return buildeo;
    }

    public bool getCerrado()
    {
        return cerrarJ;
    }

    public void moverEnfermero()
    {

    }

    public void mouseController()
    {

    }
}
