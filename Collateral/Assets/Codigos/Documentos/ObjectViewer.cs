using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Esta clase se encarga mover la camara dependiendo de que objeto se toque por ahora solo esta implementada para ver el documento
public class ObjectViewer : MonoBehaviour
{
    public Vector3 setPosition;
    public Vector3 offsetP;
    public Vector3 offsetR;
    public Vector3 rotationVector;
    private Vector3 prevPosition;
    private Quaternion prevRotation;
    //public GameObject camposDocumento; -> Se ve que esta referencia nunca es usada
    public Transform documento;
    //Nos muestra el documento
    //Obtiene las referencias que necesita para funcionar y ubica la main camera en el escritorio
    public void Awake()
    {
        documento = this.GetComponent<Transform>();
        Camera.main.transform.SetPositionAndRotation(documento.position + offsetP, Quaternion.Euler(offsetR));
    }
    //nos lleva a la posicion para mirar el documento
    public void viewDocument()
    {
        prevPosition = Camera.main.transform.position;
        prevRotation = Camera.main.transform.rotation;
        Camera.main.transform.SetPositionAndRotation(setPosition, Quaternion.Euler(rotationVector));
        //camposDocumento.SetActive(true); 
        GameObject.Find("mostrarPacientes").GetComponent<AdministradorDocumentos>().setMirando(true); //Llama al metodo setMirando del objeto AmdinistradorHUD para que active el canvas del doc
    }
    //Nos lleva a la posicion antes de mirar el documento
    public void previousView()
    {
        Camera.main.transform.SetPositionAndRotation(prevPosition, prevRotation);
        GameObject.Find("mostrarPacientes").GetComponent<AdministradorDocumentos>().setMirando(false);//Llama al metodo setMirando del objeto AmdinistradorHUD para que desactive el canvas del doc
        //camposDocumento.SetActive(false);
    }
}
