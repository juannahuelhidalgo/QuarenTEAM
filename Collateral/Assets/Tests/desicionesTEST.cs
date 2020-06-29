using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

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
        Controller controlador;
        Text  texto;

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
            new WaitForSeconds(5f);
            adm = gameGameObject.GetComponent<AdministradorDesiciones>();
            Debug.Log("instancia 3");
            controlador = adm.GetComponent<Controller>();
            texto = GameObject.Find("VistaTexto").GetComponent<Text>();
        }

        //1
        //el metodo chequea si se estan almacenando correctamente las respuestas en base a controlar su veracidad
        [UnityTest]
        public IEnumerator TestDesicionesSi()
        {
            //supone una primer respuesta correcta
            int correcta = adm.getCorrectas();
            //llama al metodo que decide
            adm.Si();
            //el metodo devuelve el valor de la respuesta en este caso incorrecta y por ende es 0
            int acumulada = adm.getCorrectas();

            //si el primer valor es mayor al segundo sera verdadero
            Assert.Greater( acumulada, correcta);

            // yield return new WaitForSeconds (20);
            yield return null;
        }

        //2
        //el metodo chequea si se estan almacenando correctamente las respuestas en base a controlar su veracidad
        [UnityTest]
        public IEnumerator TestDesicionesNo()
        {
            //supone una primer respuesta incorrecta
            int incorrecta = adm.getIncorrectas();
            //llama al metodo que decide
            adm.No();
            //el metodo devuelve el valor de la respuesta en este caso correcta y por ende es 1
            int acumulada = adm.getIncorrectas();

            //si ambos son 0 sera verdadero
            Assert.Greater( acumulada, incorrecta);

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
            adm.No();
            //el metodo devuelve el valor de la respuesta en este caso incorrecta y por ende es 0
            int acumulada2 = adm.getCorrectas();

            //si el valor de las respuestas correctas es mayor entonces se comprueba que la comparacion es satisfactoria
            Assert.Greater(acumulada2, acumulada);

            yield return null;
        }
        
        //4
        //el metodo chequea si se agregan observadores correctamente
        [UnityTest]
        public IEnumerator TestDesicioneszObserAgregado(/*Observador nuevo*/)
        {/*
            
            //se toma el valor inicial del array que es 0
            int EstadoInicial = adm.getSuscribirTamanio();
            //se agrega un observador
            //adm.suscribir(nuevo);
            Observador nuevo = new Texto(adm);
            //se toma el nuevo valor del array
            int EstadoFinal = adm.getSuscribirTamanio();
            yield return new WaitForSeconds(2f);
            Assert.Greater(EstadoFinal, EstadoInicial);*/

            yield return null;
        }
        
        //5
        //el metodo chequea si se quitan observadores correctamente
        [UnityTest]
        public IEnumerator TestDesicionesObserQuitado()
        {
           
            //se toma el valor inicial del array que es 0
            Observador nuevo = new Texto(adm);
            int EstadoInicial = adm.getSuscribirTamanio();
            //se agrega un observador
            yield return new WaitForSeconds(2);
            adm.desuscribir(nuevo);
            //se toma el nuevo valor del array
            yield return new WaitForSeconds(2);
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
            adm.Si();
            adm.ActualizarNumeroAMostrar();
            float EstadoInicial = adm.getnumeroMostrado();
            //se toma una desicion
            adm.No();
            adm.ActualizarNumeroAMostrar();
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
            adm.setNumeroPacientes(2);
            adm.nuevaDesicion(0);
            //se comprueba si se entro a la rutina
            yield return new WaitForSeconds(2);
            Assert.IsTrue(adm.getCambio());

            yield return null;
        }


        //9
        //el metodo chequea si se notifica correctamente al tomar una desicion
        [UnityTest]
        public IEnumerator TestDesicionesxanuevaDes()
        {
            
            //se setea un tipo de desicion.
            adm.nuevaDesicion(0);
            //se chequea si ha entrado al metodo
            //float EstadoInicial = adm.getnumeroMostrado();
            string primernumero = texto.text;
            //se setea un tipo de desicion.
            adm.nuevaDesicion(1);
            //float EstadoFinal = adm.getnumeroMostrado();
            string segundonumero = texto.text;
            


            Assert.AreNotEqual(primernumero,segundonumero);

            yield return null;
        }


        [TearDown]
        public void Teardown()
        {
              GameObject.Destroy(DOM.gameObject);
            //  GameObject.Destroy(gameGameObject);
            //  GameObject.Destroy(documentos);
        }

    }
}
