using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Torta : Observador
{
    static Sujeto mirar;
    private static Image grafico;

    public Torta(Sujeto miralo)
    {
        mirar = miralo;
        mirar.suscribir(this);
        grafico = GameObject.FindWithTag("rellenoGrafTorta").GetComponent<Image>();

    }

    public void mostrar(float llenado)
    {
        if (llenado >= 0 && llenado <= 1)
        {
            grafico.fillAmount = llenado;
        }
        else
            Debug.Log("Valor de llenado fuera de rango");
    }
}
