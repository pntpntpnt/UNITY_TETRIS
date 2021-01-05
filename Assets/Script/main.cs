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

    float freeFallTimer = 0f;
    
    bool touch;

    D.ST[] blkOrderAry = new D.ST[D.BLOCK_NUM + D.BLOCK_NUM] {
        D.ST.III, D.ST.JJJ, D.ST.LLL, D.ST.OOO, D.ST.SSS, D.ST.TTT, D.ST.ZZZ,
        D.ST.III, D.ST.JJJ, D.ST.LLL, D.ST.OOO, D.ST.SSS, D.ST.TTT, D.ST.ZZZ
    };

    D.ST[] blkOrderAryTmp = new D.ST[D.BLOCK_NUM] {
        D.ST.III, D.ST.JJJ, D.ST.LLL, D.ST.OOO, D.ST.SSS, D.ST.TTT, D.ST.ZZZ
    };



    static Block blkI = new Block(D.ST.III);
    static Block blkJ = new Block(D.ST.JJJ);
    static Block blkL = new Block(D.ST.LLL);
    static Block blkO = new Block(D.ST.OOO);
    static Block blkS = new Block(D.ST.SSS);
    static Block blkT = new Block(D.ST.TTT);
    static Block blkZ = new Block(D.ST.ZZZ);
    static Block[] blkBag = new Block[D.BLOCK_NUM] {blkI, blkJ, blkL, blkO, blkS, blkT, blkZ};

    short blkOrderCnt;
    D.ST blkIndex;
    static Block blk;
    D.ROT_ST rotSt;
    D.ST[,] blkShp = new D.ST[D.BLOCK_CELL_LEN, D.BLOCK_CELL_LEN];


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

    init();
    
}

void init() {
    
    blkOrderCnt = 0;
    blkOrderAryTmp = shuffleAry(blkOrderAryTmp);
    blkOrderAryTmp.CopyTo(blkOrderAry, 0);
    blkOrderAryTmp = shuffleAry(blkOrderAryTmp);
    blkOrderAryTmp.CopyTo(blkOrderAry, blkOrderAryTmp.Length);
  
    rotSt = D.ROT_ST.A;

    changeBlkShp();
    putBlk();



}

void changeBlkShp() {
    

    if (blkOrderCnt == D.BLOCK_NUM) {
        blkOrderCnt = 0;
        blkOrderAryTmp.CopyTo(blkOrderAry, 0);
        blkOrderAryTmp = shuffleAry(blkOrderAryTmp);
        blkOrderAryTmp.CopyTo(blkOrderAry, blkOrderAryTmp.Length);
    }

    blkIndex = blkOrderAry[blkOrderCnt];
    blkOrderCnt++;

    switch (blkIndex)
    {
        case D.ST.III: blk = blkI; break;
        case D.ST.JJJ: blk = blkJ; break;
        case D.ST.LLL: blk = blkL; break;
        case D.ST.OOO: blk = blkO; break;
        case D.ST.SSS: blk = blkS; break;
        case D.ST.TTT: blk = blkT; break;
        case D.ST.ZZZ: blk = blkZ; break;
    }

    blkShp = blk.shp.A;


}


void rstBlk() {


    blkX = D.INIT_POS_X;
    blkY = D.INIT_POS_Y;

    changeBlkShp();

    if (ablePutBlk()) {
        putBlk();
    }

}

void delBlk() {
    for (int y = blkY; y < blkY + D.BLOCK_CELL_LEN; y++) {
        for (int x = blkX; x < blkX + D.BLOCK_CELL_LEN; x++) {
            if (mainFldAry[y, x] != D.ST.FIX) {
                if (mainFldAry[y, x] != D.ST.NON) {
                    mainFldAry[y, x] = D.ST.NON;
                    mainFldGui[y, x].color(mainFldAry[y, x]);
                }
            }
        }
    }
}

void putBlk() {
    for (int y = blkY; y < blkY + D.BLOCK_CELL_LEN; y++) {
        for (int x = blkX; x < blkX + D.BLOCK_CELL_LEN; x++) {
            //if (mainFldAry[y, x] != D.ST.FIX) {
            if (blkShp[y - blkY, x - blkX] != D.ST.NON) {
                mainFldAry[y, x] = blkShp[y - blkY, x - blkX];
                mainFldGui[y, x].color(mainFldAry[y, x]);
            }
        }
    }
}

bool ablePutBlk() {
    for (int y = 0; y < D.BLOCK_CELL_LEN; y++) {
        for (int x = 0; x < D.BLOCK_CELL_LEN; x++) {
            if (blkShp[y, x] != D.ST.NON) {
                if (mainFldAry[blkY + y, blkX + x] == D.ST.FIX) {
                    return false;
                }
            }
        }
    }
    return true;
}

void fixBlk() {
    for (int y = blkY; y < blkY + D.BLOCK_CELL_LEN; y++) {
        for (int x = blkX; x < blkX + D.BLOCK_CELL_LEN; x++) {
            if (blkShp[y- blkY, x - blkX] != D.ST.NON) {
                mainFldGui[y, x].colorF(mainFldAry[y, x]);

                mainFldAry[y, x] = D.ST.FIX;
            }
        }
    }
}

bool mvBlk(int dx, int dy) {
    delBlk();

    bool mv = true;
    blkX += dx;
    blkY += dy;

    if (!ablePutBlk()) {
        blkX -= dx;
        blkY -= dy;
        mv = false;
    }
    putBlk();
    return mv;

}

bool checkLine(int y) {
    for (int x = D.BLOCK_CELL_LEN - 1 ; x < D.MAIN_FIELD_CELL_W - D.BLOCK_CELL_LEN + 1; x++) {
        if (mainFldAry[y, x] != D.ST.FIX) {
            return false;
        }
    }
    return true;
}

void delLine(int y) {
    

    while (true) {
        for (int x = D.BLOCK_CELL_LEN - 1 ; x < D.MAIN_FIELD_CELL_W - D.BLOCK_CELL_LEN + 1; x++) {
            mainFldAry[y, x] = mainFldAry[y - 1, x];
            mainFldGui[y, x].colorF(mainFldGui[y - 1, x].getColorId());
            //.colorF(mainFldAry[y, x]);
            // mainFldAry[y, x] = D.ST.SSS;        
            // mainFldGui[y, x].color(mainFldAry[y, x]);
            // Debug.Log(mainFldAry);

        }
        
        y--;

        if (y == D.BLOCK_CELL_LEN - 1) {
            for (int x = D.BLOCK_CELL_LEN - 1 ; x < D.MAIN_FIELD_CELL_W - D.BLOCK_CELL_LEN + 1; x++) {
            mainFldAry[y, x] = D.ST.NON;
            mainFldGui[y, x].color(mainFldAry[y, x]);
            // mai nFldAry[y, x] = mainFldAry[y, x];        
            // mainFldGui[y, x].color(mainFldAry[y, x]);
            }
            return;
        }
    }
}

void fixDelRstBlk() {
    fixBlk();
    for (int y = D.MAIN_FIELD_CELL_H - D.BLOCK_CELL_LEN; y >= D.BLOCK_CELL_LEN - 1; y--) {
        if (checkLine(y)) {
            delLine(y);
            y = D.MAIN_FIELD_CELL_H - D.BLOCK_CELL_LEN + 1;
        }
    }



    rstBlk();
}

void rotBlk() {
    delBlk();

    switch (rotSt) {
        case D.ROT_ST.A: blkShp = blk.shp.B; rotSt = D.ROT_ST.B; break;
        case D.ROT_ST.B: blkShp = blk.shp.C; rotSt = D.ROT_ST.C; break;
        case D.ROT_ST.C: blkShp = blk.shp.D; rotSt = D.ROT_ST.D; break;
        case D.ROT_ST.D: blkShp = blk.shp.A; rotSt = D.ROT_ST.A; break;
    }
    // blk.rotShp();
    // blkShp = blk.shp;
    if (ablePutBlk()) {
        putBlk();
    }
}

static D.ST[] shuffleAry(D.ST[] ary) {

    // Random r = new System.Random();
    D.ST[] tmp = new D.ST[ary.Length];
    int ran;

    for (int i = ary.Length - 1; i >= 0 ; i--) {
        ran = Random.Range(0, i + 1);
        //ran = r.Next(0, i + 1);
        tmp[i] = ary[ran];
        ary[ran] = ary[i];
    }
    return tmp;
}


// Update is called once per frame
void Update()
{
    freeFallTimer += Time.deltaTime;
    if (freeFallTimer > D.FREE_FALL_TIME){
        if (!mvBlk(0, 1)) {
            fixDelRstBlk();
        }
        freeFallTimer = 0f;
    }


    if (Input.GetMouseButtonDown(0)) {
        x0 = Input.mousePosition.x;
        y0 = Input.mousePosition.y;
        x1 = x0;
        y1 = y0;
        touch = true;
    }

    if (Input.GetMouseButtonUp(0)) {

        if (touch) {
            rotBlk();
        }


        if (y1 - y0 > D.SWIPE_THR) {
            x0 = x1;
            y0 = y1;
            for (int i = 0; i < D.MAIN_FIELD_CELL_H; i++) {
                if (!mvBlk(0, 1)) {
                    fixDelRstBlk();
                    freeFallTimer = 0f;
                    return;
                }
            }
        }
    }

    if (Input.GetMouseButton(0)) {
        x1 = Input.mousePosition.x;
        y1 = Input.mousePosition.y;

        if (Mathf.Abs((float) (x1 - x0)) > D.TOUCH_JUDGE_THR || Mathf.Abs((float) (y1 - y0)) > D.TOUCH_JUDGE_THR) {
            touch = false;
        }

    }
    
    if (x1 - x0 > D.SWIPE_THR) {
        x0 = x1;
        y0 = y1;
        mvBlk(1, 0);
    }
    else if (x0 - x1 > D.SWIPE_THR) {
        x0 = x1;
        y0 = y1;
        mvBlk(-1, 0);
    }
    else if (y0 - y1 > D.SWIPE_THR) {
        x0 = x1;
        y0 = y1;
        if (!mvBlk(0, 1)) {
            fixDelRstBlk();
        }
        freeFallTimer = 0f;
   }




}




}