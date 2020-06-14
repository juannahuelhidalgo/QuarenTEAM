
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LlenadorGraficos : MonoBehaviour
{

    private Image grafico;

    private void Start()
    {
        //grafico = GameObject.Find("desempenio").GetComponent<Image>();
        //grafico = gameObject.GetComponent<Image>();
    }

    //llena el grafico, utilizando un numero entre 0 y 1, el cual representa el porcentaje de llenado. 
    public void llenar(float llenado)
    {
        if (llenado >= 0 && llenado <= 1)
            grafico.fillAmount = llenado;
        else
            Debug.Log("Valor de llenado fuera de rango");
    }
}

