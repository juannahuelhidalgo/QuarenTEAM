using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminRestricciones : MonoBehaviour
{
    int semanaActual;
    GameObject restriccion;
    // Start is called before the first frame update
    GameObject Juego;
    adminJuego admin;
    void Start()
    {
        Juego = GameObject.Find("adminJuegos");
        admin = Juego.GetComponent<adminJuego>();
        semanaActual = admin.getSemanaActual()+1;
        setRestricciones();
    }

    
    public void setRestricciones()
    {
         for(int i=1;i<=5;i++)
         {
             if(i != semanaActual)
             {
                // UnityEngine.Debug.Log("Entre al if ya que i= " + i + " es igual a la semana: " + semanaActual);
                 string nombre = "Semana" + i;
               // UnityEngine.Debug.Log(nombre);
                restriccion = GameObject.Find(nombre);
                 restriccion.SetActive(false);
             }
         }
        
    }
}
