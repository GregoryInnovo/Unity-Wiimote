using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Globalization;

public class XmlPalmeras : MonoBehaviour
{
    
    private List<Vector3> ListaPalmeras;
    public GameObject palmeraPrefab;


    public void Start()
    {
        ListaPalmeras = new List<Vector3>();
        LoadByXML();

    }

    public void Update()
    {

    }

    private void LoadByXML()
    {
        if (File.Exists(Application.dataPath + "/PalmerasXML.xml"))
        {

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(Application.dataPath + "/PalmerasXML.xml");


            var baseNode = xmlDocument.DocumentElement;
            foreach (XmlNode node in baseNode.ChildNodes)
            {
                Debug.Log(node.Name);
                Debug.Log(node.SelectSingleNode("Posicion").InnerText);

                ListaPalmeras.Add(StringToVector3(node.SelectSingleNode("Posicion").InnerText));


            }

            Debug.Log("Tamaño lista: " + ListaPalmeras.Count);
            spawnearPalmeras();
            Debug.Log("File Founded");

        }
        else
        {
            Debug.Log("Not founded File");
        }
    }

    public  Vector3 StringToVector3(string vector)
    {
        
        if (vector.StartsWith("(") && vector.EndsWith(")"))
        {
            vector = vector.Substring(1, vector.Length - 2);
        }


        CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
        ci.NumberFormat.CurrencyDecimalSeparator = ".";
        
        string[] sArray = vector.Split(',');

        
        
        Vector3 result = new Vector3(
            float.Parse((sArray[0]), NumberStyles.Any, ci),
            float.Parse((sArray[1]), NumberStyles.Any, ci),
            float.Parse((sArray[2]), NumberStyles.Any, ci));

        Debug.Log(result);
        return result;

    }

    public void spawnearPalmeras()
    {

        for (int i = 0; i < ListaPalmeras.Count; i++)
        {
            Instantiate(palmeraPrefab, ListaPalmeras[i], Quaternion.Euler(-90, 0, 0));
        }

    }

}
