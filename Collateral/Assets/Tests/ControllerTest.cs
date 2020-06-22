using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Tests
{
    public class ControllerTest
    {
        GameObject controlador;
        GameObject juego;
        //Aqui se pondra lo que se inicia/instancia con el comienzo de cada test
        [SetUp]
        public void Setup()
        {
            juego = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Escenas/Juego"));
            //SceneManager.LoadScene(1);
            controlador = GameObject.FindWithTag("control");
        }

        [UnityTest]
        public IEnumerator setTomarDesicionTest()
        {
            controlador.GetComponent<Controller>().TomarDesicion(0);
            bool setomodesicion = controlador.GetComponent <Controller> ().getTomarDesicion();
            yield return new WaitForSeconds(0.1f);
            Assert.IsTrue(setomodesicion);
            yield return null;
        }

        [UnityTest]
        public IEnumerator setAlgoritmoPromedioTest()
        {
            controlador.GetComponent <Controller>().TomarDesicion(0);
            controlador.GetComponent <Controller> ().setAlgoritmoPromedio();
            bool setAlgoritmo = controlador.GetComponent <Controller>().getAlgoritmo();
            yield return new WaitForSeconds(0.1f);
            Assert.IsTrue(setAlgoritmo);
            yield return null;
        }

        [UnityTest]
        public IEnumerator setAlgoritmoUltimaDesicionTest()
        {
            controlador.GetComponent <Controller>().setAlgoritmoUltimaDesicion();
            bool setAlgoritmo = controlador.GetComponent <Controller>().getAlgoritmo();

            yield return new WaitForSeconds(0.1f);
            Assert.IsTrue(setAlgoritmo);
            yield return null;
        }

        [TearDown]
        public void Teardown()
        {
            //Se destruyen los objetos 
           // GameObject.Destroy(controlador);
            GameObject.Destroy(juego.gameObject);

        }
    }

}
