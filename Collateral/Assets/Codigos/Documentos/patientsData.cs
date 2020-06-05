using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;
using System.Diagnostics;

//En esta clase se guarda la informacion para generar pacientes y contiene metodos para accecer a esta
public class patientsData : MonoBehaviour
{
    private Queue<string> nombres;
    private Queue<string> nacionalidades;
    private Queue<string> viajo;
    private Queue<string> enfermedades;
    private string[] sexo = new string[2];

    public patientsData()
    {

        nombres = new Queue<string>();
        nacionalidades = new Queue<string>();
        viajo = new Queue<string>();
        enfermedades = new Queue<string>();
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
        //databese de posibles lugares visitados
        viajo.Enqueue("USA");
        viajo.Enqueue("España");
        viajo.Enqueue("Rusia");
        viajo.Enqueue("Reino Unido");
        viajo.Enqueue("Italia");
        viajo.Enqueue("Brazil");
        viajo.Enqueue("Francia");
        viajo.Enqueue("Alemania");
        viajo.Enqueue("Turquia");
        //Enfermedades del database
        enfermedades.Enqueue("Hipertension");
        enfermedades.Enqueue("Diabetes");
        enfermedades.Enqueue("Cancer");
        enfermedades.Enqueue("Asma");
        enfermedades.Enqueue("Caries");
        enfermedades.Enqueue("EPOC");
        enfermedades.Enqueue("Gripe");
        enfermedades.Enqueue("Ebola");
        enfermedades.Enqueue("Gastitris");
        //sexo
        sexo[0] = "Hombre";
        sexo[1] = "Mujer";
    }
    public string[] generatePatient()
    {
        Random random = new Random();
        int edad = random.Next(18, 50);
        int s = random.Next(0, 1);
        string[] paciente = new string[6];
        paciente[0] = nombres.Peek();
        paciente[1] = "" + edad;
        paciente[2] = nacionalidades.Peek();
        paciente[3] = enfermedades.Peek();
        paciente[4] = sexo[s];
        paciente[5] = viajo.Peek();

        nombres.Dequeue();
        nacionalidades.Dequeue();
        enfermedades.Dequeue();
        viajo.Dequeue();
        return paciente;
    }

    public int patientsNumber()
    {
        return nombres.Count;
    }
}
