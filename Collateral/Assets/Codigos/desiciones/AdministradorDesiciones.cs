using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorDesiciones : MonoBehaviour
{
    GameObject canvas;
    int[] RespEsperadas = new int[] { 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 }; //No ha sido chequeado
    static int[] RespTomadas = new int[15];
    //List<Observador> observadores = new List<Observador>();
    static int lugarArray = -1;
    private static int pacientesAtendidos = 0;
    int correctas = 0;
    int incorrectas = 0;
    private int desicionesTomadas = 0; 
    int numeroMostrar = 0;


    GameObject admDOC;
    AdministradorDocumentos admin;
    GameObject AdmJuego;
    adminJuego juego;


    // busca los objetos con el tag
    void Start()
    {

        canvas = GameObject.FindWithTag("canvasDesiciones");
        admDOC = GameObject.Find("Documento");
        admin = admDOC.GetComponent<AdministradorDocumentos>();

        AdmJuego = GameObject.Find("adminJuegos");
        juego = AdmJuego.GetComponent<adminJuego>();


        if(desicionesTomadas == 3)
        {
            desicionesTomadas = 0;
        }

    }


    //Chequea si se esta mirando el documento para mostrar las posibles desiciones
    void Update()
    {
      
    }


    //algoritmo si se decide que si
    public void Si()
    {
        if (desicionesTomadas < 3)
        {
            desicionesTomadas++;
            pacientesAtendidos++;
            //Debug.Log("entre al if");
            lugarArray++;
           // Debug.Log("sumo lugar");
            RespTomadas[lugarArray] = 1;
            compararDesicion();
           // Debug.Log("respuesta si, guardada");
            if (desicionesTomadas <= 2)
            {
                admin.generarDocumento();
            }
           
        }
        else
        {
            if (desicionesTomadas == 3)
            {
                StartCoroutine("esperaClasica");
            }
        }

    }


    //algoritmo si se decide que no
    public void No()
    {
        if (desicionesTomadas < 3)
        {
            desicionesTomadas++;
            pacientesAtendidos++;
           // Debug.Log("entre al if");
            lugarArray++;
            //Debug.Log("sumo lugar");
            RespTomadas[lugarArray] = 0;
            compararDesicion();
         //   Debug.Log("respuesta no, guardada");
            if (desicionesTomadas <= 2)
            {
                admin.generarDocumento();
            }
               
        }
        else { 
            if (desicionesTomadas == 3){ 
                StartCoroutine("esperaClasica");    
            } 
        }   
    }


    //compara si las desiciones se consideren correctas
    public void compararDesicion()
    {
        if (RespTomadas[lugarArray].Equals(RespEsperadas[lugarArray]))
        {
            correctas++;
          //  Debug.Log("correcta");
        }
        else { incorrectas++;/* Debug.Log("incorrecta");*/ }
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

    IEnumerator esperaClasica()
    {
        canvas.SetActive(false);
        bool espera = true;
        while (espera)
        {
            yield return new WaitForSeconds(3);
            juego.cargarEscenaSiguiente();
            espera = false;
        }
    }

    //este metodo notificara a los observadores
    public void notificar()
    {

          /*  for (int i = 0; i < observadores.Count; i++)
              {
                  observadores[i].OnNotify();
              }*/

    }

    //este metodo dejara suscribir al observador
    public void suscribir(/*Observador n*/)
    {
        //observadores.Add(n);
    }

    //este metodo quitara el observador indicado
    public void quitar(/*Observador n*/)
    {
       // observador.Remove(n);
    }

    //este metodo setea la estrategia a mostrar
    public void setEstrategia()
    {


    }

}
