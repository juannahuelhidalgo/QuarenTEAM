using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
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
    int index;
    patientsData data;
    public bool LlegoEnfermero = true;
    GameObject doc;
    GameObject canvas;
    bool mirando;

    private void Start()
    {

        nombre = GameObject.Find("RespNombre").GetComponent<Text>();
        edad = GameObject.Find("RespEdad").GetComponent<Text>();
        nacionalidad = GameObject.Find("RespNacionalidad").GetComponent<Text>();
        enfermedades = GameObject.Find("RespEnfermedad").GetComponent<Text>();
        sexo = GameObject.Find("RespSexo").GetComponent<Text>();
        viajo = GameObject.Find("RespViajo").GetComponent<Text>();
        data = GameObject.Find("Documento").GetComponent<patientsData>();
        doc = GameObject.FindWithTag("Documento");
        canvas = GameObject.FindWithTag("CanvasDocumentos");


        generarDocumento();
    }

    private void Update()
    {
        if (LlegoEnfermero)
        {
            doc.SetActive(true);
            if (mirando)
            {
                canvas.SetActive(true);
            }
            else
            {
                canvas.SetActive(false);
            }
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

    public void setMirando(bool mirar)
    {
        mirando = mirar;
    }
}