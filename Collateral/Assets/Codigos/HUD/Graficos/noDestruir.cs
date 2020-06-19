using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class noDestruir : MonoBehaviour
{
    public static string[] nombreModelos = new string[2];
    private void Awake()
    {
        nombreModelos[0] = "UltimaDesicion";
        nombreModelos[1] = "Promedio";
    }


    private void Update()
    {
        if (!(SceneManager.GetActiveScene().buildIndex == 2) && (gameObject.GetComponent<Canvas>().enabled != false))
            gameObject.GetComponent<Canvas>().enabled = false;
       
        if (SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (GameObject.Find("modelo").GetComponent<Text>().text == nombreModelos[UltimoValor.ultimaDesicion])
            {
                gameObject.GetComponent<Canvas>().enabled = false;
                gameObject.GetComponent<Canvas>().enabled = true;
            }
            GameObject.Find("modelo").GetComponent<Text>().text = nombreModelos[UltimoValor.ultimaDesicion];
        }
    }
}
