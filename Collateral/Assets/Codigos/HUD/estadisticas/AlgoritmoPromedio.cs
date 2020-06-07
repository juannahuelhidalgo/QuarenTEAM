using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgoritmoPromedio : Algoritmo
{
    public float Calcular(int[] respTomadas, int lugarArray, int correctas)
    {
        return (float)(correctas/(lugarArray+1));
    }
}
