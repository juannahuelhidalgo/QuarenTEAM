using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Linq.Expressions;
using UnityEngine;

public class AdministradorDesiciones : MonoBehaviour, Sujeto
{
    GameObject canvas;
    int[] RespEsperadas = new int[] { 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 1 };
    static int[] RespTomadas = new int[15];
    static int lugarArray = -1;
    private int pacientesAtendidos = 0;
    static int correctas = 0;
    static int incorrectas = 0;
    private int desicionesTomadas; 
    //int numeroMostrar = 0;


    GameObject admDOC;
    AdministradorDocumentos admin;
    GameObject AdmJuego;
    adminJuego juego;


    //----------------------------------------------------------------------------------------------------------
    //PARAMETROS NECESARIOS PARA LOS PATRONES
    static ArrayList observadores = new ArrayList();
    static Algoritmo algoritmo = new AlgoritmoUltimaDesicion();
    static float numeroAMostrar = 0;
    public bool pacientesSemanalesAlcanzados = false;
    //-----------------------------------------------------------------------------------------------------------
    


    // busca los objetos con el tag
    void Start()
    {

        canvas = GameObject.FindWithTag("canvasDesiciones");
        admDOC = GameObject.Find("Documento");
        admin = admDOC.GetComponent<AdministradorDocumentos>();
        AdmJuego = GameObject.Find("adminJuegos");
        juego = AdmJuego.GetComponent<adminJuego>();
    }


    //Chequea si se esta mirando el documento para mostrar las posibles desiciones
    void Update()
    {
      
    }


    //algoritmo si se decide que si
    public void Si()
    {
        /*if (desicionesTomadas < 3)
        {*/
            desicionesTomadas++;
            pacientesAtendidos++;
            Debug.Log("entre al if");
           lugarArray++;
            Debug.Log("sumo lugar");
           RespTomadas[lugarArray] = 1;
            compararDesicion();
            Debug.Log("respuesta si, guardada");
            //admin.generarDocumento();
       /* }
        else { Debug.Log("no se puede mas"); }*/
    }


    //algoritmo si se decide que no
    public void No()
    {
        /*if (desicionesTomadas < 3)
        {*/
            desicionesTomadas++;
            pacientesAtendidos++;
            Debug.Log("entre al if");
            lugarArray++;
            Debug.Log("sumo lugar");
            RespTomadas[lugarArray] = 0;
            compararDesicion();
            Debug.Log("respuesta no, guardada");
            //admin.generarDocumento();
        /*}
        else { Debug.Log("no se puede mas"); }*/
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

    //----------------------------------------------------------------------------------------------------------
    //METODOS NECESARIOS PARA LOS PATRONES

    //Metodo suscribir el cual se encarga de registrar un nuevo observador
    public void suscribir(Observador nuevo)
    {
        observadores.Add(nuevo);
    }

    //Metodo desuscribir el cual se encarga de sacar un observador de la lista de observadores
    public void desuscribir(Observador sacar)
    {
        int numSac = observadores.IndexOf(sacar);
        if (numSac >= 0)
        {
            observadores.Remove(numSac);
        }

    }

    //Metodo que se encargará de notificar a los observadores suscriptos que ha cambiado
    public void notificar()
    {
        
        for (int i = 0; i < observadores.Count; i++)
        {

            Observador notificado = (Observador)observadores[i];
            notificado.mostrar(numeroAMostrar);
        }

    }

    //Metodo que se encargará de calcular el numero a mostrar acorde al algoritmo que se eliga
    public void ActualizarNumeroAMostrar()
    {
        numeroAMostrar = algoritmo.Calcular(RespTomadas,lugarArray,correctas);
    }

    //Metodo que se encargá de ver si se alcanzo el numero semanal de pacientes.
    public void corroborarLimiteSemanal()
    {
        Debug.Log("ENTRE A CORROBORAR LIMITESEMANAL con pacientes atendidos= " + pacientesAtendidos);
        if (pacientesAtendidos == 3)
        {
            StartCoroutine("esperaClasica");
        }
        else
        {
            admin.generarDocumento();
        }
    }

    IEnumerator esperaClasica()
    {
       // canvas.SetActive(false);
        bool espera = true;
        while (espera)
        {
            yield return new WaitForSeconds(3);
            juego.cargarEscenaSiguiente();
            espera = false;
        }
    }

    //Metodo que se encarga de notificar que se tomó una nueva desicion 
    public void nuevaDesicion(int num)
    {
        if(num==0)
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
