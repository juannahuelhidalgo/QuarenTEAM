using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class TestDocumentos
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

        [UnityTest]
        public IEnumerator TestCambioPaciente()
        {
            Debug.Log("Entre al test cambioPaciente");
            string original;
            string nuevo;
            yield return new WaitForSeconds(1);
            original = GameObject.Find("RespNombre").GetComponent<Text>().text;
            Debug.Log(original);
            adminDOC.generarDocumento();
            nuevo = GameObject.Find("RespNombre").GetComponent<Text>().text;
            Debug.Log(nuevo);
            Assert.AreNotEqual(original, nuevo);
            yield return null;
        }

        [TearDown]
        public void Teardown()
        {
            GameObject.Destroy(juego);
        }
    }
}
