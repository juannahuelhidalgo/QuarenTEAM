using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguidorDeMouse : MonoBehaviour
{
    string objectUnderMouse;


    void Update()
    {
        //nos crea un rayo utilizando dos puntos, la posición de la camara y la posición del mouse sobre el plano que muestra la camara
        StartCoroutine("PasarSemana");
        Ray ray = GameObject.Find("CamaraDocumentos").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        //RaycastHit nos permite acceder a informacion con respecto al objeto con el cual el rayo colisiono
        RaycastHit hitData;
        //Physics.Raycast(ray, out hitData) devuelve true si el rayo choca con un colider
        if (Physics.Raycast(ray, out hitData))
        {
            //guarda en el campo la posicion del mouse en este frame
            objectUnderMouse = hitData.transform.name;
        }
    }

    IEnumerator PasarSemana()
    {

        yield return new WaitForSeconds(10);       
    }


    //devuelve el nombre del objeto que este debajo del mouse
    public string getObjectUnder()
    {
        return objectUnderMouse;
    }

}
