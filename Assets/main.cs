using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    public GameObject cell;


        GameObject g;
        SpriteRenderer s;
        Vector2 pos;

        float x0 = 0, x1 = 0;
        float y0 = 0, y1 = 0;

    float THR = 100;
    bool tmp = false;

    // Start is called before the first frame update
    void Start()
    {
        g = Instantiate(cell);
        s = g.GetComponent<SpriteRenderer>();
        pos = s.transform.position;
        pos.x = -5; pos.y = -10;
        s.transform.position = pos;
        

    }

    // Update is called once per frame
    void Update()
    {

         if (Input.GetMouseButtonDown(0)) {
             x0 = Input.mousePosition.x;
            y0 = Input.mousePosition.y;
            Debug.Log(x0);
            tmp = true;

         }

         if (Input.GetMouseButton(0)) {
             x1 = Input.mousePosition.x;
             y1 = Input.mousePosition.y;
            Debug.Log(x1);
            
         
         
        if(x1 - x0 > THR && tmp){
            tmp = false;
                x0 = 0;
                x1 = 0;
                y0 = 0;
                y1 = 0;
                pos.x += 1; 
                s.transform.position = pos;
                    Debug.Log("right");

        }
        else if(x0 - x1 > THR  && tmp){
            tmp = false;
                x0 = 0;
                x1 = 0;
                y0 = 0;
                y1 = 0;
                pos.x -= 1; 
                s.transform.position = pos;
        
        }
        else if(y1 - y0 > THR  && tmp){
            tmp = false;
                x0 = 0;
                x1 = 0;
                y0 = 0;
                y1 = 0;
                pos.y += 1; 
                s.transform.position = pos;
        
        }
        else if(y0 - y1 > THR  && tmp){
            tmp = false;
                x0 = 0;
                x1 = 0;
                y0 = 0;
                y1 = 0;
                pos.y -= 1; 
                s.transform.position = pos;
        
        }
         }



        // s.transform.position = pos;        }
    
        
    }
}
