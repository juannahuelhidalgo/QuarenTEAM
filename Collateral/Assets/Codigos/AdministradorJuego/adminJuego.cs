using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class adminJuego : MonoBehaviour
{
    int EscenaActual;
    int semanaActual = 0;
    int pacientesTotales = 0;
    static int pacientesAtendidos = 0;


    void Start()
    {
        EscenaActual = SceneManager.GetActiveScene().buildIndex;
       // Debug.Log("DEBUG DE ADMINISTRADOR DE ESCENA -La escena es: " + EscenaActual);
    }

    public void cargarEscenaSiguiente()
    {
        if (getNumeroEscenaActual() == 0 || getNumeroEscenaActual() == 1)
        {
            semanaActual++;
            Debug.Log("la semana actual es (primer if) " + semanaActual);
            SceneManager.LoadScene(EscenaActual + 1);
        }
        if (getNumeroEscenaActual() == 2)
        {
            semanaActual++;
            Debug.Log("la semana actual es (segundo if) " + semanaActual);
            SceneManager.LoadScene(1);
        }
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
        Application.Quit();
    }
    public void cargarEscena(int num)
    {
        SceneManager.LoadScene(num);
    }

    public int semanaAct()
    {
        return semanaActual;
    }

    public void setSemana(int n)
    {
        semanaActual = n;
    }

    public void moverEnfermero()
    {
       
    }

    public void mouseController()
    {

    }
}
