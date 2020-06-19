using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Comunicacion 
{
    void nuevaDesicion(int resp);
    void setEstrategia(Algoritmo nuevo);
}
