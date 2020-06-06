using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
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
 

    private void Awake()
    {
        
        nombre = GameObject.Find("RespNombre").GetComponent<Text>();
        edad = GameObject.Find("RespEdad").GetComponent<Text>();
        nacionalidad = GameObject.Find("RespNacionalidad").GetComponent<Text>();
        enfermedades = GameObject.Find("RespEnfermedad").GetComponent<Text>();
        sexo = GameObject.Find("RespSexo").GetComponent<Text>();
        viajo = GameObject.Find("RespViajo").GetComponent<Text>();
        data = GameObject.Find("Documento").GetComponent<datosPacientes>();
        doc = GameObject.Find("Documento");
        canvas = GameObject.Find("CanvasDocumentos").GetComponent<Canvas>();
        canvasrestricciones = GameObject.Find("CanvasRestricciones").GetComponent<Canvas>();
        generarDocumento();
    }

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


    public void generarDocumento()
    {

        string[] paciente = new string[6];
        paciente = data.generatePatient();
        nombre.text = paciente[0];
        edad.text = paciente[1];
        nacionalidad.text = paciente[2];
        enfermedades.text = paciente[3];
        sexo.text = paciente[4];
        viajo.text = paciente[5];

    }

    public void setllegoEnfermero(bool llego)
    {
        LlegoEnfermero = llego;
    }

    public void mirando(bool mirar)
    {
        canvas.enabled = mirar;
        canvasrestricciones.enabled = mirar;
    }

}