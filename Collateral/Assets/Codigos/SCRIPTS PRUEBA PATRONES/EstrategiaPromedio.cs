using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstrategiaPromedio : EstrategiaInterface
{
    public float calcular(ArrayList numeros)
    {
        float suma=0;
        
        for(int i=0; i<numeros.Count;i++)
        {
            suma = suma + (float)numeros[i];
        }

        return (suma / numeros.Count);
    }
}
