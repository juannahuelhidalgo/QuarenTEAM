using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
//comentario 
public class menuPrinc : MonoBehaviour
{
    public static int semana = -2;
    public bool EsMenu = false;
    public static int final = 5;
    public Texture2D[] frames0;
    public Texture2D[] frames1;
    public Texture2D[] frames2;
    public Texture2D[] frames3;
    public Texture2D[] frames4;
    public Texture2D[] frames5;
    public double fps;
    public static bool fin = false;


    void Update()
    {
        if (semana <= final) StartCoroutine(mostrar());

    }

    void Start()
    {
        cambioSemana();
    }

    public int getFinal()
    {
        return final;
    }


    public int semanaActual()
    {
        return semana;
    }

    public void cambioSemana()
    {
        if (semana < final)
        {
            semana++;
        }
        else { finTrans(); }

    }

    public bool finTrans()
    {
        if (semana < final) { return fin; }
        else { return (fin = true); }
    }


    public bool esMenu()
    {
        return EsMenu;
    }

    IEnumerator mostrar()
    {

       // Debug.Log("estoy en el switch semana= " + semana);
        int indice = (int)(Time.time * fps % frames1.Length);
        int indiceMenu = (int)(Time.time * fps % frames0.Length);
        if (EsMenu == true)
        {
            GetComponent<RawImage>().texture = frames0[indiceMenu];
            yield return new WaitForSeconds(10);
        }
        if (EsMenu == false) {
            switch (semana)
            {
                case 0:
                    int index = (int)(Time.time * fps % frames0.Length);
                    //  Debug.Log("cargue el entero de los fps");
                    GetComponent<RawImage>().texture = frames0[index];
                    //   Debug.Log("tome el array correspondiente");
                    yield return new WaitForSeconds(10);
                    Debug.Log("semana = " + semana);
                    //  Debug.Log("salgo del switch ");
                    break;
                case 1:
                    GetComponent<RawImage>().texture = frames1[indice];
                    yield return new WaitForSeconds(10);
                    Debug.Log("semana = " + semana);
                    break;
                case 2:
                    GetComponent<RawImage>().texture = frames2[indice];
                    yield return new WaitForSeconds(10);

                    Debug.Log("semana = " + semana);
                    break;
                case 3:
                    GetComponent<RawImage>().texture = frames3[indice];
                    yield return new WaitForSeconds(10);
                    Debug.Log("semana = " + semana);
                    break;
                case 4:
                    GetComponent<RawImage>().texture = frames4[indice];
                    yield return new WaitForSeconds(10);
                    Debug.Log("semana = " + semana);
                    break;
                case 5:
                    GetComponent<RawImage>().texture = frames5[indice];
                    yield return new WaitForSeconds(10);
                    Debug.Log("semana = " + semana);
                    break;
            }

        }
    }
           

}

