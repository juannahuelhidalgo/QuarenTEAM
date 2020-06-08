using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgoritmoUltimaDesicion : Algoritmo
{
    public float Calcular(int[] respTomadas, int lugarArray, int correctas)
    {
        return (float)respTomadas[lugarArray];
    }
}
