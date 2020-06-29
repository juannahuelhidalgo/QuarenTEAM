using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TestsDeIntegracion
{
    public class AdministradorJuegoIntegracionTest
    {
        GameObject controlador;
        GameObject juego;
        //Aqui se pondra lo que se inicia/instancia con el comienzo de cada test
        [SetUp]
        public void Setup()
        {
           
           
            SceneManager.LoadScene(1);
           // juego = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Escenas/Juego"));
          // new WaitForSeconds(5f);
            


        }

        [UnityTest]
        public IEnumerator cambioDeEscenaIntegracionTest()
        {
            GameObject.Find("mostrarPacientes").GetComponent<AdministradorDesiciones>().setearValoresOriginales();
            yield return new WaitForSeconds(0.1f);
            controlador = GameObject.FindWithTag("control");
            int escenaPrevia = SceneManager.GetActiveScene().buildIndex;
            controlador.GetComponent<Controller>().TomarDesicion(0);
            controlador.GetComponent<Controller>().TomarDesicion(1);
            controlador.GetComponent<Controller>().TomarDesicion(1);
            yield return new WaitForSeconds(5f);
            int escenaActual = SceneManager.GetActiveScene().buildIndex;
            yield return new WaitForSeconds(0.1f);
            Assert.Greater(escenaActual, escenaPrevia);
            yield return null;
        }

        [TearDown]
        public void Teardown()
        {
            //Se destruyen los objetos 
            //GameObject.Destroy(juego.gameObject);

        }
    }

}