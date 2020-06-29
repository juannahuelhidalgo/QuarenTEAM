using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;
using System.Diagnostics;

//En esta clase se guarda la informacion para generar pacientes y contiene metodos para accecer a esta
public class datosPacientes : MonoBehaviour
{
    private static Queue<string> nombres = new Queue<string>();
    private static Queue<string> nacionalidades = new Queue<string>();
    private static Queue<string> viajo = new Queue<string>();
    private static Queue<string> enfermedades = new Queue<string>();
    private static Queue<string> sexo = new Queue<string>();
    private static Queue<int> edades = new Queue<int>();
    private static Queue<string> antecedentes = new Queue<string>();
    //private static string[] sexo = new string[2];

    public datosPacientes()
    {

        /*nombres = new Queue<string>();
        nacionalidades = new Queue<string>();
        viajo = new Queue<string>();
        enfermedades = new Queue<string>();*/


        //nombres del dataBase
        nombres.Enqueue("Mario Echeverria");
        nombres.Enqueue("Jennifer Camacho");
        nombres.Enqueue("Elvira Guillen");
        nombres.Enqueue("Anas Tamayo");
        nombres.Enqueue("Berta Uriarte");
        nombres.Enqueue("Roser Carreras");
        nombres.Enqueue("Eloi Olmo");
        nombres.Enqueue("Aimar Mendoza");
        nombres.Enqueue("Sofia Ros");
        nombres.Enqueue("Osvaldo Ros");
        nombres.Enqueue("Julian Merida");
        nombres.Enqueue("Sabrina Shultz");
        nombres.Enqueue("Paz Seia");
        nombres.Enqueue("Julieta Murisasco");
        nombres.Enqueue("Virginia Mendez");
        //nacionalidades del database
        nacionalidades.Enqueue("Argentina");
        nacionalidades.Enqueue("Colombiana");
        nacionalidades.Enqueue("Chilena");
        nacionalidades.Enqueue("China");
        nacionalidades.Enqueue("Rusa");
        nacionalidades.Enqueue("Estadounidense");
        nacionalidades.Enqueue("Argentina");
        nacionalidades.Enqueue("Colombiana");
        nacionalidades.Enqueue("Chilena");
        nacionalidades.Enqueue("Chileno");
        nacionalidades.Enqueue("Argentino");
        nacionalidades.Enqueue("Mexicana");
        nacionalidades.Enqueue("Argentina");
        nacionalidades.Enqueue("China");
        nacionalidades.Enqueue("Peruana");
        //databese de posibles lugares visitados
        viajo.Enqueue(" - ");
        viajo.Enqueue("España");
        viajo.Enqueue("China");
        viajo.Enqueue("Reino Unido");
        viajo.Enqueue("Perú");
        viajo.Enqueue(" - ");
        viajo.Enqueue(" - ");
        viajo.Enqueue("Alemania");
        viajo.Enqueue("Japón");
        viajo.Enqueue("-");
        viajo.Enqueue("USA");
        viajo.Enqueue("Iran");
        viajo.Enqueue("Japón");
        viajo.Enqueue("NorCorea");
        viajo.Enqueue("Ecuador");
        //Enfermedades del database
        enfermedades.Enqueue("Hipertension");
        enfermedades.Enqueue(" - ");
        enfermedades.Enqueue("Cancer");
        enfermedades.Enqueue("Asma");
        enfermedades.Enqueue("Caries");
        enfermedades.Enqueue("EPOC");
        enfermedades.Enqueue("Gripe");
        enfermedades.Enqueue("Ebola");
        enfermedades.Enqueue("Neumonía");
        enfermedades.Enqueue("Asma");
        enfermedades.Enqueue("Cancer");
        enfermedades.Enqueue("Bronquitis");
        enfermedades.Enqueue("Hipertension");
        enfermedades.Enqueue("Preinfartos");
        enfermedades.Enqueue(" - ");
        //sexo
        sexo.Enqueue("Masculino");
        sexo.Enqueue("Femenino");
        sexo.Enqueue("Femenino");
        sexo.Enqueue("N/E");
        sexo.Enqueue("Femenino");
        sexo.Enqueue("Masculino");
        sexo.Enqueue("Masculino");
        sexo.Enqueue("Masculino");
        sexo.Enqueue("Femenino");
        sexo.Enqueue("Masculino");
        sexo.Enqueue("Masculino");
        sexo.Enqueue("Femenino");
        sexo.Enqueue("Femenino");
        sexo.Enqueue("Femenino");
        sexo.Enqueue("Femenino");
        //antecedentes
        antecedentes.Enqueue("Herida de bala en Malvinas");
        antecedentes.Enqueue(" - ");
        antecedentes.Enqueue(" - ");
        antecedentes.Enqueue("Herida autoinflingida en construccion");
        antecedentes.Enqueue(" - ");
        antecedentes.Enqueue("Herida en manifestaciones del dia de la memoria");
        antecedentes.Enqueue("Quemaduras de 1er grado y ataques de panico");
        antecedentes.Enqueue("Depresion");
        antecedentes.Enqueue("Abuso de farmacos para el dolor");
        antecedentes.Enqueue("Depresion e intento de suicidio en el 2008");
        antecedentes.Enqueue("Prision por asesinato con ensañamiento");
        antecedentes.Enqueue("A.A medalla sobriedad hace 10 años");
        antecedentes.Enqueue("Rotura de ligamentos a temprana edad");
        antecedentes.Enqueue("Paciente con historial de alcoholismo y violencia");
        antecedentes.Enqueue("Historial de intentos de suicidios multiples");
        //edades
        edades.Enqueue(62);
        edades.Enqueue(28);
        edades.Enqueue(24);
        edades.Enqueue(40);
        edades.Enqueue(35);
        edades.Enqueue(32);
        edades.Enqueue(29);
        edades.Enqueue(62);
        edades.Enqueue(70);
        edades.Enqueue(34);
        edades.Enqueue(55);
        edades.Enqueue(42);
        edades.Enqueue(60);
        edades.Enqueue(31);
        edades.Enqueue(44);

    }
    public string[] generatePatient()
    {
        // Random random = new Random();
       // int edad = random.Next(18, 50);
       // int s = random.Next(0, 1);
        string[] paciente = new string[7];
        paciente[0] = nombres.Peek();
        paciente[1] = "" + edades.Peek();
        paciente[2] = nacionalidades.Peek();
        paciente[3] = enfermedades.Peek();
        paciente[4] = sexo.Peek();
        paciente[5] = viajo.Peek();
        paciente[6] = antecedentes.Peek();

        nombres.Dequeue();
        nacionalidades.Dequeue();
        edades.Dequeue();
        enfermedades.Dequeue();
        sexo.Dequeue();
        viajo.Dequeue();
        antecedentes.Dequeue();
        return paciente;
    }

    public int patientsNumber()
    {
        return nombres.Count;
    }
}
