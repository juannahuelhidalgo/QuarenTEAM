using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    static AdministradorDesiciones administrador;
    static Observador texto;
    static Observador barra;
    static Observador torta;
    static AlgoritmoUltimaDecision ultima = new AlgoritmoUltimaDecision();
    static AlgoritmoPromedio promedio = new AlgoritmoPromedio();
    // Start is called before the first frame update


    void Start()
    {
        administrador = GameObject.Find("mostrarPacientes").GetComponent<AdministradorDesiciones>(); //Se determina el sujeto del patron
        texto = new Texto(administrador); //Determino uno de los observers, en este caso el que muestra por texto.
        barra = new Barra(administrador);
        torta = new Torta(administrador);
        
    }

   public void TomarDesicion(int resp)
    {
        administrador.nuevaDesicion(resp);
    }

    public void setAlgoritmoUltimaDesicion()
    {
        administrador.setEstrategia(ultima);
        UltimoValor.ultimaDesicion = 0;
    }

    public void setAlgoritmoPromedio()
    {
        administrador.setEstrategia(promedio);
        UltimoValor.ultimaDesicion = 1;
    }
}
