using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TestsDeIntegracion
{
    public class DesicionesIntegracionTest
    {
        GameObject controlador;
        GameObject gameGameObject;
        AdministradorDesiciones adm;
        //GameObject juego;
        //Aqui se pondra lo que se inicia/instancia con el comienzo de cada test
        [SetUp]
        public void Setup()
        {
            SceneManager.LoadScene(1);
            //juego = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Escenas/Juego"));

           
        }

        [UnityTest]
        public IEnumerator tomarDesicionCorrectaIntegracion()
        {
            controlador = GameObject.FindWithTag("control");
            gameGameObject = GameObject.Find("mostrarPacientes");
            adm = gameGameObject.GetComponent<AdministradorDesiciones>();
            GameObject.Find("mostrarPacientes").GetComponent<AdministradorDesiciones>().setearValoresOriginales();
            int correctasinicial = adm.getCorrectas();
            controlador.GetComponent <Controller>().TomarDesicion(0);
            int correctasfinal = adm.getCorrectas();
            yield return new WaitForSeconds(0.1f);
            Assert.Greater(correctasfinal, correctasinicial);
            yield return null;

        }

        [UnityTest]
        public IEnumerator tomarDesicionInorrectaIntegracion()
        {
            controlador = GameObject.FindWithTag("control");
            gameGameObject = GameObject.Find("mostrarPacientes");
            adm = gameGameObject.GetComponent<AdministradorDesiciones>();
            GameObject.Find("mostrarPacientes").GetComponent<AdministradorDesiciones>().setearValoresOriginales();
            int incorrectasinicial = adm.getIncorrectas();
            controlador.GetComponent <Controller>().TomarDesicion(1);
            int incorrectasfinal = adm.getIncorrectas();
            yield return new WaitForSeconds(0.1f);
            Assert.Greater(incorrectasfinal, incorrectasinicial);
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