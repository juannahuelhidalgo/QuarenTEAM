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
           
          
            //se obtiene el codigo y el objeto asociado
            gameGameObject = GameObject.Find("mostrarPacientes");
            adm = gameGameObject.GetComponent<AdministradorDesiciones>();
        }


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
