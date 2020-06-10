using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparadorDeEventos : MonoBehaviour
{
    private float timer;
    //me permite saber si estoy viendo el documento
    bool viewingDocument;
    //me permite saber sobre que objeto esta el mouse
    private seguidorDeMouse mouse;
    //Me va a permitir setear la posición de la camara
    private visorDeObjetos view;
    private MovimientoEnfermero movimientoEnfermero;
    
    public bool llegoDocumento = false;
    public bool sePuedeVer = false;
   
    //Obtiene las referencias de las otras clases que necesita para funcionar
    public void Awake()
    {
        mouse = this.GetComponent<seguidorDeMouse>();
        view = this.GetComponent<visorDeObjetos>();
        this.GetComponent<MeshRenderer>().enabled = false;
        movimientoEnfermero = GameObject.FindGameObjectWithTag("NPC").GetComponent<MovimientoEnfermero>();

    }
    private void Start()
    {
        viewingDocument = false;
        timer = 0.0f;
        mouse = this.GetComponent<seguidorDeMouse>();
    }
    //timer evita que se hagan multiples cambios de camara por click, ya que un click puede durar mas de una llamada de update
    void Update()
    {           

        //Time.deltaTime me devuelve el tiempo transcurrido entre el frame anterior y este
        timer += Time.deltaTime;
        //Si el usuario hace click derecho, esta sobre el documento y el tiempo desde que se ejecuto el último mov de camara es mayor a 0,3 s
        if (Input.GetMouseButton(0) && mouse.getObjectUnder() == "Documento" && timer > 0.3 && sePuedeVer)
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
        //esta funcion permitia asociar un cambio de paciente a un click sobre un obj de tag "CambiarPaciente"
        /*
        if (Input.GetMouseButton(0) && mouse.getObjectUnder() == "CambiarPaciente" && timer > 0.3)
        {
            documento.generarDocumento();
            timer = 0.0f;
        }*/
    }

    void DejarDeMostrarDocumento(bool verDocumento){
        this.GetComponent<MeshRenderer>().enabled = verDocumento;
    }

    public void LlegoDocumento(){
        DejarDeMostrarDocumento(true);
    }

    public void SePuedeVer(bool ver){
        sePuedeVer = ver;
    }

    public void EnfermeroSeVa(){
        SePuedeVer(false);
        view.previousView();
        StartCoroutine("EnfermeroSeVaComplemento");   
    }

    IEnumerator EnfermeroSeVaComplemento(){
        yield return new WaitForSeconds(0.5f);  //Tiempo que se espera antes de sacar el documento de la vista
        DejarDeMostrarDocumento(false);    
        yield return new WaitForSeconds(0.5f);  //Tiempo que se espera antes de hacer volver al enfermero
        movimientoEnfermero.Volver();  
    }

}
