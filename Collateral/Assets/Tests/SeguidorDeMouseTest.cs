using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class SeguidorDeMouseTest
    {
        GameObject juego;
        seguidorDeMouse mouse;


        //Aqui se pondra lo que se inicia/instancia con el comienzo de cada test
        [SetUp]
        public void Setup()
        {
            //SceneManager.LoadScene(1);
            //se instancia el juego correspondiente
          
            juego = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Escenas/Juego"));
            
            Debug.Log("instancia 1");
            
            mouse = GameObject.Find("Documento").GetComponent<seguidorDeMouse>();

        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator getObjectUnderTest()
        {
            //Camera camara = GameObject.Find("CamaraDocumentos").GetComponent<Camera>();
            //camara.transform.position = GameObject.Find("Int_MD_01_Floor_01 (34)").transform.position + new Vector3(0,0.3f,0);
            //camara.transform.rotation = Quaternion.Euler(90, 0, 0);
            //Debug.Log(mouse.getObjectUnder());
            Assert.AreNotEqual("Null", mouse.getObjectUnder());
             // Use the Assert class to test conditions.
             // Use yield to skip a frame.
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

