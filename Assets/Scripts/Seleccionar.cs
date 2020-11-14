using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Seleccionar : MonoBehaviour
{
    public Material materialDeSeleccion;
    private Material materialInicial;
    private Transform seleccion1;
    private bool bloqueado;
    private GameObject info;



    private void Start()
    {
        bloqueado = true;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.T))
        {
            bloqueado = !bloqueado;

        }

        if (bloqueado == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            this.gameObject.GetComponent<Camara>().enabled = true;


        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            this.gameObject.GetComponent<Camara>().enabled = false;

        }


        if (seleccion1 != null)
        {
            var seleccionRenderer = seleccion1.GetComponent<Renderer>();
            seleccionRenderer.material = materialInicial;
            seleccion1 = null;

        }

        var rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(rayo, out hit, 8f))
        {

            var seleccion = hit.transform;

            if (seleccion.CompareTag("seleccionable"))
            {
                var seleccionRenderer = seleccion.GetComponent<Renderer>();
                if (seleccionRenderer != null)
                {
                    materialInicial = seleccionRenderer.material;
                    seleccionRenderer.material = materialDeSeleccion;
                    if (Input.GetMouseButtonDown(0))
                    {


                        info = seleccion.GetChild(0).gameObject;
                        info.SetActive(true);


                        info.GetComponent<TextMesh>().text = "Posicion: " + seleccion.transform.position.ToString(); ;



                        StartCoroutine("esperar", info);




                    }

                }
                seleccion1 = seleccion;


            }


        }


    }

    IEnumerator esperar(GameObject info)
    {
        yield return new WaitForSeconds(1.5f);
        info.gameObject.SetActive(false);

    }

}
