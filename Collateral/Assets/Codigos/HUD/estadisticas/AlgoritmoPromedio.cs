using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AlgoritmoPromedio : Algoritmo
{
    public float Calcular(int[] respTomadas, int lugarArray, int correctas)
    {
        float correctastotales = (float)correctas;

        float numero = correctastotales / (lugarArray + 1);

        return (float) System.Math.Round(numero,2);
        
    }
}
