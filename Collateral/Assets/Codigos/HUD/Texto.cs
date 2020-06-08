using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texto : Observador
{
    static Sujeto mirar;
    static Text vistaTexto;

    public Texto(Sujeto miralo)
    {
        mirar = miralo;
        mirar.suscribir(this);
        vistaTexto = GameObject.Find("VistaTexto").GetComponent<Text>();
    }

   public void mostrar(float num)
    {
        vistaTexto.text = num + "";
    }
}
