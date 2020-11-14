using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;

public class GuardarPosiciones : MonoBehaviour
{
    public static GuardarPosiciones guardarPosiciones;
    // private List<Vector3> posicion;
    // private List<float> grados;

    private string cadenaPosiciones;
    private string cadenaGrados;
    public void Start()
    {
        // posicion = new List<Vector3>();
        // grados = new List<float>();
        guardarPosiciones = this;

        //Pruebas
        // posicion.Add(new Vector3(1, 1, 1));
        // posicion.Add(new Vector3(2, 2, 2));
        // posicion.Add(new Vector3(69, 666, 7));

        // grados.Add(3f);
        // grados.Add(11f);
        // grados.Add(17f);
        // grados.Add(54151f);


        // SaveByXML(posicion, grados);

        // Debug.Log(posicion[0] + ","+ posicion[1]);
    }

    // Update is called once per frame
    public void Update()
    {

    }

    //Nota no se puede puede guardar una lista, ya que se coloca como:  <Posicion>System.Collections.Generic.List`1[UnityEngine.Vector3]</Posicion>
    //Por lo tanto hay que guardar sus valores que tiene en cada posicion
    //Metodo para guardar las listas de las posiciones en Vector3 y los angulos para posicionar el path en float
    public void SaveByXML(List<Vector3> ListaVector, List<float> ListaAngulos)
    {
        XmlDocument xmlDocument = new XmlDocument(); //Crea el documento xml

        XmlElement root = xmlDocument.CreateElement("Save");//MARKER <Save>...elements...</Save>
        root.SetAttribute("GuardarRecorrido", "File_02");//OPTIONAL

        //Prueba con un for, para guardar datos que pertenezcan a arryas o list
        for (int i = 0; i < ListaVector.Count; i++)
        {
            cadenaPosiciones = ListaVector[i].ToString();
            XmlElement listaPosiciones = xmlDocument.CreateElement("Posicion");
            listaPosiciones.InnerText = cadenaPosiciones;
            root.AppendChild(listaPosiciones);
        }

        for (int k = 0; k < ListaAngulos.Count; k++)
        {
            cadenaGrados = ListaAngulos[k].ToString();
            XmlElement listaGrados = xmlDocument.CreateElement("Grados");
            listaGrados.InnerText = cadenaGrados;
            root.AppendChild(listaGrados);
        }

        xmlDocument.AppendChild(root);
        xmlDocument.Save(Application.dataPath + "/RecorridoXML.xml");
        if (File.Exists(Application.dataPath + "/RecorridoXML.xml"))
        {
            //Guarda con la extension de los xml
            using (TextWriter sw = new StreamWriter(Application.dataPath + "/RecorridoXML.xml", false, System.Text.Encoding.UTF8))
            {
                xmlDocument.Save(sw);
            }
            Debug.Log("XML FILE SAVED");
        }
    }

}
