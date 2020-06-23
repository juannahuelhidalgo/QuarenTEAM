using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Tests
{
    public class TextoTest
    {
        GameObject controlador;
        Texto tex;

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
            tex = (Texto)controlador.GetComponent<Controller>().getTexto();
            string textooriginal = tex.getTextoAMostrar();
            tex.mostrar(0.5f);
            string textofinal = tex.getTextoAMostrar();
            Assert.AreEqual("0,5", textofinal);
            yield return null;
        }


        [TearDown]
        public void Teardown()
        {
            //Se destruyen los objetos 
            //GameObject.Destroy(controlador);

        }
    }

}