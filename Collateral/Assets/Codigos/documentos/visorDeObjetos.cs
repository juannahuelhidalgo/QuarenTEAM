using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Esta clase se encarga mover la camara dependiendo de que objeto se toque por ahora solo esta implementada para ver el documento
public class visorDeObjetos : MonoBehaviour
{

    private Vector3 offsetP1;
    private Vector3 offsetP2;
    private Vector3 offsetR1;
    private Vector3 offsetR2;
    private Transform documento;
    private AdministradorDocumentos administradorDeDocumentos;
    //Nos muestra el documento
    //Obtiene las referencias que necesita para funcionar y ubica la main camera en el escritorio
    public void Awake()
    {
        documento = GameObject.Find("Documento").transform;
        offsetP2 = new Vector3(0.25f, 0.61f, 0.04f);
        offsetR2 = new Vector3(90.1f, -170.86f, 8.95f);
        offsetP1 = new Vector3(0, 0.76f, 1.07f);
        offsetR1 = new Vector3(10.5f, -176.35f, 0);
        documento = this.GetComponent<Transform>();
        Camera.main.transform.SetPositionAndRotation(documento.position + offsetP1, Quaternion.Euler(offsetR1));
        administradorDeDocumentos = this.GetComponent<AdministradorDocumentos>();
        administradorDeDocumentos.mirando(false);
    }
    //nos lleva a la posicion para mirar el documento

    
    //Esta funcion update nomas se uso como ayuda para setear bien la posición de las vistas de la camara. En caso de necesitar ver cambios en tiempo
    // real de la posicion y rotacion de la camara poner como publicas las variables offsetP offsetR y rotationVector
    /*
    public void Update()
    {
        Camera.main.transform.SetPositionAndRotation(documento.position + offsetP2, Quaternion.Euler(rotationVector));
    }*/
    public void viewDocument()
    {
        Camera.main.transform.SetPositionAndRotation(documento.position + offsetP2, Quaternion.Euler(offsetR2));
        //camposDocumento.SetActive(true); 
        administradorDeDocumentos.mirando(true); //Llama al metodo setMirando del objeto AmdinistradorHUD para que active el canvas del doc
    }
    //Nos lleva a la posicion antes de mirar el documento
    public void previousView()
    {
        Camera.main.transform.SetPositionAndRotation(documento.position + offsetP1, Quaternion.Euler(offsetR1));
        this.GetComponent<AdministradorDocumentos>().mirando(false);//Llama al metodo setMirando del objeto AmdinistradorHUD para que desactive el canvas del doc
        //camposDocumento.SetActive(false);
    }
}
