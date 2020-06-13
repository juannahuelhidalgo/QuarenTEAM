using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class datosPacientesTest
    {
        private GameObject juego;
        private datosPacientes datos;
        // A Test behaves as an ordinary method
        [SetUp]
        public void Setup()
        {
            // Use the Assert class to test conditions
            juego = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Escenas/Juego"));
            datos = GameObject.Find("Documento").GetComponent<datosPacientes>();
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator generatePatientTest()
        {
            string[] inforPacienteAnterior = new string[6];
            string[] inforPacientesActual = new string[6];

            inforPacienteAnterior = datos.generatePatient();
            inforPacientesActual = datos.generatePatient();

            Assert.IsFalse(inforPacienteAnterior.Equals(inforPacientesActual));

            yield return null;
        }

        [TearDown]
        public void Teardown()
        {
            GameObject.Destroy(juego);
        }
    }
}
