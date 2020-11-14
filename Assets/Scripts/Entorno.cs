using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Entorno : MonoBehaviour
{
    public Material cieloDia, cieloNoche;
    public GameObject luzDia, luzNoche;
    public GameObject fogata;
    public GameObject lluvia;
    //  public Text ayuda;
    private bool cambioi;
    private bool cambiof;
    private bool cambiol;
    private bool presiono;

    public void Start()
    {
        cambioi = true;
        cambiof = false;
        cambiol = false;
        presiono = false;
    }
    public void Update()
    {

    }
    public void cambiarIluminacion()
    {

        if (presiono == false)
        {
            //    ayuda.CrossFadeAlpha(0, 1, false);

        }
        presiono = true;

        cambioi = !(cambioi);
        if (cambioi)
        {

            RenderSettings.skybox = cieloDia;
            luzDia.SetActive(true);
            luzNoche.SetActive(false);
            RenderSettings.ambientSkyColor = Color.gray;



        }
        else
        {
            RenderSettings.skybox = cieloNoche;
            luzDia.SetActive(false);
            luzNoche.SetActive(true);
        }

    }

    public void encenderFogata()
    {


        cambiof = !(cambiof);
        if (cambiof)
        {

            fogata.SetActive(true);


        }
        else
        {
            fogata.SetActive(false);
        }

    }

    public void activarLluvia()
    {


        cambiol = !(cambiol);
        if (cambiol)
        {

            lluvia.SetActive(true);


        }
        else
        {
            lluvia.SetActive(false);
        }

    }

    public void CambiarLago(){
        
        SceneManager.LoadScene("Lago");
    }

}
