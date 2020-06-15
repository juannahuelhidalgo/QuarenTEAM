using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.ExceptionServices;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class AdministradorDocumentosTest
    {
        private AdministradorDocumentos adminDOC;
        private GameObject juego;


        // A Test behaves as an ordinary method
        [SetUp]
        public void Setup()
        {
            juego = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Escenas/Juego"));
            adminDOC = GameObject.Find("Documento").GetComponent<AdministradorDocumentos>();
        }

        //Este test se fija que se modifiquen el nombre del paciente en el CanvasDocumentos, cada vez que se genere un paciente. Ya que este es el unico campo que ningun paciente puede tener en común
        [UnityTest]
        public IEnumerator generarDocumentoTest()
        {
            string nombrePrevio = GameObject.Find("RespNombre").GetComponent<Text>().text;

            yield return new WaitForSeconds(1);
            adminDOC.generarDocumento();

            string nombreActual = GameObject.Find("RespNombre").GetComponent<Text>().text;

            Assert.IsFalse(nombrePrevio.Equals(nombreActual));
            yield return null;
        }

        //Este test comprueba que los canvas se desactiven cuando no los esta viendo el usuario
        [UnityTest]
        public IEnumerator mirandoTest()
        {
            bool ResultadoTest = true;
            adminDOC.mirando(false);
            if (GameObject.Find("CanvasDocumentos").GetComponent<Canvas>().enabled.Equals(false) || GameObject.Find("CanvasRestricciones").GetComponent<Canvas>().enabled.Equals(false) || GameObject.Find("CanvasDesicion").GetComponent<Canvas>().Equals(false))
                ResultadoTest = false;
            Assert.IsFalse(ResultadoTest);
            yield return null;
        }


        [TearDown]
        public void Teardown()
        {
            GameObject.Destroy(juego);
        }
    }
}

