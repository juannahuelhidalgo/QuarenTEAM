using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barra : Observador
{
    static Sujeto mirar;
    private static Image grafico;

    public Barra(Sujeto miralo)
    {
        mirar = miralo;
        mirar.suscribir(this);
        if (GameObject.FindWithTag("desempenio") != null)
        grafico = GameObject.FindWithTag("desempenio").GetComponent<Image>();

    }

    public void mostrar(float llenado)
    {
        if (llenado >= 0 && llenado <= 1)
            grafico.fillAmount = llenado;
        else
            Debug.Log("Valor de llenado fuera de rango");
    }
}
