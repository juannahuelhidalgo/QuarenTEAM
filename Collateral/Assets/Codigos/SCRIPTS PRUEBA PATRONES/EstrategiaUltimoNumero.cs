using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstrategiaUltimoNumero : EstrategiaInterface
{
   public float calcular(ArrayList numeros)
    {
        int indice = numeros.Count;
        return (float)numeros[indice-1];
    }
}
