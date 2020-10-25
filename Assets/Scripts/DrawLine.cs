using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject currentLine;
    public LineRenderer lineRender;
    public EdgeCollider2D edgeCollider;
    public List<Vector2> fingerPositions;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            CreateLine();
        }
         if(Input.GetMouseButton(0)){
            Vector2 tempFingerPos = cam.ScreenToWorldPoint(Input.mousePosition);
            if(Vector2.Distance(tempFingerPos, fingerPositions[fingerPositions.Count-1]) > .1f){
                UpdateLine(tempFingerPos);
            }
        } 
    }

    void CreateLine(){

        //Event   currentEvent = Event.current;
        //Vector2 mousePos = new Vector2();

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        //mousePos.x = currentEvent.mousePosition.x;
        //mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;

        
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRender = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
        fingerPositions.Clear();        
        fingerPositions.Add(cam.ScreenToWorldPoint(Input.mousePosition));
        fingerPositions.Add(cam.ScreenToWorldPoint(Input.mousePosition));
        lineRender.SetPosition(0, fingerPositions[0]);
        lineRender.SetPosition(1, fingerPositions[1]);
        edgeCollider.points = fingerPositions.ToArray();
    }

    void UpdateLine(Vector2 newFingerPos){
        fingerPositions.Add(newFingerPos);
        lineRender.positionCount++;
        lineRender.SetPosition(lineRender.positionCount-1, newFingerPos);
        edgeCollider.points = fingerPositions.ToArray();

    }
}
