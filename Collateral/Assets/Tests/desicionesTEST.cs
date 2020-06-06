using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class desicionesTEST
    {
        GameObject gameGameObject;
        GameObject documentos;
        GameObject DOM;
        AdministradorDesiciones adm;
        AdministradorDocumentos admin;

        //Aqui se pondra lo que se inicia/instancia con el comienzo de cada test
        [SetUp]
        public void Setup()
        {
            //se instancia el raw image correspondiente
            DOM = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Escenas/Juego"));
           // gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Desiciones/mostrarPacientes"));
            gameGameObject = GameObject.Find("mostrarPacientes");
            // documentos = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Documentos/Documento"));
            documentos = GameObject.Find("Documento");
            admin = documentos.GetComponent<AdministradorDocumentos>();
 
            //se obtiene el codigo
            adm = gameGameObject.GetComponent<AdministradorDesiciones>();
        }

        //1
        //el metodo chequea si se estan almacenando correctamente las respuestas en base a controlar su veracidad
        /* [UnityTest]
         public IEnumerator TestDesicionesSi()
         {
             //supone una primer respuesta correcta
             int correcta = 1;

             //llama al metodo que decide
             adm.Si();

             //el metodo devuelve el valor de la respuesta en este caso incorrecta y por ende es 0
             int acumulada = adm.Correctas();

             //si el primer valor es mayor al segundo sera verdadero
             Assert.Greater(correcta, acumulada);

             // yield return new WaitForSeconds (20);
             yield return null;
         }*/

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
            int acumulada = adm.Correctas();

            //si ambos son 0 sera verdadero
            Assert.AreEqual(incorrecta, acumulada);

            // yield return new WaitForSeconds (20);
            yield return null;
        }
     
        [TearDown]
        public void Teardown()
        {
            GameObject.Destroy(DOM);
            GameObject.Destroy(gameGameObject);
            GameObject.Destroy(documentos);
        }

    }
}
