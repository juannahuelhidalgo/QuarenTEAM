using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace TestsDeIntegracion
{
    [TestFixture]
    public class npc_SmokeTest
    {
        GameObject juego;
        GameObject npc;
        Transform[] objetivos;
        MovimientoEnfermero movimientoEnfermero;
        // A Test behaves as an ordinary method

        [SetUp]
        public void Setup()
        {
            juego = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Escenas/Juego"));
            movimientoEnfermero = GameObject.FindWithTag("npc").GetComponent<MovimientoEnfermero>();
            //movimientoEnfermero.prueba();
            objetivos = movimientoEnfermero.returnObjetivos();
            Debug.Log("setup");
        }

        [UnityTest]
        public IEnumerator TagFinalIdaColocado()
        {
            bool FinalIda = false;

            for (int i = 0; i < objetivos.Length; i++)
            {
                if (objetivos[i].tag == "FinalIda") {
                    FinalIda = true;
                }
            }

            yield return new WaitForSeconds(0.1f);
            Assert.IsTrue(FinalIda);
            yield return null;
        }

        [UnityTest]
        public IEnumerator TagPrevioFinalIdaColocado()
        {
            bool PrevioFinalIda = false;

            for (int i = 0; i < objetivos.Length; i++)
            {
                if (objetivos[i].tag == "PrevioFinalIda") {
                    PrevioFinalIda = true;
                }
            }
            yield return new WaitForSeconds(0.1f);
            Assert.IsTrue(PrevioFinalIda);
            yield return null;
        }

        [UnityTest]
        public IEnumerator TagFinalVueltaColocado()
        {
            bool FinalVuelta = false;

            for (int i = 0; i < objetivos.Length; i++)
            {
                if (objetivos[i].tag == "FinalVuelta") {
                    FinalVuelta = true;
                }
            }

            yield return new WaitForSeconds(0.1f);
            Assert.IsTrue(FinalVuelta);
            yield return null;
        }

        //hacer que verifique cuando colisione con el tag frente jugador

        [UnityTest]
        public IEnumerator EnfermeroSeMueveHastaFrenteDelJugador_Test()
        {

            yield return new WaitForSeconds(5);
            bool llegoAlFinal = movimientoEnfermero.getComportamientoUltimoTramo();

            Assert.IsTrue(llegoAlFinal);

            yield return null;
        }

        [TearDown]
        public void Teardown()
        {
            Debug.Log("aca");
            Object.Destroy(juego.gameObject);
        }

    }
}

namespace Tests
{

    [TestFixture]
    public class Anpc_UnitTest
    {
        MovimientoEnfermero movimientoEnfermero;
        GameObject npc;
        GameObject juego;
        Transform[] objetivos;
        [SetUp]
        public void Setup()
        {
            juego = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Escenas/Juego"));
            movimientoEnfermero = GameObject.FindWithTag("npc").GetComponent<MovimientoEnfermero>();
            npc = GameObject.FindWithTag("npc");
            objetivos = movimientoEnfermero.returnObjetivos();
        }

         [UnityTest]
        public IEnumerator Rotacion_Test()
        {            
            int j = movimientoEnfermero.objetivos.Length-2;
            yield return new WaitForSeconds(5);

            Assert.AreEqual(j,movimientoEnfermero.i);            
            
            yield return null;
        }

         [UnityTest]
        public IEnumerator CalcularRotacion_Test()
        {

            Vector3 dir = objetivos[0].position - movimientoEnfermero.transform.position;                                                      //Vector que marca la direccion de la rotacion
            dir.y = movimientoEnfermero.direccion.y;
            Quaternion rot = Quaternion.LookRotation(dir, Vector3.up);  
            /*
            Debug.Log(dir.x);
            Debug.Log(dir.y);
            Debug.Log(dir.z);
            Debug.Log(movimientoEnfermero.direccion.x);
            Debug.Log(movimientoEnfermero.direccion.y);
            Debug.Log(movimientoEnfermero.direccion.z);
            Debug.Log(rot.x);
            Debug.Log(rot.y);
            Debug.Log(rot.z);
            Debug.Log(movimientoEnfermero.rotacion.x);
            Debug.Log(movimientoEnfermero.rotacion.y);
            Debug.Log(movimientoEnfermero.rotacion.z);
            */
            yield return new WaitForSeconds(0.1f);           

            Assert.AreEqual(rot,movimientoEnfermero.rotacion);         
            
            yield return null;
        }

        [UnityTest]
        public IEnumerator Movimiento_Test()
        {      
            yield return new WaitForSeconds(1f);
            Assert.IsTrue(movimientoEnfermero.GetComponent<Animator>().GetBool("Moviendo"));
            
            yield return null;
        }

        [UnityTest]
        public IEnumerator MoverNpc_Test()
        {      
            yield return new WaitForSeconds(0.1f);
            Vector3 pos1 = movimientoEnfermero.transform.position;
            yield return new WaitForSeconds(0.7f);
            Vector3 pos2 = movimientoEnfermero.transform.position;

            Assert.AreNotEqual(pos1,pos2);
            yield return null;
        }

        [UnityTest]
        public IEnumerator Volver_Test()
        {
            yield return new WaitForSeconds(5f);
            Vector3 pos1 = movimientoEnfermero.transform.position;
            movimientoEnfermero.Volver();
            yield return new WaitForSeconds(1f);
            Vector3 pos2 = movimientoEnfermero.transform.position;

            Assert.AreNotEqual(pos1, pos2);


            yield return null;
        }


        [TearDown]
        public void Teardown()
        {
            Debug.Log("aca");
            Object.Destroy(juego.gameObject);
        }


    }
    
}
