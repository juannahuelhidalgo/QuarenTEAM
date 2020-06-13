using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

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

            juego = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Escenas/Juego"));

            admin = GameObject.Find("CanvasRestricciones").GetComponent<AdminRestricciones>();
        }

        [UnityTest]
        public IEnumerator setRestriccionesTest()
        {
            bool ResultadoTest = true;
            int i = GameObject.Find("adminJuegos").GetComponent<adminJuego>().getSemanaActual();
            string semanaActual = "Semana" + i;
            // UnityEngine.Debug.Log(nombre);
        
            //GameObject.Find("CanvasRestricciones").GetComponent<Canvas>().enabled = true;
            yield return new WaitForSeconds(3f);
            
            admin.setRestricciones();
            /*for(int j=1; j<5; j++)
            {
                string semana = "Semana" + j;
                if (j != i)
                    if (GameObject.Find(semana).active)
                        ResultadoTest = false;
            }
            if (!GameObject.Find(semanaActual).active)
                ResultadoTest = false;

            Assert.IsTrue(ResultadoTest);*/
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