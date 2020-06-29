using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texto : Observador
{
    static Sujeto mirar;
    static Text vistaTexto;
    // static LlenadorGraficos barra;
    // static LlenadorGraficos torta;

    public Texto(Sujeto miralo)
    {
        mirar = miralo;
        mirar.suscribir(this);
        //if (GameObject.Find("VistaTexto") != null)
        //{
        vistaTexto = GameObject.Find("VistaTexto").GetComponent<Text>();
        //  barra = GameObject.Find("desempenio").GetComponent<LlenadorGraficos>();
        //}
        //else
        //torta = GameObject.Find("rellenoGrafTorta").GetComponent<LlenadorGraficos>();

    }

    public void mostrar(float num)
    {
        /* if (GameObject.Find("VistaTexto") != null)
         {
           */
        vistaTexto.text = num + "";
        /*   barra.llenar(num);
       }
       else
       {
           torta.llenar(num);
       }*/
    }

    public string getTextoAMostrar()
    {
        return vistaTexto.text;
    }
}