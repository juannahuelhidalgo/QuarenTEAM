using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class disparadorDeEventosTest
    {
        //GameObject juego;
        //disparadorDeEventos eventos;

        [SetUp]
        public void Setup()
        {
            // Use the Assert class to test conditions
            //juego = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Escenas/Juego"));
            SceneManager.LoadScene(1);
           
        }

        [UnityTest]
        public IEnumerator MostrarDocumentoTest()
        {
            disparadorDeEventos eventos = GameObject.Find("Documento").GetComponent<disparadorDeEventos>();
            eventos.MostrarDocumento(true);

            bool checkeo = eventos.GetComponent<MeshRenderer>().enabled;
            yield return new WaitForSeconds(0.1f);
            Assert.IsTrue(checkeo);

            yield return null;
        }

        [UnityTest]
        public IEnumerator LlegoDocumentoTest()
        {
            disparadorDeEventos eventos = GameObject.Find("Documento").GetComponent<disparadorDeEventos>();
            eventos.LlegoDocumento();
            bool checkeo = eventos.GetComponent<MeshRenderer>().enabled;
            yield return new WaitForSeconds(0.1f);
            Assert.IsTrue(checkeo);

            yield return null;

        }
        [UnityTest]
        public IEnumerator SePuedeVerTest()
        {
            disparadorDeEventos eventos = GameObject.Find("Documento").GetComponent<disparadorDeEventos>();
            eventos.SePuedeVer(false);
            yield return new WaitForSeconds(0.1f);
            Assert.IsFalse(eventos.sePuedeVer);

            yield return null;
        }

        [UnityTest]
        public IEnumerator EnfermeroSeVaTest()
        {
            disparadorDeEventos eventos = GameObject.Find("Documento").GetComponent<disparadorDeEventos>();
            yield return new WaitForSeconds(5f);
            eventos.EnfermeroSeVa();
            yield return new WaitForSeconds(2f);
            bool checkeo = eventos.GetComponent<MeshRenderer>().enabled;
            Assert.IsFalse(checkeo);


            yield return null;
        }

        [TearDown]
        public void Teardown()
        {
            //GameObject.Destroy(juego.gameObject);
        }
    }
}