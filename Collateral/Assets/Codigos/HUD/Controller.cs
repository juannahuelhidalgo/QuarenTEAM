using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    static AdministradorDesiciones administrador;
    static Observador texto;
    static AlgoritmoUltimaDesicion ultima = new AlgoritmoUltimaDesicion();
    static AlgoritmoPromedio promedio = new AlgoritmoPromedio();
    // Start is called before the first frame update


    void Start()
    {
        administrador = GameObject.Find("mostrarPacientes").GetComponent<AdministradorDesiciones>(); //Se determina el sujeto del patron
        texto = new Texto(administrador); //Determino uno de los observers, en este caso el que muestra por texto.
        
    }

   public void TomarDesicion(int resp)
    {
        administrador.nuevaDesicion(resp);
    }

    public void setAlgoritmoUltimaDesicion()
    {
        administrador.setEstrategia(ultima);
    }

    public void setAlgoritmoPromedio()
    {
        administrador.setEstrategia(promedio);
    }
}
