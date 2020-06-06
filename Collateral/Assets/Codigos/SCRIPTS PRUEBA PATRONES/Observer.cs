using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Observer : ObserverInterface
{
    SujetoInterface mirar;
    Text numero;

    public Observer(SujetoInterface miralo)
    {
        mirar = miralo;
        miralo.suscribir(this);
        numero = GameObject.FindWithTag("Numero").GetComponent<Text>();
    }

    public void actualizar(float numeroamostrar)
    {

        numero.text = numeroamostrar + "";
    }
}
