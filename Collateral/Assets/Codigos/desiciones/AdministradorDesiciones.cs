using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class AdministradorDesiciones : MonoBehaviour, Sujeto, Escenarios, Comunicacion
{
    //----------------------------------------------------------------------------------------------------------
    //Declarado de variables
    int[] RespEsperadas = new int[] { 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 1 };
    public static int[] RespTomadas = new int[15];
    static int lugarArray = -1;
    private int pacientesAtendidos = 0;
    static int correctas = 0;
    static int incorrectas = 0;
    private static int desicionesTomadas;
    private int notificaciones = 0;
    public bool espera = false;
    public bool cambio;

    //----------------------------------------------------------------------------------------------------------
    //Objetos necesarios
    GameObject canvas;
    GameObject admDOC;
    AdministradorDocumentos admin;
    GameObject AdmJuego;
    adminJuego juego;
    GameObject enfer;
    GameObject contro;
   
    disparadorDeEventos eventos;
    //----------------------------------------------------------------------------------------------------------
    //PARAMETROS NECESARIOS PARA LOS PATRONES
    static ArrayList observadores = new ArrayList();
    static Algoritmo algoritmo = new AlgoritmoUltimaDecision();
    static float numeroAMostrar = 0;
    public bool pacientesSemanalesAlcanzados = false;
    //-----------------------------------------------------------------------------------------------------------


    // busca los objetos con el tag
    void Start()
    {

        canvas = GameObject.FindWithTag("canvasDesiciones");
        admDOC = GameObject.Find("Documento");
        contro = GameObject.FindWithTag("control");
        admin = admDOC.GetComponent<AdministradorDocumentos>();
        AdmJuego = GameObject.Find("adminJuegos");
        juego = AdmJuego.GetComponent<adminJuego>();
        eventos = admDOC.GetComponent<disparadorDeEventos>();
        enfer = GameObject.FindWithTag("npc");
        if(desicionesTomadas == 15)
        {
            juego.setCargarEscena(4);
        }
        cambio = false;

    }


    //algoritmo si se decide que si
    public void Si()
    {
        desicionesTomadas++;
        pacientesAtendidos++;
        Debug.Log("entre al if");
        lugarArray++;
        Debug.Log("sumo lugar");
        RespTomadas[lugarArray] = 1;
        compararDesicion();
        Debug.Log("respuesta si, guardada");
    }


    //algoritmo si se decide que no
    public void No()
    {
        desicionesTomadas++;
        pacientesAtendidos++;
        Debug.Log("entre al if");
        lugarArray++;
        Debug.Log("sumo lugar");
        RespTomadas[lugarArray] = 0;
        compararDesicion();
        Debug.Log("respuesta no, guardada");
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


    public int[] array()
    {
        return RespTomadas;
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
    public int getCorrectas()
    {
        return correctas;
    }


    //retorna el numero de respuestas incorrectas
    public int getIncorrectas()
    {
        return incorrectas;
    }

    //setea el numero de pacientes atendidos;
    public void setNumeroPacientes(int num)
    {
        pacientesAtendidos = num;
    }

    public bool getCambio()
    {
        return cambio;
    }
    //----------------------------------------------------------------------------------------------------------
    //METODOS NECESARIOS PARA LOS PATRONES

    //Metodo suscribir el cual se encarga de registrar un nuevo observador
    public void suscribir(Observador nuevo)
    {
        observadores.Add(nuevo);
    }

    //Metodo que devuelve el tamaño del array
    public int getSuscribirTamanio()
    {
        return (observadores.Count);
    }

    //Metodo desuscribir el cual se encarga de sacar un observador de la lista de observadores
    public void desuscribir(Observador sacar)
    {

        int numSac = observadores.IndexOf(sacar);
        if (numSac >= 0)
        {
            observadores.Remove(sacar);
        }

    }

    //Metodo que se encargará de notificar a los observadores suscriptos que ha cambiado
    public void notificar()
    {

        for (int i = 0; i < observadores.Count; i++)
        {

            Observador notificado = (Observador)observadores[i];
            notificado.mostrar(numeroAMostrar);
            notificaciones++;
        }

    }

    //Devuelve el numero de notificaciones realizadas
    public int getNotificaciones()
    {
        return notificaciones;
    }


    //Metodo que se encargará de calcular el numero a mostrar acorde al algoritmo que se eliga
    public void ActualizarNumeroAMostrar()
    {
        numeroAMostrar = algoritmo.Calcular(RespTomadas, lugarArray, correctas);
        UltimoValor.ultimo = numeroAMostrar;
    }

    public float getnumeroMostrado()
    {
        return numeroAMostrar;
    }

    //Metodo que se encargá de ver si se alcanzo el numero semanal de pacientes.
    public void corroborarLimiteSemanal()
    {
        Debug.Log("ENTRE A CORROBORAR LIMITESEMANAL con pacientes atendidos= " + pacientesAtendidos);
        if (pacientesAtendidos == 3)
        {
            contro.GetComponent<Controller>().setAlgoritmoPromedio();
            UltimoValor.ultimaDesicion = 1;
            eventos.EnfermeroSeVa();            
            StartCoroutine("PasarSemana");

        }
        else
        {
            admin.generarDocumento();
        }
    }
    

    IEnumerator PasarSemana()
    {
        cambio = true;
        yield return new WaitForSeconds(3.5f);                          //Tiempo que espera el juego antes de pasar a la siguiente semana para que el enfermero se vaya de la habitacion
        cargarEscenaSiguiente();
    }

    public void cargarEscenaSiguiente()
    {
        juego.cargarEscenaSiguiente();
    }
  
    public void SetPacientesAtendidos(int pacientesAtendidos)
    {
        this.pacientesAtendidos = pacientesAtendidos;
    }
    public bool getesperando()
    {
        return espera;
    }

    //Metodo que se encarga de notificar que se tomó una nueva desicion 
    public void nuevaDesicion(int num)
    {
        if (num == 0)
        {
            No();
            ActualizarNumeroAMostrar();
        }
        else
        {
            Si();
            ActualizarNumeroAMostrar();
        }
        notificar();
        corroborarLimiteSemanal();
    }

    //Metodo que se encarga de setear el algoritmo con el que se calcula el numero a mostrar
    public void setEstrategia(Algoritmo nueva)
    {
        algoritmo = nueva;
        ActualizarNumeroAMostrar();
        notificar();

    }

    //-----------------------------------------------------------------------------------------------------------
}
