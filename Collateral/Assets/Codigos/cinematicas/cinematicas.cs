using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class cinematicas : MonoBehaviour
{
    adminJuego juego;
    GameObject AdmJuego;
    AdministradorDesiciones decide;
    GameObject dec;
    int[] respuestas = new int[15];
    GameObject uno;
    GameObject dos;
    GameObject tres;
    bool aca = false;
    private static Queue<string> mensajes = new Queue<string>();
    Text mensajesTexto;

    private void Awake()
    {
        AdmJuego = GameObject.Find("adminJuegos");
        juego = AdmJuego.GetComponent<adminJuego>();
        dec = GameObject.Find("mostrarPacientes");
        decide = dec.GetComponent<AdministradorDesiciones>();
        uno = GameObject.FindWithTag("camarauno");
        dos = GameObject.FindWithTag("camarados");
        tres = GameObject.FindWithTag("camaratres");

        GameObject tumba1 = GameObject.Find("Tumba1");
        GameObject enfermera = GameObject.Find("enfermera");
        GameObject soldado = GameObject.Find("soldado");
        GameObject ambulancia = GameObject.Find("Ambulancia");
        GameObject tumba2 = GameObject.Find("tumba2");
        GameObject camilla = GameObject.Find("camilla");
        GameObject cocina = GameObject.Find("cocina");
        GameObject drogas = GameObject.Find("drogas");
        GameObject horca = GameObject.Find("horca");
        GameObject asesino = GameObject.Find("asesino");
        GameObject calle = GameObject.Find("calle");
        GameObject violencia = GameObject.Find("violencia");
        GameObject baniera = GameObject.Find("baniera");
        GameObject drogas2 = GameObject.Find("drogas (1)");
        GameObject camilla2= GameObject.Find("camilla (1)");
        GameObject ambulancia2 = GameObject.Find("Ambulancia (1)");
        GameObject navidad = GameObject.Find("navidat");
        GameObject obrero = GameObject.Find("Obrero");
        GameObject actor = GameObject.Find("actor");
        GameObject baile = GameObject.Find("baile");
        GameObject box = GameObject.Find("box");
        GameObject running = GameObject.Find("Running");
        GameObject paracaidas = GameObject.Find("paracaidas");
        GameObject cumpleaños = GameObject.Find("cumpleaños");
        GameObject campamento= GameObject.Find("Campfire");
        GameObject fut = GameObject.Find("Ball");
        GameObject bote = GameObject.Find("bote");
        GameObject tenedor = GameObject.Find("tenedor");

       
        tenedor.SetActive(false);
        tumba1.SetActive(false);
        tumba2.SetActive(false);
        enfermera.SetActive(false);
        soldado.SetActive(false);
        ambulancia.SetActive(false);
        camilla.SetActive(false);
        camilla2.SetActive(false);
        cocina.SetActive(false);
        drogas.SetActive(false);
        drogas2.SetActive(false);
        calle.SetActive(false);
        horca.SetActive(false);
        asesino.SetActive(false);
        violencia.SetActive(false);
        baniera.SetActive(false);
        ambulancia.SetActive(false);
        ambulancia2.SetActive(false);
        navidad.SetActive(false);
        obrero.SetActive(false);
        actor.SetActive(false);
        baniera.SetActive(false);
        baile.SetActive(false);
        box.SetActive(false);
        bote.SetActive(false);
        running.SetActive(false);
        paracaidas.SetActive(false);
        cumpleaños.SetActive(false);
        campamento.SetActive(false);
        fut.SetActive(false);

        mensajesTexto = GameObject.Find("collateral").GetComponent<Text>();
        Debug.Log("te llame.");

        respuestas = decide.array();

        if (juego.getSemanaActual() == 1)
        {
            soldado.SetActive(true);
            if (respuestas[1] == 0) { drogas2.SetActive(true); } else { enfermera.SetActive(true); }
            if (respuestas[2] == 1) { camilla2.SetActive(true); } else { ambulancia.SetActive(true); }
        }
        if (juego.getSemanaActual() == 2)
        {
            if (respuestas[3] == 1) { navidad.SetActive(true); } else { tumba2.SetActive(true); }
            if (respuestas[4] == 0) { obrero.SetActive(true); } else { camilla.SetActive(true); }
            soldado.SetActive(true);
        }
        if (juego.getSemanaActual() == 3)
        {
            if (respuestas[5] == 0) { actor.SetActive(true); } else { tumba1.SetActive(true); }
            if (respuestas[6] == 0) { box.SetActive(true); } else { cocina.SetActive(true); }
            if (respuestas[7] == 1) { running.SetActive(true); } else { drogas.SetActive(true); }
        }
        if (juego.getSemanaActual() == 4)
        {
            if (respuestas[8] == 0) { baile.SetActive(true); } else { horca.SetActive(true); }
            asesino.SetActive(true);
            if (respuestas[9] == 0) { calle.SetActive(true); } else { tenedor.SetActive(true); }  
          
        }
        if (juego.getSemanaActual() == 5)
        {
            asesino.SetActive(true);
            violencia.SetActive(true);
            baniera.SetActive(true);
        }
      
    }

    public  void MensajeEmitido()
    {
        Debug.Log("Llame a MensajeEmitido.");
        string[] final = new string[2];
        final = complicado();
        mensajesTexto.text = final[0];
    }

    public string[] complicado()
    {
        Debug.Log("Llame a complicado.");
        string[] final = new string[2];
        final[0] = mensajes.Peek();

        mensajes.Dequeue();

        return final;
    }

    void Start()
    {
        respuestas = decide.array();
        mensajesCanvas();
        if (GameObject.Find("collateral").GetComponent<Text>().text.Equals("New Text")) {
            Debug.Log("te cache.");
            if (juego.getSemanaActual() == 1)
        {
                if (respuestas[2] == 1) { MensajeEmitido(); mensajes.Dequeue(); } else { mensajes.Dequeue();  MensajeEmitido(); }
                camara1();
        }

        if (juego.getSemanaActual() == 2)
        {
            if (respuestas[3] == 1) { MensajeEmitido(); mensajes.Dequeue(); } else { mensajes.Dequeue();  MensajeEmitido(); }
            camara1();
        }
          if (juego.getSemanaActual() == 3)
          {
              if (respuestas[5] == 0) { MensajeEmitido(); mensajes.Dequeue(); } else { mensajes.Dequeue();  MensajeEmitido(); }
            camara1();
        }

         if (juego.getSemanaActual() == 4)
         {
             if (respuestas[8] == 0) { MensajeEmitido(); mensajes.Dequeue(); } else { mensajes.Dequeue();  MensajeEmitido(); }
                camara1();
     
        }

          if (juego.getSemanaActual() == 5)
          {
            MensajeEmitido();
            camara1();
        }

        }
    }

    public  void camara1()
    {
        uno.SetActive(true);
        dos.SetActive(false);
        tres.SetActive(false);
        Debug.Log("camra1");
        StartCoroutine("PasarCamara");
    }

    public void camara2()
    {
        uno.SetActive(false);
        dos.SetActive(true);
        tres.SetActive(false);
        Debug.Log("camra2");
        StartCoroutine("PasarCamara2");
    }

    public void camara3()
    {
        uno.SetActive(false);
        dos.SetActive(false);
        tres.SetActive(true);
        Debug.Log("camra3");
        StartCoroutine("PasarCamara3");
        Debug.Log("ready?");
    }

    IEnumerator PasarCamara()
    {
        yield return new WaitForSeconds(4.3f);

        if (juego.getSemanaActual() == 1)
        {
            if (respuestas[1] == 0) { MensajeEmitido(); mensajes.Dequeue(); } else { mensajes.Dequeue();  MensajeEmitido(); }
        }
        if (juego.getSemanaActual() == 2)
        {
            if (respuestas[4] == 0) { MensajeEmitido(); mensajes.Dequeue();} else { mensajes.Dequeue();  MensajeEmitido(); }
        }
        if (juego.getSemanaActual() == 3)
        {
            if (respuestas[6] == 0) { MensajeEmitido(); mensajes.Dequeue(); } else { mensajes.Dequeue(); MensajeEmitido(); mensajes.Dequeue(); }
        }
        if (juego.getSemanaActual() == 4) { MensajeEmitido(); }
        if (juego.getSemanaActual() == 5)
        {
            MensajeEmitido();
        }

            camara2();
        Debug.Log("en el enum1");
    }

    IEnumerator PasarCamara2()
    {
        yield return new WaitForSeconds(4.5f);
        if (juego.getSemanaActual() == 1)
        {
            MensajeEmitido();
        }
        if (juego.getSemanaActual() == 2)
        {
            MensajeEmitido();
        }
        if (juego.getSemanaActual() == 3)
        {
            if (respuestas[7] == 1) { MensajeEmitido(); mensajes.Dequeue(); } else { mensajes.Dequeue();  MensajeEmitido(); }
        }
        if (juego.getSemanaActual() == 4)
        {
            if (respuestas[9] == 0) { MensajeEmitido(); mensajes.Dequeue(); } else { mensajes.Dequeue();  MensajeEmitido(); }
        }
        if (juego.getSemanaActual() == 5)
        {
            MensajeEmitido();
        }
        camara3();
        Debug.Log("en el enum2");
    }
    IEnumerator PasarCamara3()
    {
        yield return new WaitForSeconds(4.5f);

        Debug.Log("en el enum3");
        juego.cargarEscenaSiguiente();
    }

    public void mensajesCanvas()
    {
        mensajes.Enqueue("Una atencion a tiempo evito que tu paciente estuviera aqui");
        mensajes.Enqueue("Alguien se descompuso unas semanas despues");
        mensajes.Enqueue("Una buena medicacion es a veces es mas que suficiente felicitaciones");
        mensajes.Enqueue("Esta semana alguien no volvio a casa luego del trabajo...");
        mensajes.Enqueue("Bueno el excombatiente podra seguir en el servicio...");
        //bien 1
        mensajes.Enqueue("Estas fiestas lograste que no faltara nadie, bien hecho");
        mensajes.Enqueue("Bueno... a todos nos llega ¿No?");
        mensajes.Enqueue("Alguien podra seguir construyendo futuro");
        mensajes.Enqueue("El paciente no logro superarlo quiza si lo hubieses atendido..."); 
        mensajes.Enqueue("Espera ahora que lo recuerdo ¿Esos no son tus 2 pacientes? ");
        //bien
        mensajes.Enqueue("El doble de riesgos podra seguir actuando"); 
        mensajes.Enqueue("Bueno... a todos nos llega... ¿No?... ¡¿No?!");
        mensajes.Enqueue("Este chico tiene futuro"); //acercar boxeador
        mensajes.Enqueue("Siento olor a gas pero no veo el pavo..."); 
        mensajes.Enqueue("Correr es una buena actividad a cualquier edad");//con no da todo bien
        mensajes.Enqueue("Bueno... quiza recetaste de mas... o el se equivoco en la dosis ¿No? ");
       
        //bien 
        mensajes.Enqueue("La mano arriba... cintura...");
        mensajes.Enqueue("Esperemos que la soga no resista el primer tiron..."); //todo no cambiar el orden
        mensajes.Enqueue("Como podrias saber a quien salvabas... Y que lo volveria a hacer...");
        mensajes.Enqueue("Creo que la cuarentena duro demasiado... Al menos para este comerciante");
        mensajes.Enqueue("A veces el presupuesto es bajo");
  //    BOTON CULIAO

        //
        mensajes.Enqueue("Hay personas que simplemente no pueden seguir...");
        mensajes.Enqueue("Por cierto conocio a alguien en la sala... Creo que es la tercer bolsa");
        mensajes.Enqueue("El alcohol es el peor padre");
        //bien
    }

}

/*  GameObject Canvas5 = GameObject.Find("Canvas5");
  GameObject Canvas6 = GameObject.Find("Canvas6");
 /* GameObject Canvas9 = GameObject.Find("Canvas9");
  GameObject Canvas10 = GameObject.Find("Canvas10");
  GameObject Canvas13 = GameObject.Find("Canvas13");
  GameObject Canvas14 = GameObject.Find("Canvas14");
  GameObject Canvas17 = GameObject.Find("Canvas17");
  GameObject Canvas18 = GameObject.Find("Canvas18");
  GameObject Canvas24 = GameObject.Find("Canvas24");

  respuestas = decide.array();
*/


/* GameObject Canvas1 = GameObject.Find("Canvas1");/*
 GameObject Canvas8 = GameObject.Find("Canvas8");
 GameObject Canvas15 = GameObject.Find("Canvas15");
 GameObject Canvas16 = GameObject.Find("Canvas16");
 GameObject Canvas19 = GameObject.Find("Canvas19");
 GameObject Canvas20 = GameObject.Find("Canvas20");
 GameObject Canvas23 = GameObject.Find("Canvas23");
 int[] respuestas = new int[15];
 respuestas = decide.array();*/

/* GameObject Canvas2 = GameObject.Find("Canvas2");
    GameObject Canvas3 = GameObject.Find("Canvas3");/*
    GameObject Canvas4 = GameObject.Find("Canvas4");
    GameObject Canvas7 = GameObject.Find("Canvas7");
    GameObject Canvas11 = GameObject.Find("Canvas11");
    GameObject Canvas12 = GameObject.Find("Canvas12");
    GameObject Canvas21 = GameObject.Find("Canvas21");
    GameObject Canvas22 = GameObject.Find("Canvas22");
    int[] respuestas = new int[15];
    respuestas = decide.array();*/


/*  GameObject Canvas1 = GameObject.Find("Canvas1");
  GameObject Canvas2 = GameObject.Find("Canvas2");
  GameObject Canvas3 = GameObject.Find("Canvas3");
  GameObject Canvas4 = GameObject.Find("Canvas4");
  GameObject Canvas5 = GameObject.Find("Canvas5");
  GameObject Canvas6 = GameObject.Find("Canvas6");
  GameObject Canvas7 = GameObject.Find("Canvas7");
  GameObject Canvas8 = GameObject.Find("Canvas8");
  GameObject Canvas9 = GameObject.Find("Canvas9");
  GameObject Canvas10 = GameObject.Find("Canvas10");
  GameObject Canvas11 = GameObject.Find("Canvas11");
  GameObject Canvas12 = GameObject.Find("Canvas12");
  GameObject Canvas13 = GameObject.Find("Canvas13");
  GameObject Canvas14 = GameObject.Find("Canvas14");
  GameObject Canvas15 = GameObject.Find("Canvas15");
  GameObject Canvas16 = GameObject.Find("Canvas16");
  GameObject Canvas17 = GameObject.Find("Canvas17");
  GameObject Canvas18 = GameObject.Find("Canvas18");
  GameObject Canvas19 = GameObject.Find("Canvas19");
  GameObject Canvas20 = GameObject.Find("Canvas20");
  GameObject Canvas21 = GameObject.Find("Canvas21");
  GameObject Canvas22 = GameObject.Find("Canvas22");
  GameObject Canvas23 = GameObject.Find("Canvas23");
  GameObject Canvas24 = GameObject.Find("Canvas24");


  Canvas1.SetActive(false);
  Canvas2.SetActive(false);
  Canvas3.SetActive(false);
  Canvas4.SetActive(false);
  Canvas5.SetActive(false);
  Canvas6.SetActive(false);
  Canvas7.SetActive(false);
  Canvas8.SetActive(false);
  Canvas9.SetActive(false);
  Canvas10.SetActive(false);
  Canvas11.SetActive(false);
  Canvas12.SetActive(false);
  Canvas13.SetActive(false);
  Canvas14.SetActive(false);
  Canvas15.SetActive(false);
  Canvas16.SetActive(false);
  Canvas17.SetActive(false);
  Canvas18.SetActive(false);
  Canvas19.SetActive(false);
  Canvas20.SetActive(false);
  Canvas21.SetActive(false);
  Canvas22.SetActive(false);
  Canvas23.SetActive(false);
  Canvas24.SetActive(false);*/


/* if (juego.getSemanaActual() == 1)
        {
            if (respuestas[2] == 1) { Canvas5.SetActive(true); aca = true; } else { Canvas6.SetActive(true); }
            camara1();
        }
        if (juego.getSemanaActual() == 2)
        {
            if (respuestas[4] == 0) { Canvas13.SetActive(true); } else { Canvas14.SetActive(true); }
        }
        if (juego.getSemanaActual() == 3)
        {
            if (respuestas[5] == 0) { Canvas9.SetActive(true); } else { Canvas10.SetActive(true); }
        }
        if (juego.getSemanaActual() == 4)
        {
            if (respuestas[8] == 0) { Canvas17.SetActive(true); } else { Canvas18.SetActive(true); }
        }
        if (juego.getSemanaActual() == 5)
        {
            Canvas24.SetActive(true);
        }
        if (juego.getSemanaActual() == 1)
        {
            Canvas1.SetActive(true);
        }
        if (juego.getSemanaActual() == 2)
        {
            Canvas8.SetActive(true);
        }
        if (juego.getSemanaActual() == 3)
        {
            if (respuestas[7] == 1) { Canvas15.SetActive(true); } else { Canvas16.SetActive(true); }
        }
        if (juego.getSemanaActual() == 4)
        {
            if (respuestas[9] == 0) { Canvas19.SetActive(true); } else { Canvas20.SetActive(true); }
        }
        if (juego.getSemanaActual() == 5)
        {
            Canvas23.SetActive(true);
        }
        if (juego.getSemanaActual() == 1)
        {
            if (respuestas[1] == 0) { Canvas2.SetActive(true); aca = true; } else { Canvas3.SetActive(true); }
          //  camara3();
        }
        if (juego.getSemanaActual() == 2)
        {
            if (respuestas[3] == 1) { Canvas4.SetActive(true); } else { Canvas7.SetActive(true); }
        }
        if (juego.getSemanaActual() == 3)
        {
            if (respuestas[6] == 0) { Canvas11.SetActive(true); } else { Canvas12.SetActive(true); }
        }
        if (juego.getSemanaActual() == 4)
        {
            Canvas21.SetActive(true);
        }
        if (juego.getSemanaActual() == 5)
        {
            Canvas22.SetActive(true);
        }
*/
