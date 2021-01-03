using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class main : MonoBehaviour
{
    public GameObject square;
    GameObject gO;
    SpriteRenderer sR;
    Vector2 pos;

    D.ST[,] mainFldAry = new D.ST[D.MAIN_FIELD_CELL_H, D.MAIN_FIELD_CELL_W];

    Cell[,] mainFldGui = new Cell[D.MAIN_FIELD_CELL_H, D.MAIN_FIELD_CELL_W];

    int blkX = D.INIT_POS_X;
    int blkY = D.INIT_POS_Y;

    double x0, y0, x1, y1;


    
void Start()
{
    for (int y = 0; y < D.MAIN_FIELD_CELL_H; y++) {
        for (int x = 0; x < D.MAIN_FIELD_CELL_W; x++) {

            gO = Instantiate(square);
            sR = gO.GetComponent<SpriteRenderer>();
            pos = sR.transform.position;

            if (x < D.BLOCK_CELL_LEN - 1 || x > D.MAIN_FIELD_CELL_W - D.BLOCK_CELL_LEN
            || y < D.BLOCK_CELL_LEN - 1 || y > D.MAIN_FIELD_CELL_H - D.BLOCK_CELL_LEN) {
                mainFldAry[y, x] = D.ST.FIX; 
                pos.x = (float) -10.5;
                pos.y = y;
                sR.transform.position = pos;
            } else {
                mainFldAry[y, x] = D.ST.NON; 
                pos.x = x - (float) (D.MAIN_FIELD_CELL_W * 0.5 - 0.5);
                pos.y = (float) (D.MAIN_FIELD_CELL_H * 0.5 - 0.5) - y;
                sR.transform.position = pos;
            }

            mainFldGui[y, x] = new Cell(sR);
            mainFldGui[y, x].color(mainFldAry[y, x]);


  
        }
    }

    // debug
    mainFldAry[blkY, blkX] = D.ST.TTT;
    mainFldGui[blkY, blkX].color(mainFldAry[blkY, blkX]);



}

// Update is called once per frame
void Update()
{

    if (Input.GetMouseButtonDown(0)) {
        x0 = Input.mousePosition.x;
        y0 = Input.mousePosition.y;
    }

    if (Input.GetMouseButton(0)) {
        x1 = Input.mousePosition.x;
        y1 = Input.mousePosition.y;
    }
    
    if (x1 - x0 > D.SWIPE_THR) {
        mainFldAry[blkY, blkX] = D.ST.NON;
        mainFldGui[blkY, blkX].color(mainFldAry[blkY, blkX]);
        x0 = x1;
        y0 = y1;
        blkX += 1;
        mainFldAry[blkY, blkX] = D.ST.TTT;
        mainFldGui[blkY, blkX].color(mainFldAry[blkY, blkX]);
    }
    else if (x0 - x1 > D.SWIPE_THR) {
        mainFldAry[blkY, blkX] = D.ST.NON;
        mainFldGui[blkY, blkX].color(mainFldAry[blkY, blkX]);
        x0 = x1;
        y0 = y1;
        blkX += -1;
        mainFldAry[blkY, blkX] = D.ST.TTT;
        mainFldGui[blkY, blkX].color(mainFldAry[blkY, blkX]);
    }
    else if (y1 - y0 > D.SWIPE_THR) {
        mainFldAry[blkY, blkX] = D.ST.NON;
        mainFldGui[blkY, blkX].color(mainFldAry[blkY, blkX]);
        x0 = x1;
        y0 = y1;
        blkY += -1;
        mainFldAry[blkY, blkX] = D.ST.TTT;
        mainFldGui[blkY, blkX].color(mainFldAry[blkY, blkX]);
    }
    else if (y0 - y1 > D.SWIPE_THR) {
        mainFldAry[blkY, blkX] = D.ST.NON;
        mainFldGui[blkY, blkX].color(mainFldAry[blkY, blkX]);
        x0 = x1;
        y0 = y1;
        blkY += 1;
        mainFldAry[blkY, blkX] = D.ST.TTT;
        mainFldGui[blkY, blkX].color(mainFldAry[blkY, blkX]);
    }

}

}