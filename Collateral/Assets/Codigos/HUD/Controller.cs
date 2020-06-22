using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    static Comunicacion administrador;
    static Observador texto;
    static Observador barra;
    static Observador torta;
    static AlgoritmoUltimaDecision ultima = new AlgoritmoUltimaDecision();
    static AlgoritmoPromedio promedio = new AlgoritmoPromedio();
    bool tomarDesicion = false;
    bool setAlgoritmo = false;
    // Start is called before the first frame update


    void Start()
    {
        administrador = GameObject.Find("mostrarPacientes").GetComponent<AdministradorDesiciones>(); //Se determina el sujeto del patron
        texto = new Texto((Sujeto)administrador); //Determino uno de los observers, en este caso el que muestra por texto.
        barra = new Barra((Sujeto)administrador);
        torta = new Torta((Sujeto)administrador);

    }

    public void TomarDesicion(int resp)
    {
        tomarDesicion = true;
        administrador.nuevaDesicion(resp);
    }

    public void setAlgoritmoUltimaDesicion()
    {
        setAlgoritmo = true;
        administrador.setEstrategia(ultima);
        UltimoValor.ultimaDesicion = 0;
    }

    public void setAlgoritmoPromedio()
    {
        setAlgoritmo = true;
        administrador.setEstrategia(promedio);
        UltimoValor.ultimaDesicion = 1;
    }

    public Observador getTexto()
    {
        return texto;
    }

    public Observador getBarra()
    {
        return barra;
    }

    public bool getTomarDesicion()
    {
        return tomarDesicion;
    }

    public bool getAlgoritmo()
    {
        return setAlgoritmo;
    }
}