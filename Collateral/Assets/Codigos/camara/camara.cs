using UnityEngine;
using System.Collections;

public class camara : MonoBehaviour
{
    GameObject uno;
    GameObject dos;
    GameObject tres;
    GameObject AdmJuego;
    adminJuego juego;
    bool hola = false;

    void Awake()
    {
        AdmJuego = GameObject.Find("adminJuegos");
        juego = AdmJuego.GetComponent<adminJuego>();

        uno = GameObject.FindWithTag("camarauno");
        dos = GameObject.FindWithTag("camarados");
        tres = GameObject.FindWithTag("camaratres");

    }

    void Start()
    {
        camara1();
    }

    void camara1() {
        uno.SetActive(true);
        dos.SetActive(false);
        tres.SetActive(false);
        StartCoroutine("PasarCamara");
        Debug.Log("voy a camara2");
    }
    
    void camara2()
    {
        uno.SetActive(false);
        dos.SetActive(true);
        tres.SetActive(false);
        StartCoroutine("PasarCamara2");
        Debug.Log("voy a camara3");
    }

    void camara3()
    {
        uno.SetActive(false);
        dos.SetActive(false);
        tres.SetActive(true);
        StartCoroutine("PasarCamara3");
        Debug.Log("ready?");
    }

    IEnumerator PasarCamara()
    {
        yield return new WaitForSeconds(7.3f);
        camara2();
        Debug.Log("en el enum1");
    }

    IEnumerator PasarCamara2()
    {      
        yield return new WaitForSeconds(7.5f);
        camara3();
        Debug.Log("en el enum2");
    }
    IEnumerator PasarCamara3()
    {
        yield return new WaitForSeconds(7.5f);
        Debug.Log("en el enum3");
    }
}
