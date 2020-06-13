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


    public int i = 0;                                       //Indice del array objetivos. 3.8
    float velocidadRotacion = 3.8f;                  //Velocidad con la que rota el personaje
    float velocidadMovimiento = 2.2f;                //Velocidad con la que se mueve el personaje
    public Quaternion rotacion;
    public Vector3 direccion;
    Vector3 direccion2;
  
    bool rotarAlSiguiente = false;                  //Variable que indica si se puede rotar al siguiente objetivo
    bool sePuedeMover = false;                      //Variable que indica si se puede mover o no
    public bool ida;                                       //Variable que indica si esta en el camino de ida (true) o de vuelta (false)
    bool comportamientoUltimoTramo = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        eventos = GameObject.FindGameObjectWithTag("Documento").GetComponent<disparadorDeEventos>();
        anim.SetBool("Moviendo", false);                                                                            //Comienza quieto
        ida = true;                                                                                               //Al comienzo estamos en el camino de ida
        CalcularRotacion();                                                                                         //Calculamos la rotacion hacia el PRIMER objetivo  
        StartCoroutine("InicioDeRecorrido");
    }

    void FixedUpdate()                                                                                                   //Se ejecuta cada frame
    {
        Rotacion();                                                                                                 //Se llama constantemente a la funcion que se encarga de rotar
        Movimiento();                                                                                               //Se llama constantemente a la funcion que se encarga de mover
    }
    
    public void Rotacion()
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

    public void CalcularRotacion()                                                                                          //Se calcula la rotacion a realizarse                
    {        
        direccion = objetivos[i].position - transform.position;                                                      //Vector que marca la direccion de la rotacion
        rotacion = Quaternion.LookRotation(direccion, Vector3.up);                                                   //Rotacion que lleva hacia donde apunta el vector rotacion
    }

    public void Movimiento()
    { 
        if (sePuedeMover)                                                                                           //Si se puede mover
        {
            anim.SetBool("Moviendo", true);                                                                         //Animacion de movimiento activada
            if(!comportamientoUltimoTramo)
            MoverNpc(direccion);                                                                                             //Se mueve el personaje
            else
            MoverNpc(direccion2);
        }

    }

    public void MoverNpc(Vector3 direccionAIr)
    {
        rigid.AddForce(direccionAIr.normalized * velocidadMovimiento, ForceMode.VelocityChange);                                      //Agrego una fuerza que causa el movimiento
    }


    public void OnTriggerEnter()                                                                               //Cuando activo el Trigger del objetivo
    {                                                                                                
        PermitirRotarAlSiguiente(true);                                                                             //Cuando llego al objetivo permito que rote al siguiente objetivo

        if (ida)                                                                                                    //Si estoy en el camino de ida
        {
            if (comportamientoUltimoTramo)                                                                    //Si llegue al objetivo antes de la puerta o al frente del jugador
            {
                PermitirMover(false);                                                                               //Desactivo el movimiento
                anim.SetBool("Moviendo", false);                                                                    //Desactivo la animacion de movimiento
                StartCoroutine("LlegoEnfermero");  
            }

            if (objetivos[i].tag == "PrevioFinalIda")                                                              //Si estoy en el objetivo anterior al del final de la ida 
            { 
                //Se camina hacia el siguiente objetivo pero se mira al jugador                             
                PermitirRotarAlSiguiente(false);
                IncrementarI();
                CalcularRotacion();
                DecrementarI();
                direccion2 = direccion;
                comportamientoUltimoTramo = true;
                direccion = jugador.position - transform.position;                                                  
                rotacion = Quaternion.LookRotation(direccion, Vector3.up); 
                velocidadRotacion = 3.8f;      
            }
        }

        if(!ida)                                                                                                     //Si estoy en el camino de vuelta
        {
            if(objetivos[i].tag == "FinalVuelta")                                                                          //Si llegue al final del recorrido
            {
                PermitirMover(false);                                                                                //Desactivo el movimiento
                anim.SetBool("Moviendo", false);                                                                     //Desactivo la animacion de movimiento
                PermitirRotarAlSiguiente(false);                                                                     //Desactivamos la rotacion al proximo objetiv
            }
        }
    }

    public void IncrementarI()
    {
        i++;
    }

    public void DecrementarI()
    {
        i--;
    }
    
    public void setRotacion(Quaternion rotacion)
    {
        this.rotacion = rotacion;
    }

    public bool getComportamientoUltimoTramo()
    {
        return comportamientoUltimoTramo;
    }
    public void PermitirMover(bool mover)
    {
        sePuedeMover = mover;
    }

    public void PermitirRotarAlSiguiente(bool rotar)
    {
        rotarAlSiguiente = rotar;        
    }

    public void Volver()                                                                                            //Metodo que se ejecuta para que vuelva a la posicion inicial
    {
        comportamientoUltimoTramo = false;
        i = objetivos.Length - 2;                                                                                   //El indice se setea al anterior del objetivo donde esta parado el enfermero
        CalcularRotacion();
        ida = false;
        velocidadRotacion = 3f;
        PermitirMover(true);
    }

    IEnumerator LlegoEnfermero()
    {
        eventos.LlegoDocumento();
        yield return new WaitForSeconds(1);
        eventos.SePuedeVer(true);
    }

    IEnumerator InicioDeRecorrido()
    {
        yield return new WaitForSeconds(0.5f);
        PermitirMover(true);
    }

    public Transform[] returnObjetivos()
    {
        return objetivos;        
    }

}
