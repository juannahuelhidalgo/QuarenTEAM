using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class admJuegoTEST
    {
        private GameObject adminJuego;
        private adminJuego admin;
        private int EscenaInicial;
        private int EscenaFinal;
        private int valorEsperado;

        [SetUp]
        public void SetupAdministradorDeEscena()
        {
            adminJuego = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/AdministradorJuego/adminJuegos"));
            admin = adminJuego.GetComponent<adminJuego>();

        }

        //1
        //Se verificara si cambia de escena
        [UnityTest]
        public IEnumerator TestEscenaSiguiente()
        {
            admin.setCargarEscena(1);                                              //CargaLaEscena1 correspondiente a la del juego, porque sino carga una escena creada para el test 
            yield return new WaitForSeconds(2);
            adminJuego = GameObject.Find("adminJuegos");                        //De igual forma que al principio como ahora cambie de escena tengo que setear de nuevo los objetos
            admin = adminJuego.GetComponent<adminJuego>();
            EscenaInicial = admin.getNumeroEscenaActual();                      //Toma el valor de la escena que cargue
            Debug.Log("La escena inicial es: " + EscenaInicial);
            admin.cargarEscenaSiguiente();                                      //Ejecuto el metodo EscenaSiguiente    
            yield return new WaitForSeconds(2);
            adminJuego = GameObject.Find("adminJuegos");                        //De igual forma que al principio como ahora cambie de escena tengo que setear de nuevo los objetos
            admin = adminJuego.GetComponent<adminJuego>();
            Debug.Log("EjecuteElCambioDeEscena");
            EscenaFinal = admin.getNumeroEscenaActual();                        //Tomo el valor de la escena en la que estoy
            Debug.Log("La escena final es: " + EscenaFinal);
            Assert.AreEqual(EscenaInicial + 1, EscenaFinal);                    //Hace la comparacion

            yield return null;
        }

        [UnityTest]
        public IEnumerator TestEscenaAnterior()
        {
            admin.setCargarEscena(1);                                              //CargaLaEscena1 correspondiente a la del juego, porque sino carga una escena creada para el test 
            yield return new WaitForSeconds(2);
            adminJuego = GameObject.Find("adminJuegos");                        //Ahora mi adminEscena tienen que ser los objetos de la escena que acabo de cargar
            admin = adminJuego.GetComponent<adminJuego>();
            EscenaInicial = admin.getNumeroEscenaActual();                      //Toma el valor de la escena que cargue
            Debug.Log("La escena inicial es: " + EscenaInicial);
            admin.cargarEscenaAnterior();                                       //Ejecuto el metodo EscenaAnterior    
            yield return new WaitForSeconds(2);
            adminJuego = GameObject.Find("adminJuegos");                        //De igual forma que al principio como ahora cambie de escena tengo que setear de nuevo los objetos
            admin = adminJuego.GetComponent<adminJuego>();
            Debug.Log("EjecuteElCambioDeEscena");
            EscenaFinal = admin.getNumeroEscenaActual();                        //Tomo el valor de la escena en la que estoy
            Debug.Log("La escena final es: " + EscenaFinal);
            Assert.AreEqual(EscenaInicial - 1, EscenaFinal);
            yield return null;
        }

        [UnityTest]
        public IEnumerator TestSumarSemana()
        {
            //se toma la semana pasada
            int semanaPasada = admin.getSemanaActual();
            //se suma una semana
            admin.sumarSemana();

            //se compara si la semana actual es mayor a la anterior
            Assert.Greater(admin.getSemanaActual(), semanaPasada);
            yield return null;
        }


        [UnityTest]
        public IEnumerator TestStart()
        {
            //se conoce si el build de escena esta hecho
            Assert.IsTrue(admin.getBuideado());
            yield return null;
        }

        [UnityTest]
        public IEnumerator TestCerrado()
        {
            //se comprueba si el juego es cerrado correctamente
            admin.cerrarJuego();
            Assert.IsTrue(admin.getCerrado());
            yield return null;
        }

        [TearDown]
        public void Teardown()
        {

            GameObject.Destroy(admin);
            GameObject.Destroy(adminJuego);
        }
    }
}
