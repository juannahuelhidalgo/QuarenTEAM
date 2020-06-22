using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TestsDeIntegracion
{
    public class GraficosIntegracionTest
    {
        GameObject controlador;
        GameObject juego;
        //Aqui se pondra lo que se inicia/instancia con el comienzo de cada test
        [SetUp]
        public void Setup()
        {
            juego = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Escenas/Juego"));
            //SceneManager.LoadScene(1);
            
        }

        [UnityTest]
        public IEnumerator vistaUltimaDecisionTextoTest()
        {
            GameObject.Find("mostrarPacientes").GetComponent<AdministradorDesiciones>().setearValoresOriginales();
            controlador = GameObject.FindWithTag("control");
            controlador.GetComponent<Controller> ().TomarDesicion(0);
            Texto tex = (Texto)controlador.GetComponent<Controller>().getTexto();
            string textomostrado = tex.getTextoAMostrar();
            yield return new WaitForSeconds(0.1f);
            Assert.AreEqual(textomostrado, "0");
            yield return null;
        }

        [UnityTest]
        public IEnumerator vistaUltimaDecisionBarraTest()
        {
            controlador = GameObject.FindWithTag("control");
            controlador.GetComponent <Controller>().TomarDesicion(0);
            Barra bar = (Barra)controlador.GetComponent<Controller>().getBarra();
            float llenar = bar.getNumeroALlenar();
            yield return new WaitForSeconds(0.1f);
            Assert.AreEqual(llenar, 0.0f);
            yield return null;
        }



        [TearDown]
        public void Teardown()
        {
            //Se destruyen los objetos 
            GameObject.Destroy(juego.gameObject);

        }
    }

}