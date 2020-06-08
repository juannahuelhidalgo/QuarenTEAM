using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

[TestFixture]
public class transicionTEST
{

     GameObject gameGameObject;
     menuPrinc noticias;


    //Aqui se pondra lo que se inicia/instancia con el comienzo de cada test
    [SetUp]
    public void Setup()
    {
        //se instancia el raw image correspondiente
        gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Menu/gif"));
        //se obtiene el codigo
        noticias = gameGameObject.GetComponent<menuPrinc>();
    }

    // 1
    // se testea si la variable que cuenta la semana en la que nos encontramos 
    // es mayor que la anterior, con ello sabemos que la semana ha avanzado
    [UnityTest]
    public IEnumerator transicionTestCambiodeSemana()
    {

        //en esta variable se almacena el valor de la primer semana 
        int semanaAnterior = noticias.semanaActual();
        Debug.Log("SemanaAnterior: " + semanaAnterior);

        noticias.cambioSemana();
        Debug.Log("semana actual de noticias: " + noticias.semanaActual());


        //Greater da true si el primer parametro es mayor que el segundo
        Assert.Greater(noticias.semanaActual(), semanaAnterior);

        // yield return new WaitForSeconds(15);

        //return obligatorio
        yield return null;
    }

    // 2
    //se testeara si se ha terminado el juego en base a la cantidad de semanas
    //que este posea
    [UnityTest]
    public IEnumerator transicionTestSemanasAcabadas()
    {
        //Se setea una variable que nos indicara luego que ha terminado
        bool finalizo = true;
       // yield return new WaitForSeconds(15);
        //se cambia la semana
        for (int i = 0; i < noticias.getFinal(); i++)
        {
            noticias.cambioSemana();
            Debug.Log("cambie la semana: " + i);
            Debug.Log("semana actual de noticias: " + noticias.semanaActual());
        }
        Debug.Log("sali del for ");
        //se verifica que se llegue al final de las semanas
        if (noticias.semanaActual() == noticias.getFinal())
          {
              Debug.Log("entre al if ");
              //AreEquial verifica que los parametros coincidan en su valor booleano
              Assert.AreEqual(finalizo, noticias.finTrans());
          }

        Debug.Log("semana actual de noticias: " + noticias.semanaActual());
        Debug.Log("final: " + noticias.getFinal());
        Debug.Log("final: " + noticias.finTrans());

        //  Assert.IsTrue(noticias.finTrans());
        // Assert.AreEqual(noticias.semanaActual(), noticias.getFinal());


        //return obligatorio
        yield return null;
    }

    [TearDown]
    public void Teardown()
    {
        //Se destruyen los objetos creados
      //  GameObject.Destroy(gameGameObject);
       GameObject.Destroy(gameGameObject.gameObject);
       // Object.Destroy(gameGameObject);
       // Object.Destroy(gameGameObject.gameObject);
       // GameObject.Destroy(noticias);

    }
}



