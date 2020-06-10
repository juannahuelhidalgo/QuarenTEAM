using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    [TestFixture]
    public class movimientoNPCTEST
    {
        GameObject juego;
        GameObject NPC;
        Transform[] objetivos;
        MovimientoEnfermero movimientoEnfermero;
        // A Test behaves as an ordinary method

        [SetUp]
        public void Setup()
        {
            juego = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Escenas/Juego"));
            movimientoEnfermero = GameObject.FindWithTag("NPC").GetComponent<MovimientoEnfermero>();
            //movimientoEnfermero.prueba();
            objetivos = movimientoEnfermero.returnObjetivos();
            Debug.Log("setup");
        }

        [UnityTest]
        public IEnumerator TagFinalColocado()
        {
            bool tagFinalColocado = false;

            for(int i = 0; i < objetivos.Length; i++)
            {
                if(objetivos[i].tag == "final"){
                    tagFinalColocado = true;
                }
            }

            yield return new WaitForSeconds(0.1f);
            Assert.IsTrue(tagFinalColocado);       
            yield return null;
        }

        [UnityTest]
        public IEnumerator TagFrenteDeJugadorColocado()
        {
            bool frenteDeJugador = false;

            for(int i = 0; i < objetivos.Length; i++)
            {
                if(objetivos[i].tag == "frenteDeJugador"){
                    frenteDeJugador = true;
                }
            }
            yield return new WaitForSeconds(0.1f);
            Assert.IsTrue(frenteDeJugador);            
            yield return null;
        }
        
        [UnityTest]
        public IEnumerator EnfermeroSeMueveHastaFrenteDelJugador_Test()
        {
            Vector3 pos_enfermero;
            Vector3 pos_frenteDeJugador = new Vector3(0,0,0);

            for(int i = 0; i < objetivos.Length; i++)
            {
                if(objetivos[i].tag == "frenteDeJugador"){
                    pos_frenteDeJugador = objetivos[i].position;
                }
            }
            
            yield return new WaitForSeconds(5);
            pos_enfermero = GameObject.FindWithTag("NPC").transform.position;
            Debug.Log(pos_enfermero);
            Debug.Log(pos_frenteDeJugador);
            pos_enfermero = new Vector3(Mathf.Round(pos_enfermero.x), Mathf.Round(pos_enfermero.y), Mathf.Round(pos_enfermero.z));
            pos_frenteDeJugador = new Vector3(Mathf.Round(pos_frenteDeJugador.x), Mathf.Round(pos_frenteDeJugador.y), Mathf.Round(pos_frenteDeJugador.z));
            Debug.Log(pos_enfermero);
            Assert.AreEqual(pos_enfermero, pos_frenteDeJugador);
            
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
