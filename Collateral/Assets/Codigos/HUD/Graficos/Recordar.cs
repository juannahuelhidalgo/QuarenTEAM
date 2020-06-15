using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine;
public class Recordar : MonoBehaviour
{
    // Esta clase se engarga de que al entrar en la escena los graficos muestren de nuevo los ultimos valores que mostraban los modelos
    private void Start()
    {
        //si el ultimo modelo fue promedio, solo actualiza la torta
        if(UltimoValor.ultimaDesicion.Equals(1) && gameObject.name.Equals("rellenoGrafTorta"))
            gameObject.GetComponent<Image>().fillAmount = UltimoValor.ultimo;
        //si el ultimo modelo fue ultimaDesicion, todos los graficos se actualizan
        if (UltimoValor.ultimaDesicion.Equals(0))
            gameObject.GetComponent<Image>().fillAmount = UltimoValor.ultimo;


    }
}
