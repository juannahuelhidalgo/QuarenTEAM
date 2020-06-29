using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TestsDeIntegracion
{
    public class AlgoritmosIntegracionTest
    {
        //GameObject controlador;
        GameObject juego;
        //Aqui se pondra lo que se inicia/instancia con el comienzo de cada test
        [SetUp]
        public void Setup()
        {
            SceneManager.LoadScene(1);
            //juego = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Escenas/Juego"));
            
           


        }

        [UnityTest]
        public IEnumerator algoritmoPromedioTest()
        {
            GameObject.Find("mostrarPacientes").GetComponent<AdministradorDesiciones>().setearValoresOriginales();
            yield return new WaitForSeconds(10f);
            GameObject controlador = GameObject.FindWithTag("control");
            Texto tex = (Texto)controlador.GetComponent<Controller>().getTexto();
            string textoAnterior = tex.getTextoAMostrar();
            controlador.GetComponent<Controller>().TomarDesicion(0);
            controlador.GetComponent<Controller>().TomarDesicion(1);
            controlador.GetComponent<Controller>().setAlgoritmoPromedio();
            string textomostrado = tex.getTextoAMostrar();
            yield return new WaitForSeconds(5f);
            Assert.AreNotEqual(textomostrado, textoAnterior);
            yield return null;

        }

        [UnityTest]
        public IEnumerator algoritmoUltimaDecision()
        {
            GameObject.Find("mostrarPacientes").GetComponent<AdministradorDesiciones>().setearValoresOriginales();
            GameObject controlador = GameObject.FindWithTag("control");
            controlador.GetComponent<Controller>().TomarDesicion(0);
            controlador.GetComponent<Controller>().TomarDesicion(1);
            controlador.GetComponent<Controller>().setAlgoritmoUltimaDesicion();
            Texto tex = (Texto)controlador.GetComponent<Controller>().getTexto();
            string textomostrado = tex.getTextoAMostrar();
            yield return new WaitForSeconds(5f);
            Assert.AreEqual(textomostrado, "1");
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