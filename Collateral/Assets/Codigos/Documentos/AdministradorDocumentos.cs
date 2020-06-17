using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class AdministradorDocumentos : MonoBehaviour
{
    Text nombre; //Nombre, Edad, Nacionalidad, Enfermedades,Sexo,Viajo
    Text edad;
    Text nacionalidad;
    Text enfermedades;
    Text sexo;
    Text viajo;
    datosPacientes data;
    public bool LlegoEnfermero = true;
    GameObject doc;
    Canvas canvas;
    Canvas canvasrestricciones;
    Canvas desiciones;
    Canvas barra;
 

     void Awake()
    {
        nombre = GameObject.Find("RespNombre").GetComponent<Text>();
        edad = GameObject.Find("RespEdad").GetComponent<Text>();
        nacionalidad = GameObject.Find("RespNacionalidad").GetComponent<Text>();
        enfermedades = GameObject.Find("RespEnfermedad").GetComponent<Text>();
        sexo = GameObject.Find("RespSexo").GetComponent<Text>();
        viajo = GameObject.Find("RespViajo").GetComponent<Text>();
        data = GameObject.Find("Documento").GetComponent<datosPacientes>();
        doc = GameObject.FindWithTag("Documento");
        canvas = GameObject.Find("CanvasDocumentos").GetComponent<Canvas>();
        canvasrestricciones = GameObject.Find("CanvasRestricciones").GetComponent<Canvas>();
        desiciones = GameObject.Find("CanvasDesicion").GetComponent<Canvas>();
        barra = GameObject.Find("CanvasBarraDesempenio").GetComponent<Canvas>();
    }

    private void Start()
    {
        if (GameObject.Find("RespNombre").GetComponent<Text>().text.Equals("New Text"))
            generarDocumento();
    }

    //El update se fija si se modifica el booleano que indica si llego el enfermero, y muestra o no muestra el documento que ve el jugador dependiendo de esto.
    private void Update()
    {
        if (LlegoEnfermero)
        {
            doc.SetActive(true);
        }
        else
        {
            doc.SetActive(false);
        }
    }

    //Le asigna a la información correspondiente a el canvas que muestra la informacion de la ficha medica del paciente, cada llamada de este metodo carga la informacion de un nuevo paciente
    public void generarDocumento()
    {
        Debug.Log("Llame a generar documento.");
        string[] paciente = new string[6];
        paciente = data.generatePatient();
        nombre.text = paciente[0];
        edad.text = paciente[1];
        nacionalidad.text = paciente[2];
        enfermedades.text = paciente[3];
        sexo.text = paciente[4];
        viajo.text = paciente[5];

    }

    //Este es un seter para saber si llego el enfermero
    public void setllegoEnfermero(bool llego)
    {
        LlegoEnfermero = llego;
    }

    //Este metodo desactiva o activa los canvas CanvasDocumentos, CanvasRestricciones y el CanvasDesiciones
    public void mirando(bool mirar)
    {
        canvas.enabled = mirar;
        canvasrestricciones.enabled = mirar;
        desiciones.enabled = mirar;
        barra.enabled = mirar;
    }

}