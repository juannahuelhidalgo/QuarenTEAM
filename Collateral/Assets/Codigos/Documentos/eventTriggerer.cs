using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventTriggerer : MonoBehaviour
{
    private float timer;
    //me permite saber si estoy viendo el documento
    bool viewingDocument;
    //me permite saber sobre que puto objeto esta el mouse
    private MouseTracker mouse;
    //Me va a permitir setear la posición de la camara
    private ObjectViewer view;
    // Update is called once per frame
    private AdministradorDocumentos documento;
   
    //Obtiene las referencias de las otras clases que necesita para funcionar
    public void Awake()
    {
        mouse = this.GetComponent<MouseTracker>();
        view = this.GetComponent<ObjectViewer>();
        documento = this.GetComponent<AdministradorDocumentos>();

    }
    private void Start()
    {
        viewingDocument = false;
        timer = 0.0f;
        mouse = this.GetComponent<MouseTracker>();
    }
    //timer evita que se hagan multiples cambios de camara por click, ya que un click puede durar mas de una llamada de update
    void Update()
    {
        //Time.deltaTime me devuelve el tiempo transcurrido entre el frame anterior y este
        timer += Time.deltaTime;
        //Si el usuario hace click derecho, esta sobre el documento y el tiempo desde que se ejecuto el último mov de camara es mayor a 0,3 s
        if (Input.GetMouseButton(0) && mouse.getObjectUnder() == "Documento" && timer > 0.3)
        {
            timer = 0.0f;
            if (!viewingDocument)
            {
                view.viewDocument();
                viewingDocument = true;
            }
            else
            {
                ///Debug.Log("entre en el else ");
                view.previousView();
                viewingDocument = false;
            }
        }
        if (Input.GetMouseButton(0) && mouse.getObjectUnder() == "CambiarPaciente" && timer > 0.3)
        {
            documento.generarDocumento();
            timer = 0.0f;
        }
    }
}
