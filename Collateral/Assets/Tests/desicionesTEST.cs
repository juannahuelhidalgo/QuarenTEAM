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
           
            //se instancia el documento y se toma el script
           // documentos = GameObject.Find("Documento");
           // admin = documentos.GetComponent<AdministradorDocumentos>();

            //se obtiene el codigo y el objeto asociado
            gameGameObject = GameObject.Find("mostrarPacientes");
            adm = gameGameObject.GetComponent<AdministradorDesiciones>();
        }

        //1
        //el metodo chequea si se estan almacenando correctamente las respuestas en base a controlar su veracidad
       /*  [UnityTest]
         public IEnumerator TestDesicionesSi()
         {
             //supone una primer respuesta correcta
             int correcta = 1;

            //llama al metodo que decide
            adm.Si();
            Debug.Log("ejecute si");

            //el metodo devuelve el valor de la respuesta en este caso incorrecta y por ende es 0
            int acumulada = adm.Correctas();

             //si el primer valor es mayor al segundo sera verdadero
             Assert.Greater(correcta, acumulada);

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
            Debug.Log("ejecute no");
            //el metodo devuelve el valor de la respuesta en este caso correcta y por ende es 1
            int acumulada = adm.Correctas();

            //si ambos son 0 sera verdadero
            Assert.AreEqual(incorrecta, acumulada);

            // yield return new WaitForSeconds (20);
            yield return null;
        }*/

        //el metodo chequea si se estan almacenando correctamente las respuestas en base a controlar su veracidad
        [UnityTest]
        public IEnumerator TestDesiciones()
        {
            bool rtaSi = false;
            //supone una primer respuesta incorrecta
            int incorrecta = 1;
            //llama al metodo que decide
            adm.No();
            Debug.Log("ejecute no");
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


            Assert.AreEqual(rtaSi, rtaNo);
            
            yield return null;
        }

        [TearDown]
        public void Teardown()
        {
            GameObject.Destroy(DOM);
            GameObject.Destroy(gameGameObject);
          //  GameObject.Destroy(documentos);
        }

    }
}
