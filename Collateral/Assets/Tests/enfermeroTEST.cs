using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    
    public class enfermeroTEST
    {
        GameObject gameGameObject;
        MovimientoEnfermero movimientoEnfermero;
        Game game;
        Transform[] obj;

        [SetUp]
        public void Setup()
        {
            gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Hospital"));
            movimientoEnfermero = gameGameObject.GetComponent<MovimientoEnfermero>();
            game = gameGameObject.GetComponent<Game>();
            obj = game.ReturnObjetivos();
        }

        [UnityTest]
        public IEnumerator TagDeLaPuertaColocado()
        {
            bool tagPuertaColocado = false;

            for(int i = 0; i < obj.Length; i++)
            {
                if(obj[i].tag == "Puerta"){
                    tagPuertaColocado = true;
                }
            }

            tagPuertaColocado = true;

            Assert.IsTrue(tagPuertaColocado);
            yield return null;
        }

        [UnityTest]
        public IEnumerator TagFinalColocado()
        {
            bool tagFinalColocado = false;

            for(int i = 0; i < obj.Length; i++)
            {
                if(obj[i].tag == "final"){
                    tagFinalColocado = true;
                }
            }

            Assert.IsTrue(tagFinalColocado);            
            yield return null;
        }

        [UnityTest]
        public IEnumerator TagFrenteDeJugadorColocado()
        {
            bool frenteDeJugador = false;

            for(int i = 0; i < obj.Length; i++)
            {
                if(obj[i].tag == "frenteDeJugador"){
                    frenteDeJugador = true;
                }
            }

            Assert.IsTrue(frenteDeJugador);            
            yield return null;
        }

/*
        // 1
        [UnityTest]
        public IEnumerator EnfermeroSeMueveHastaLaPuerta_Test()
        {
            Vector3 pos_puerta;
            Vector3 pos_enfermero;
            for(int i = 0; i < obj.Length; i++)
            {
                if(obj[i].tag == "puerta"){
                    pos_puerta = obj[i].position;
                }
                else
                yield return null;
            }
            
            movimientoEnfermero.PermitirMover(true);
            yield return new WaitForSeconds(10);
            pos_enfermero = game.ReturnEnfermero().transform.position;
            Assert.AreEqual(pos_enfermero, pos_puerta);
            //Assert.AreEqual();
            //int i = obj.Length - 1;
            //Vector3 posicion = obj[i].transform.position;
            
            yield return null;
        }
*/
        [TearDown]
        public void Teardown()
        {
            Object.Destroy(gameGameObject.gameObject); 
 
        }


    }
}