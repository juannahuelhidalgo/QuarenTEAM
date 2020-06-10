/*
 * Se tiene que poner tres tags para que el script funcione:
 * puerta: al objetivo que este justo antes de la puerta al consultorio
 * frenteDeJugador: al objetivo que este justo antes del jugador (fin del recorrido a la ida)
 * final: al objetivo el cual sera el final del recorrido del enfermero (a la vuelta)
 */

using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class MovimientoEnfermero : MonoBehaviour
{
    Animator anim;
    Rigidbody rigid;
    disparadorDeEventos eventos;
    public GameObject puerta;
    public Transform[] objetivos;
    public Transform jugador;


    public bool adios = false;
    public bool espera = false;


    int i = 0;                                       //Indice del array objetivos. 
    float velocidadRotacion = 4.6f;                  //Velocidad con la que rota el personaje
    float velocidadMovimiento = 2.2f;                //Velocidad con la que se mueve el personaje
    Quaternion rotacion;
    Vector3 direccion;
  
    bool rotarAlSiguiente = false;                  //Variable que indica si se puede rotar al siguiente objetivo
    bool sePuedeMover = false;                      //Variable que indica si se puede mover o no
    bool ida;                                       //Variable que indica si esta en el camino de ida (true) o de vuelta (false)

    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        eventos = GameObject.FindGameObjectWithTag("Documento").GetComponent<disparadorDeEventos>();
        anim.SetBool("Moviendo", false);                                                                            //Comienza quieto
        ida = true;                                                                                                 //Al comienzo estamos en el camino de ida
        CalcularRotacion();                                                                                         //Calculamos la rotacion hacia el PRIMER objetivo  
        StartCoroutine("Comienzo");
    }

    void FixedUpdate()                                                                                                   //Se ejecuta cada frame
    {
        Rotacion();                                                                                                 //Se llama constantemente a la funcion que se encarga de rotar
        Movimiento();                                                                                               //Se llama constantemente a la funcion que se encarga de mover
    }
    
    void Rotacion()
    {   //Funcion que rota "suavemente" el personaje
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, velocidadRotacion * Time.deltaTime);            //La rotacion se hace constantemente en esta linea
                                                                                                                    //con la rotacion indicada en la variable "rotacion"


        //Se comprueba que: Se pueda rotar y que la rotacion del personaje en el eje y (el que nos interesa) sea igual a la rotacion en el eje y de la rotacion deseada (rotacion)
        //Si se cumple esto, el personaje esta mirando completamente hacia el objetivo y puede rotar al proximo
        if (((Mathf.Round(transform.rotation.y) == Mathf.Round(rotacion.y)) || (Mathf.Round(transform.rotation.y) == Mathf.Round(-rotacion.y))) && rotarAlSiguiente)
        {
            if (ida)                                                                                                 //Si estamos en el camino de ida
                IncrementarI();                                                                                      //Incrementamos el indice para rotar hacia el proximo objetivo                                                                                   
            else                                                                                                     //Si estamos en el camino de vuelta
                DecrementarI();                                                                                      //Decrementamos el indice para rotar hacia el proximo objetivo

            CalcularRotacion();                                                                                      //Se calcula la rotacion a realizarse
            PermitirRotarAlSiguiente(false);                                                                         //Desabilitamos la rotacion al proximo objetivo
        }
    }

    void CalcularRotacion()                                                                                          //Se calcula la rotacion a realizarse                
    {
        Debug.Log(i);
        direccion = objetivos[i].position - transform.position;                                                      //Vector que marca la direccion de la rotacion
        rotacion = Quaternion.LookRotation(direccion, Vector3.up);                                                   //Rotacion que lleva hacia donde apunta el vector rotacion
    }

    void Movimiento()
    { 
        if (sePuedeMover)                                                                                           //Si se puede mover
        {
            anim.SetBool("Moviendo", true);                                                                         //Animacion de movimiento activada
            MoverNPC();                                                                                             //Se mueve el personaje
        }                                                                        
    }

    void MoverNPC()
    {
        rigid.AddForce(direccion.normalized * velocidadMovimiento, ForceMode.VelocityChange);                                      //Agrego una fuerza que causa el movimiento
    }


    void OnTriggerEnter(Collider col)                                                                               //Cuando activo el Trigger del objetivo
    {                                                                                                
        PermitirRotarAlSiguiente(true);                                                                             //Cuando llego al objetivo permito que rote al siguiente objetivo

        if (ida)                                                                                                    //Si estoy en el camino de ida
        {
            if (objetivos[i].tag == "puerta" || objetivos[i].tag == "frenteDeJugador")                              //Si llegue al objetivo antes de la puerta o al frente del jugador
            {
                PermitirMover(false);                                                                               //Desactivo el movimiento
                anim.SetBool("Moviendo", false);                                                                    //Desactivo la animacion de movimiento
            }

            if (objetivos[i].tag == "frenteDeJugador")                                                              //Si estoy al frente del juegador tambien 
            {                              
                PermitirRotarAlSiguiente(false);                                                                    //Desactivamos la rotacion al proximo objetivo
                direccion = jugador.position - transform.position;                                                  //Calculamos la proxima rotacion a hacerse hacia el jugador (no hacia el prox objetivo)
                rotacion = Quaternion.LookRotation(direccion, Vector3.up);
                StartCoroutine("llego");
                
            }
        }

        if(!ida)                                                                                                     //Si estoy en el camino de vuelta
        {
            if(objetivos[i].tag == "final")                                                                          //Si llegue al final del recorrido
            {
                PermitirMover(false);                                                                                //Desactivo el movimiento
                anim.SetBool("Moviendo", false);                                                                     //Desactivo la animacion de movimiento
                PermitirRotarAlSiguiente(false);                                                                     //Desactivamos la rotacion al proximo objetiv
            }
        }
    }

    void IncrementarI()
    {
        i++;
    }

    void DecrementarI()
    {
        i--;
    }

    public void PermitirMover(bool mover)
    {
        sePuedeMover = mover;
    }

    public void PermitirRotarAlSiguiente(bool rotar)
    {
        rotarAlSiguiente = rotar;        
    }

    public void AbrirPuerta()                                                                                       //Metodo que se ejecuta cuando abrimos la puerta
    {
        puerta.SetActive(false);
        PermitirMover(true);
        anim.SetBool("Moviendo", true);
    }

    public void Volver()                                                                                            //Metodo que se ejecuta para que vuelva a la posicion inicial
    {
        i = objetivos.Length - 2;                                                                                   //El indice se setea al anterior del objetivo donde esta parado el enfermero
        Debug.Log("i al volver vale: "+ i);
        CalcularRotacion();
        ida = false;
        velocidadRotacion = 3f;
        PermitirMover(true);
    }

    IEnumerator llego()
    {
        eventos.LlegoDocumento();
        yield return new WaitForSeconds(1);
        eventos.SePuedeVer(true);
    }

    IEnumerator Comienzo()
    {
        yield return new WaitForSeconds(0.5f);
        PermitirMover(true);
    }

}
