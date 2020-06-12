using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    [TestFixture]
    public class desicionesTEST
    {
        GameObject gameGameObject;
        // GameObject documentos;
        GameObject DOM;
        AdministradorDesiciones adm;
        //  AdministradorDocumentos admin;

        //Aqui se pondra lo que se inicia/instancia con el comienzo de cada test
        [SetUp]
        public void Setup()
        {
            //se instancia el juego correspondiente
            DOM = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Escenas/Juego"));
            Debug.Log("instancia 1");


            //se obtiene el codigo y el objeto asociado
            gameGameObject = GameObject.Find("mostrarPacientes");
            Debug.Log("instancia 2");
            adm = gameGameObject.GetComponent<AdministradorDesiciones>();
            Debug.Log("instancia 3");

        }

        //1
        //el metodo chequea si se estan almacenando correctamente las respuestas en base a controlar su veracidad
        [UnityTest]
        public IEnumerator TestDesicionesSi()
        {
            //supone una primer respuesta correcta
            int correcta = 1;
            //llama al metodo que decide
            adm.Si();
            //el metodo devuelve el valor de la respuesta en este caso incorrecta y por ende es 0
            int acumulada = adm.getCorrectas();

            //si el primer valor es mayor al segundo sera verdadero
            Assert.AreEqual(correcta, acumulada);

            // yield return new WaitForSeconds (20);
            yield return null;
        }

        //2
        //el metodo chequea si se estan almacenando correctamente las respuestas en base a controlar su veracidad
        [UnityTest]
        public IEnumerator TestDesicionesNo()
        {
            //supone una primer respuesta incorrecta
            int incorrecta = 1;
            //llama al metodo que decide
            adm.No();
            //el metodo devuelve el valor de la respuesta en este caso correcta y por ende es 1
            int acumulada = adm.getCorrectas();

            //si ambos son 0 sera verdadero
            Assert.AreEqual(incorrecta, acumulada);

            // yield return new WaitForSeconds (20);
            yield return null;
        }

        //3
        //el metodo chequea si se estan comparando las decisiones
        [UnityTest]
        public IEnumerator TestDesicionesxComprobacion()
        {
            //supone una primer respuesta incorrecta
            //llama al metodo que decide
            adm.No();
            //el metodo devuelve el valor de la respuesta en este caso correcta y por ende es 1
            int acumulada = adm.getCorrectas();

            //supone una segunda respuesta correcta
            //llama al metodo que decide
            adm.Si();
            //el metodo devuelve el valor de la respuesta en este caso incorrecta y por ende es 0
            int acumulada2 = adm.getCorrectas();

            //si el valor de las respuestas correctas es mayor entonces se comprueba que la comparacion es satisfactoria
            Assert.Greater(acumulada2, acumulada);

            yield return null;
        }

        //4
        //el metodo chequea si se agregan observadores correctamente
        [UnityTest]
        public IEnumerator TestDesicioneszObserAgregado(Observador nuevo)
        {
            //se toma el valor inicial del array que es 0
            int EstadoInicial = adm.getSuscribirTamanio();
            //se agrega un observador
            adm.suscribir(nuevo);
            //se toma el nuevo valor del array
            int EstadoFinal = adm.getSuscribirTamanio();

            Assert.Greater(EstadoFinal, EstadoInicial);

            yield return null;
        }

        //5
        //el metodo chequea si se quitan observadores correctamente
        [UnityTest]
        public IEnumerator TestDesicionesObserQuitado(Observador sacar)
        {
            //se toma el valor inicial del array que es 0
            int EstadoInicial = adm.getSuscribirTamanio();
            //se agrega un observador
            adm.desuscribir(sacar);
            //se toma el nuevo valor del array
            int EstadoFinal = adm.getSuscribirTamanio();

            Assert.Greater(EstadoInicial, EstadoFinal);

            yield return null;
        }


        //6
        //el metodo chequea si se notifica a los observadores correctamente
        [UnityTest]
        public IEnumerator TestDesicionesxNotificacion()
        {
            //se toma el valor inicial que es 0
            int EstadoInicial = adm.getNotificaciones();
            //se notifica
            adm.notificar();
            //se toma el nuevo valor del array
            int EstadoFinal = adm.getNotificaciones();

            Assert.Greater(EstadoFinal, EstadoInicial);

            yield return null;
        }


        //7
        //el metodo chequea si el numero a mostrar es distinto despues de cada desicion
        [UnityTest]
        public IEnumerator TestDesicionesxActualizar()
        {
            //se toma el valor inicial
            float EstadoInicial = adm.getnumeroMostrado();
            //se toma una desicion
            adm.Si();
            //se toma el nuevo valor
            float EstadoFinal = adm.getnumeroMostrado();

            Assert.AreNotEqual(EstadoFinal, EstadoInicial);

            yield return null;
        }


        //8
        //el metodo chequea si se ingresa correctamente al limite
        [UnityTest]
        public IEnumerator TestDesicionesxlimiteSemanal()
        {
            //se setea el numero de pacientes atendidos
            adm.setNumeroPacientes(3);
            //se comprueba si se entro a la rutina

            Assert.IsTrue(adm.getesperando());

            yield return null;
        }


        //9
        //el metodo chequea si se notifica correctamente al tomar una desicion
        [UnityTest]
        public IEnumerator TestDesicionesxnuevaDes()
        {

            //se setea un tipo de desicion.
            adm.nuevaDesicion(0);
            //se chequea si ha entrado al metodo
            float EstadoInicial = adm.getnumeroMostrado();
            //se setea un tipo de desicion.
            adm.nuevaDesicion(1);
            float EstadoFinal = adm.getnumeroMostrado();


            Assert.AreNotEqual(EstadoFinal, EstadoInicial);

            yield return null;
        }

        /*
        //1
        //el metodo chequea si se estan almacenando correctamente las respuestas en base a controlar su veracidad
        [UnityTest]
        public IEnumerator TestDesiciones()
        {
            bool rtaSi = false;
            //supone una primer respuesta incorrecta
            int incorrecta = 1;
            //llama al metodo que decide
            adm.No();
           // Debug.Log("ejecute no");
            //el metodo devuelve el valor de la respuesta en este caso correcta y por ende es 1
            int acumu = adm.Correctas();

            //si ambos son 0 sera verdadero
            if(incorrecta == acumu)
            {
                rtaSi = true;
            }

            bool rtaNo = false;

            //supone una primer respuesta correcta
            int correcta = 1;

            //el metodo devuelve el valor de la respuesta en este caso incorrecta y por ende es 0
            int acumulada = adm.Incorrectas();
            if(correcta != acumulada)
            {
                rtaNo = true;
            }

            //se chequea si es verdadero que la cola de correctas tiene su primer elemento "0" mediante bool 
            //en contraposicion si la de incorrectas tiene  su primer elemento "1" mediante bool
            Assert.AreEqual(rtaSi, rtaNo);
            
            yield return null;
        }*/

        [TearDown]
        public void Teardown()
        {
            //  GameObject.Destroy(DOM);
            //  GameObject.Destroy(gameGameObject);
            //  GameObject.Destroy(documentos);
        }

    }
}
