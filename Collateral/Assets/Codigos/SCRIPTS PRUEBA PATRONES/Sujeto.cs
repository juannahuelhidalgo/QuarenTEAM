using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Sujeto : SujetoInterface
{
    ArrayList observadores = new ArrayList();
    float numeroamostrar = 0;
    EstrategiaInterface metodo = new EstrategiaUltimoNumero();
    ArrayList numerosMetidos = new ArrayList();

    public void suscribir(ObserverInterface nuevo)
    {
        observadores.Add(nuevo);
    }
    public void desuscribir(ObserverInterface sacar)
    {
        int numSac = observadores.IndexOf(sacar);
        if (numSac >= 0)
        {
            observadores.Remove(numSac);
        }

    }

    public void notificar()
    {

        for (int i = 0; i < observadores.Count; i++)
        {

            ObserverInterface notificado = (ObserverInterface)observadores[i];
            notificado.actualizar(numeroamostrar);
        }

    }

    public void nuevoNumero(float n)
    {
        numerosMetidos.Add(n);
    }

    public void actualizar(float num)
    {
        nuevoNumero(num);
        numeroamostrar = metodo.calcular(numerosMetidos);
        notificar();
    }
   
    /*public int getNota()
    {
        return numeroamostrar;
    }*/

    public void setEstrategia(EstrategiaInterface nueva)
    {
        metodo = nueva;
        numeroamostrar = metodo.calcular(numerosMetidos);
        notificar();

    }
}
