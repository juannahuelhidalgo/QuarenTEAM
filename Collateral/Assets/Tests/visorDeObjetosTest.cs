using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

namespace Tests
{
    public class visorDeObjetosTest
    {
        private GameObject juego;
        private visorDeObjetos visor;
        [SetUp]
        public void Setup()
        {
            // Use the Assert class to test conditions
            juego = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Escenas/Juego"));
            visor = GameObject.Find("Documento").GetComponent<visorDeObjetos>();
        }
        [UnityTest]
        public IEnumerator viewDocumentTest()
        {
            Vector3 posicionPrevia = GameObject.Find("CamaraDocumentos").transform.position;
            visor.viewDocument();
            visor.previousView();
            Assert.AreEqual(GameObject.Find("CamaraDocumentos").transform.position, posicionPrevia);
            yield return null;
        }

        [UnityTest]
        public IEnumerator previousViewTest()
        {
            
            visor.viewDocument();
            Vector3 posicionPrevia = GameObject.Find("CamaraDocumentos").transform.position;
            visor.previousView();
            visor.viewDocument();
            Assert.AreEqual(GameObject.Find("CamaraDocumentos").transform.position, posicionPrevia);
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

