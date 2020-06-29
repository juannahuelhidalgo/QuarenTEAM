using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Tests
{
    public class BarraTest
    {
        GameObject controlador;
        Barra bar;

        //Aqui se pondra lo que se inicia/instancia con el comienzo de cada test
        [SetUp]
        public void Setup()
        {
            SceneManager.LoadScene(1);
  
        }

        [UnityTest]
        public IEnumerator metodoTextoTest()
        {
            controlador = GameObject.FindWithTag("control");
            bar = (Barra)controlador.GetComponent<Controller>().getBarra();
            float numeroOriginal = bar.getNumeroALlenar();
            bar.mostrar(0.5f);
            float numeroFinal = bar.getNumeroALlenar();
            Assert.AreNotEqual(numeroOriginal, numeroFinal);
            yield return null;
        }


        [TearDown]
        public void Teardown()
        {
            //Se destruyen los objetos 
           // GameObject.Destroy(controlador);

        }
    }

}