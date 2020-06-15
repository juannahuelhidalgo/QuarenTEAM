using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Tests
{
    public class AdminRestriccionesTest
    {
        GameObject juego;
        AdminRestricciones admin;

        //Aqui se pondra lo que se inicia/instancia con el comienzo de cada test
        [SetUp]
        public void Setup()
        {
            SceneManager.LoadScene(0);
            //juego = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Escenas/Juego"));

            //admin = GameObject.Find("CanvasRestricciones").GetComponent<AdminRestricciones>();
        }

        [UnityTest]
        public IEnumerator setRestriccionesTest()
        {
            //Arranco el juego desde el menu y cambio la escena como lo haria el jugador, para ir al juego
            GameObject.Find("adminJuegos").GetComponent<adminJuego>().cargarEscenaSiguiente();
            yield return new WaitForSeconds(1f);
            
            bool ResultadoTest = true;
              int i = GameObject.Find("adminJuegos").GetComponent<adminJuego>().getSemanaActual();
              string semanaActual = "Semana" + (i+1);
            yield return new WaitForSeconds(1f);
            /*
            for (int j = 1; j < 5; j++)
            {
                string semana = "Semana" + j;
                if (GameObject.Find(semana) == null)
                    Debug.Log(semana + " el gameobject no esta activo");
                else
                Debug.Log(GameObject.Find(semana).GetComponent<Text>().text);
            }*/
             for (int j = 1; j < 6; j++)
             {
                 string semana = "Semana" + j;
                 
                 if (j != (i+1))
                 {
                    Debug.Log(semana);

                    if (!(GameObject.Find(semana) == null))
                         ResultadoTest = false;
                 }
             }
                 if (GameObject.Find(semanaActual) == null)
                    if (!GameObject.Find(semanaActual).active)
                        ResultadoTest = false;
                     
             Assert.IsTrue(ResultadoTest);
            yield return null;
        }

        [TearDown]
        public void Teardown()
        {
            //Se destruyen los objetos 
            GameObject.Destroy(juego);

        }
    }

}