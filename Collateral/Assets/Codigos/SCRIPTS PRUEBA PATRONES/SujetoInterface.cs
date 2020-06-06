using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SujetoInterface 
{
    void suscribir(ObserverInterface nuevo);
    void desuscribir(ObserverInterface sacar);
    void notificar();
}
