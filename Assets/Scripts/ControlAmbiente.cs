using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class ControlAmbiente : MonoBehaviour
{
    public GameObject ambienteUno;
    public GameObject ambienteDos;
    public GameObject player;
    public GameObject prefab;
    public GameObject cameraPlayer;
    public GameObject cameraPanoramica;
    public List<Vector3> posicion;
    public List<float> grados;
    public bool b;
    public Vector3 pAnterior, pCambio;

    //Puntos Para la linea
    private Vector3 puntoUno, puntoDos, puntoAyuda;
    public GameObject linea;
    private float hipotenusa, adyacente, angulo;

    // private GuardarPosiciones guardarPosiciones;


    public void Start()
    {
        b = true;
        posicion = new List<Vector3>();
        grados = new List<float>();
        puntoAyuda = new Vector3();
        puntoDos = new Vector3();
        puntoUno = new Vector3();
        cameraPanoramica.SetActive(false);
    }

    public void Update()
    {
        ConocerDistancia();
    }

    public void ActivarNevada()
    {
        ambienteUno.SetActive(true);
        ambienteDos.SetActive(false);
    }

    public void ActivarArena()
    {
        ambienteDos.SetActive(true);
        ambienteUno.SetActive(false);
    }

    //Metodo que posiciona un prefab entre los dos puntos (por medio del angulo del punto anterior) y conocer que recorrido hizo
    public void MostrarRecorrido()
    {
        //Activar camara panoramica

        //crear objetos que muestran el recorrido del jugador
        try
        {
            for (int i = 0; i < posicion.Count; i++)
            {

                //Debug.Log(posicion[i]);
                Instantiate(prefab, posicion[i], Quaternion.identity);

                puntoUno = posicion[i];

                puntoDos = posicion[i + 1];

                puntoAyuda = new Vector3(puntoDos.x, posicion[i].y, puntoUno.z);

                adyacente = Vector3.Distance(puntoUno, puntoAyuda);

                // Debug.Log(adyacente);

                float cua1 = puntoAyuda.x - puntoUno.x;
                float cua2 = puntoAyuda.z - puntoUno.z;
                // hipotenusa = 20f;

                angulo = Mathf.Acos(adyacente / hipotenusa);
                // Debug.Log(angulo);


                float Pmediox = (puntoDos.x + puntoUno.x) / 2;
                float Pmedioz = (puntoDos.z + puntoUno.z) / 2;

                //ifs para saber en que cuadrante se encuentra y cambiar el signo del angulo
                if (puntoUno.z > puntoDos.z)
                {
                    angulo = angulo * -1;
                    if (puntoUno.x < puntoDos.x)
                    {
                        angulo = angulo * -1;
                    }
                }
                else if (puntoUno.x < puntoDos.x && puntoUno.z < puntoDos.z)
                {
                    angulo = angulo * -1;
                }

                grados.Add(angulo * (180 / Mathf.PI));
                Instantiate(linea, new Vector3(Pmediox, puntoUno.y + 0.3f, Pmedioz), Quaternion.Euler(0, angulo * (180 / Mathf.PI), 0));
                Instantiate(prefab, puntoUno, Quaternion.identity);
                Instantiate(prefab, puntoDos, Quaternion.identity);

            }
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine(e);
        }

        //Guardar las listas en un archivo XML
        GuardarPosiciones.guardarPosiciones.SaveByXML(posicion, grados);
        // guardarPosiciones.SaveByXML(posicion, grados);

    }

    //Metodo que gestiona los puntos por medio de una distancia mayor a 20 unidades
    public void ConocerDistancia()
    {
        pCambio = player.transform.position;

        //Poner el primer punto, donde comienza el jugador
        if (b == true)
        {
            pAnterior = player.transform.position;
            b = false;
            posicion.Add(pAnterior);
        }
        else if (Vector3.Distance(pAnterior, pCambio) >= 20)
        {
            hipotenusa = Vector3.Distance(pAnterior, pCambio);
            //  Debug.Log(hipotenusa);
            Debug.LogError("Guardar");
            pAnterior = player.transform.position;
            posicion.Add(pAnterior);
        }

        // Debug.LogError("ESTE ES EL PUNTO ANTERIOR" + pAnterior);
        // Debug.Log("ESTE ES EL PUNTO QUE CAMBIA" +pCambio);
    }

    public void CambioCamara()
    {
        cameraPanoramica.SetActive(true);
        cameraPlayer.SetActive(false);
    }

    public void CambiarPlaya()
    {
        SceneManager.LoadScene("Playa2");
    }
    
    
    
    
    
    //Metodo para experimentos
    /* public void ver()
     {
         for (int i = 0; i < posicion.Count; i++)
         {

             Debug.Log(posicion[i]);
         }
         for (int i = 0; i < grados.Count; i++)
         {

             Debug.Log(grados[i]);
         }


                 // // EJEMPLO DE LAS POSICONES//
         // // SOLO FUNCIONA EN EL EJE X/Z

         // puntoUno = new Vector3(282.2f, 24.245f, 560.7f);
         // //Cuadrante 1
         // puntoDos = new Vector3(295.5963f, 24.245f, 575.6496f);
         // //Cuadrante 3
         // //puntoDos = new Vector3(269.3891f, 24.245f, 545.2116f);
         // //Cuadrante 2
         // //puntoDos = new Vector3(270.0101f, 24.245f, 576.5577f);
         // //Cuadrante 4
         // //puntoDos = new Vector3(296.26f, 24.245f, 546.2491f);

         // puntoAyuda = new Vector3(puntoDos.x, 24.02839f, puntoUno.z);


         // adyacente = Vector3.Distance(puntoUno, puntoAyuda);

         // Debug.Log(adyacente);

         // float cua1 = puntoAyuda.x - puntoUno.x;
         // float cua2 = puntoAyuda.z - puntoUno.z;

         // hipotenusa = 20f;
         // angulo = Mathf.Acos(adyacente / hipotenusa) * (180 / Mathf.PI);

         // Debug.Log(angulo);

         // float Pmediox = (puntoDos.x + puntoUno.x) / 2;
         // float Pmedioz = (puntoDos.z + puntoUno.z) / 2;

         // if (puntoUno.z > puntoDos.z)
         // {
         //     angulo = angulo * -1;
         //     if (puntoUno.x < puntoDos.x)
         //     {
         //         angulo = angulo * -1;
         //     }
         // }
         // else if (puntoUno.x < puntoDos.x && puntoUno.z < puntoDos.z)
         // {
         //     angulo = angulo * -1;
         // }

         // Instantiate(linea, new Vector3(Pmediox, 24.24395f, Pmedioz), Quaternion.Euler(0, angulo, 0));
         // Instantiate(prefab, puntoUno, Quaternion.identity);
         // Instantiate(prefab, puntoDos, Quaternion.identity);

         /*
         // EJEMPLO DE LAS POSICONES//
         // SOLO FUNCIONA EN EL EJE X/Z

         puntoUno = new Vector3(364.2f, 24.24395f, 560.7f);

         puntoDos = new Vector3(353.8753f, 24.02839f, 577.9432f);

         puntoAyuda = new Vector3(puntoDos.x, 24.02839f, puntoUno.z);


         adyacente = Vector3.Distance(puntoUno, puntoAyuda);

         Debug.Log(adyacente);

         float cua1 = puntoAyuda.x - puntoUno.x;
         float cua2 = puntoAyuda.z - puntoUno.z;


         // Debug.Log(Mathf.Pow(2,3));
         //Ecuacion matematica de una distancia a otro punto
         // adyacente = Mathf.Sqrt(Mathf.Pow(cua1, 2) + Mathf.Pow(cua2, 2));
         // Debug.Log(adyacente);

         hipotenusa = 20f;
         angulo = Mathf.Acos(adyacente / hipotenusa) * (180 / Mathf.PI);

         Debug.Log(angulo);

         float Pmediox = (puntoDos.x + puntoUno.x) / 2;
         float Pmedioz = (puntoDos.z + puntoUno.z) / 2;

         Instantiate(linea, new Vector3(Pmediox, 24.24395f, Pmedioz), Quaternion.Euler(0, angulo, 0));
         Instantiate(prefab, puntoUno, Quaternion.identity);
         Instantiate(prefab, puntoDos, Quaternion.identity);
     }*/

}
