using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MouseMove : MonoBehaviour
{
    public Vector2 mD;
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
/*         Mouse.current.WarpCursorPositionInput(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
 */
        if(Input.GetKeyDown(KeyCode.Space)){
            Vector2 cursorPos = Input.mousePosition;
            print(cursorPos);
        }
 /*        var mouse = Mouse.current;

        float mouseXValue = Input.GetAxis("Mouse X");
        float mouseYValue = Input.GetAxis("Mouse Y");
        if(Input.GetKeyDown(KeyCode.Space)){
            
            mouse.WarpCursorPosition(new Vector2(5, 5));

        }
         */
 
        /* if(mouseXValue != 0)
        {
            print("Mouse X movement: " + mouseXValue);
        }
 
        if(mouseYValue != 0)
        {
        print("Mouse Y movement: " + mouseYValue);
        } */
                
    }

}
