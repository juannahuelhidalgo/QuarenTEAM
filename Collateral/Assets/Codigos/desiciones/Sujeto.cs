using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Sujeto 
{
    void suscribir(Observador nuevo);
    void desuscribir(Observador sacar);
    void notificar();
}
