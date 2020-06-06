using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuevoAdmin : MonoBehaviour
{
    static Sujeto sujeto;
    static ObserverInterface observador;

    void Start()
    {
        sujeto = new Sujeto();
        observador = new Observer(sujeto);
    }

    public void seApretoBoton(int num)
    {
        sujeto.actualizar(num);
    }

    public void seEligeUltimoNumer()
    {
        sujeto.setEstrategia(new EstrategiaUltimoNumero());
    }
    public void seEligePromedio()
    {
        sujeto.setEstrategia(new EstrategiaPromedio());
    }

}
