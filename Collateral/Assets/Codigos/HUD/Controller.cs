using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    AdministradorDesiciones administrador;
    Observador texto;
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
        administrador.setEstrategia(new AlgoritmoUltimaDesicion());
    }

    public void setAlgoritmoPromedio()
    {
        administrador.setEstrategia(new AlgoritmoPromedio());
    }
}
