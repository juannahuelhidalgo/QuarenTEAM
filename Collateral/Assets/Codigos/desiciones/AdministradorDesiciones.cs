using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorDesiciones : MonoBehaviour
{
    //cuestiones de visualizacion explicadas en la clase AdministradorDocumentos
    //public bool LlegoMedico = true;
    GameObject canvas;
    //bool mirando;

    //semana 1: no es necesario otro documento
    //semana 2: cierre de aeropuestos
    //semana 3: no se permiten jovenes
    //semana 4: no se permiten extranjeros
    //semana 5: no se permite nadie que no sea factor de riesgo
    int[] RespEsperadas = new int[] { 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 }; //No ha sido chequeado
    static int[] RespTomadas = new int[15];
    static int lugarArray = -1;
    private static int pacientesAtendidos = 0;
    int correctas = 0;
    int incorrectas = 0;

    GameObject administradorDOC;


    // busca los objetos con el tag
    void Start()
    {

        canvas = GameObject.FindWithTag("CanvasDesiciones");
       // administradorDOC = GameObject.Find("mostrarPacientes");

    }


    //Chequea si se esta mirando el documento para mostrar las posibles desiciones
    void Update()
    {
     /*   if (administradorDOC.GetComponent<AdministradorDocumentos>().getMirando()) //Se fija si estas mirando el documento, y en base a eso activa o desactiva el canvas
        {
            canvas.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
        }*/
    }


    //algoritmo si se decide que si
    public void Si()
    {
        if (pacientesAtendidos <= 3)
        {
            pacientesAtendidos++;
            Debug.Log("entre al if");
            lugarArray++;
            Debug.Log("sumo lugar");
            RespTomadas[lugarArray] = 1;
            compararDesicion();
            Debug.Log("respuesta si, guardada");
          //  GameObject.Find("mostrarPacientes").GetComponent<AdministradorDocumentos>().generarDocumento();
        }
        else { Debug.Log("no se puede mas master"); }
    }


    //algoritmo si se decide que no
    public void No()
    {
        if (pacientesAtendidos <= 3)
        {
            pacientesAtendidos++;
            Debug.Log("entre al if");
            lugarArray++;
            Debug.Log("sumo lugar");
            RespTomadas[lugarArray] = 0;
            compararDesicion();
            Debug.Log("respuesta no, guardada");
         //   GameObject.Find("mostrarPacientes").GetComponent<AdministradorDocumentos>().generarDocumento();
        }
        else { Debug.Log("no se puede mas master"); }
    }


    //compara si las desiciones se consideren correctas
    public void compararDesicion()
    {
        if (RespTomadas[lugarArray].Equals(RespEsperadas[lugarArray]))
        {
            correctas++;
            Debug.Log("correcta");
        }
        else { incorrectas++; Debug.Log("incorrecta"); }
    }


    //devuelve el valor de la desicion tomada
    int getDesicionTomada(int lugar)
    {
        return (RespTomadas[lugar]);
    }


    //devuelve el valor de la desicion correcta
    int getDesicionSeteada(int lugar)
    {
        return (RespEsperadas[lugar]);
    }


    //retorna el numero de respuestas correctas
    public int Correctas()
    {
        return correctas;
    }

    //retorna el numero de respuestas incorrectas
    public int Incorrectas()
    {
        return incorrectas;
    }

}
