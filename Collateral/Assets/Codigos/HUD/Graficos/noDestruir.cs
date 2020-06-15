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
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            DontDestroyOnLoad(gameObject);
            Debug.Log("Evite la destruccion del obj");
        }
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            GameObject.Find("modelo").GetComponent<Text>().text = nombreModelos[UltimoValor.ultimaDesicion];
            gameObject.GetComponent<Canvas>().enabled = false;
            gameObject.GetComponent<Canvas>().enabled = true;

        }
        else
            gameObject.GetComponent<Canvas>().enabled = false;
    }
    
}
