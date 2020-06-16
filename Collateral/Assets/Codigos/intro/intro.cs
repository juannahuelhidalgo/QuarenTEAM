using Mono.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intro : MonoBehaviour
{
    GameObject[] semanas;
    GameObject semana1;
    GameObject semana2;
    GameObject semana3;
    GameObject semana4;
    GameObject semana5;
    int semana;

    GameObject pri;
    GameObject se;



    private void Awake()
    {
        GameObject.Find("Documento").GetComponent<datosPacientes>().enabled = false;
        GameObject.Find("Documento").GetComponent<visorDeObjetos>().enabled = false; 
        GameObject.Find("Documento").GetComponent<disparadorDeEventos>().enabled = false; 
        GameObject.Find("Documento").GetComponent<seguidorDeMouse>().enabled = false;
        GameObject.Find("Documento").GetComponent<AdministradorDocumentos>().enabled = false;
       // GameObject.Find("CamaraDocumentos").GetComponent<Camera>().enabled = false;
        GameObject.Find("Controller").GetComponent<Controller>().enabled = false;
        GameObject.Find("mostrarPacientes").GetComponent<AdministradorDesiciones>().enabled = false;
        GameObject.Find("CanvasRestricciones").GetComponent<AdminRestricciones>().enabled = false;
        GameObject.Find("BotonDeTesteo").GetComponent<AdministradorDocumentos>().enabled = false;
        GameObject.Find("CanvasRestricciones").GetComponent<Canvas>().enabled = false;
        GameObject.Find("CanvasDesicion").GetComponent<Canvas>().enabled = false;
        GameObject.Find("CanvasGrafTorta").GetComponent<Canvas>().enabled = false;
        GameObject.Find("CanvasDocumentos").GetComponent<Canvas>().enabled = false;
        GameObject.Find("CanvasGrafTorta").GetComponent<noDestruir>().enabled = false;
        GameObject.Find("rellenoGrafTorta").GetComponent<Recordar>().enabled = false;

        semana1 = GameObject.Find("semana1");
        semana2 = GameObject.Find("semana2");
        semana3 = GameObject.Find("semana3");
        semana4 = GameObject.Find("semana4");
        semana5 = GameObject.Find("semana5");

        pri = GameObject.Find("CamaraDocumentos");
        se = GameObject.Find("CamaraIntro");

        pri.SetActive(false);

        semana = GameObject.Find("adminJuegos").GetComponent<adminJuego>().getSemanaActual();
        
        switch (semana)
        {
            case 0:
                semana2.SetActive(false);
                semana3.SetActive(false);
                semana4.SetActive(false);
                semana5.SetActive(false);
                break;

            case 1:
                semana1.SetActive(false);
                semana3.SetActive(false);
                semana4.SetActive(false);
                semana5.SetActive(false);

                break;

            case 2:
                semana2.SetActive(false);
                semana1.SetActive(false);
                semana4.SetActive(false);
                semana5.SetActive(false);

                break;

            case 3:
                semana2.SetActive(false);
                semana3.SetActive(false);
                semana1.SetActive(false);
                semana5.SetActive(false);

                break;

            case 4:
                semana2.SetActive(false);
                semana3.SetActive(false);
                semana4.SetActive(false);
                semana1.SetActive(false);

                break;

            case 5:
                semana2.SetActive(false);
                semana3.SetActive(false);
                semana4.SetActive(false);
                semana5.SetActive(false);

                break;
        }

    }

    public void activarTODE()
    {
        GameObject.Find("Documento").GetComponent<datosPacientes>().enabled = true;
        GameObject.Find("Documento").GetComponent<visorDeObjetos>().enabled = true;
        GameObject.Find("Documento").GetComponent<disparadorDeEventos>().enabled = true;
        GameObject.Find("Documento").GetComponent<seguidorDeMouse>().enabled = true;
        GameObject.Find("Documento").GetComponent<AdministradorDocumentos>().enabled = true;

      //  GameObject.Find("CamaraDocumentos").GetComponent<Camera>().enabled = true;

        GameObject.Find("Controller").GetComponent<Controller>().enabled = true;
        GameObject.Find("mostrarPacientes").GetComponent<AdministradorDesiciones>().enabled = true;
        GameObject.Find("CanvasRestricciones").GetComponent<AdminRestricciones>().enabled = true;
        GameObject.Find("BotonDeTesteo").GetComponent<AdministradorDocumentos>().enabled = true;
        GameObject.Find("CanvasRestricciones").GetComponent<Canvas>().enabled = true;
        GameObject.Find("CanvasDesicion").GetComponent<Canvas>().enabled = true;
        GameObject.Find("CanvasGrafTorta").GetComponent<Canvas>().enabled = true;
        GameObject.Find("CanvasDocumentos").GetComponent<Canvas>().enabled = true;
        GameObject.Find("CanvasGrafTorta").GetComponent<noDestruir>().enabled = true;
        GameObject.Find("rellenoGrafTorta").GetComponent<Recordar>().enabled = true;

        pri.SetActive(true);
        se.SetActive(false);

      //  GameObject.Find("CamaraIntro").GetComponent<Camera>().enabled = false;
    }

}
