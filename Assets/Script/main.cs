using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class main : MonoBehaviour
{
    public GameObject square;

    public GameObject gameOverScrn;
    bool gameOver;

    public GameObject iii;
    public GameObject jjj;
    public GameObject lll;
    public GameObject ooo;
    public GameObject sss;
    public GameObject ttt;
    public GameObject zzz;
    GameObject i, j, l, o, s, t, z;
    GameObject i2, j2, l2, o2, s2, t2, z2;
    GameObject i3, j3, l3, o3, s3, t3, z3;
    GameObject ih, jh, lh, oh, sh, th, zh;


    GameObject gO;
    SpriteRenderer sR;
    Vector2 pos;

    byte ojmGenTiming = 10;
    byte ojmGenCnt = 0;

    public GameObject numW1_0;
    public GameObject numW2_0;
    public GameObject numW3_0;
    public GameObject numH1_0;
    public GameObject numH2_0;
    public GameObject numH3_0;
    public GameObject numH4_0;

    public GameObject numW1_1;
    public GameObject numW2_1;
    public GameObject numW3_1;
    public GameObject numH1_1;
    public GameObject numH2_1;
    public GameObject numH3_1;
    public GameObject numH4_1;

    public GameObject numW1_2;
    public GameObject numW2_2;
    public GameObject numW3_2;
    public GameObject numH1_2;
    public GameObject numH2_2;
    public GameObject numH3_2;
    public GameObject numH4_2;

    public GameObject numW1_3;
    public GameObject numW2_3;
    public GameObject numW3_3;
    public GameObject numH1_3;
    public GameObject numH2_3;
    public GameObject numH3_3;
    public GameObject numH4_3;

    float swipeThr = (float) Screen.width * 0.05f;
    float touchThr = (float) Screen.width * 0.01f;

    byte rstClickCnt;

    D.ST[,] mainFldAry = new D.ST[D.MAIN_FIELD_CELL_H, D.MAIN_FIELD_CELL_W];

    Cell[,] mainFldGui = new Cell[D.MAIN_FIELD_CELL_H, D.MAIN_FIELD_CELL_W];

    int blkX = D.INIT_POS_X;
    int blkY = D.INIT_POS_Y;
    byte gstY;

    bool hardDrop = false;


    double x0, y0, x1, y1;

    float freeFallTimer = 0f;
    float freeFallTime = 1.0f;

    bool touch;


    bool holdInit;
    bool holdEn;
    D.ST holdIndex;

    byte fixCnt;
    bool ableMove;

    int score = 0;
    int combo = 0;
    int ren = 0;
    int tSpin = 1;
    int hardDropScore = 0;
    int scoreUpCnt = 0;
    int cheat;

    byte actCnt = 0;
    bool fixTimerSetDone = false;
    int maxY = D.INIT_POS_Y;
    bool speedFix = false;


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

    int ojmScoreThr = 100;
    int ojmScoreThrCoe = 1;

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
                pos.y = (float) (D.MAIN_FIELD_CELL_H * 0.5 - 0.5) - y + D.MAIN_FLD_GUI_MARGIN;
                sR.transform.position = pos;
            }

            mainFldGui[y, x] = new Cell(sR);
            mainFldGui[y, x].color(mainFldAry[y, x]);

            // if (x == D.BLOCK_CELL_LEN - 2 && y >= D.BLOCK_CELL_LEN - 1 && y <= D.MAIN_FIELD_CELL_H - D.BLOCK_CELL_LEN) {
            //     pos.x = x - (float) (D.MAIN_FIELD_CELL_W * 0.5 - 0.5);
            //     pos.y = (float) (D.MAIN_FIELD_CELL_H * 0.5 - 0.5) - y;
            //     sR.transform.position = pos;
            // }
            // if (x == D.MAIN_FIELD_CELL_W - D.BLOCK_CELL_LEN + 1 && y >= D.BLOCK_CELL_LEN - 1 && y <= D.MAIN_FIELD_CELL_H - D.BLOCK_CELL_LEN) {
            //     pos.x = x - (float) (D.MAIN_FIELD_CELL_W * 0.5 - 0.5);
            //     pos.y = (float) (D.MAIN_FIELD_CELL_H * 0.5 - 0.5) - y;
            //     sR.transform.position = pos;
            // }
            // if (y == D.MAIN_FIELD_CELL_H - D.BLOCK_CELL_LEN + 1 && x >= D.BLOCK_CELL_LEN - 2 && x <= D.MAIN_FIELD_CELL_W - D.BLOCK_CELL_LEN + 1) {
            //     pos.x = x - (float) (D.MAIN_FIELD_CELL_W * 0.5 - 0.5);
            //     pos.y = (float) (D.MAIN_FIELD_CELL_H * 0.5 - 0.5) - y;
            //     sR.transform.position = pos;
            // }


  
        }
    }

    gameOverScrn.SetActive(false);
    gameOver = false;


    i = Instantiate(iii);
    j = Instantiate(jjj);
    l = Instantiate(lll);
    o = Instantiate(ooo);
    s = Instantiate(sss);
    t = Instantiate(ttt);
    z = Instantiate(zzz);

    i2 = Instantiate(iii);
    j2 = Instantiate(jjj);
    l2 = Instantiate(lll);
    o2 = Instantiate(ooo);
    s2 = Instantiate(sss);
    t2 = Instantiate(ttt);
    z2 = Instantiate(zzz);

    i3 = Instantiate(iii);
    j3 = Instantiate(jjj);
    l3 = Instantiate(lll);
    o3 = Instantiate(ooo);
    s3 = Instantiate(sss);
    t3 = Instantiate(ttt);
    z3 = Instantiate(zzz);

    ih = Instantiate(iii);
    jh = Instantiate(jjj);
    lh = Instantiate(lll);
    oh = Instantiate(ooo);
    sh = Instantiate(sss);
    th = Instantiate(ttt);
    zh = Instantiate(zzz);


    // Renderer r = i.GetComponent<Renderer>();
    // r.material.color = new Color(0.239f, 0.957f, 0.957f); 

    init();

    rstClickCnt = 0;

    numW2_0.SetActive(false);
    numW2_1.SetActive(false);
    numW2_2.SetActive(false);

    ren = 0;

    score = 0;

    tSpin = 1;

}

void calcScore(int basicScore) {


    if (combo == 4) combo = 8;


    score += cheat;
    cheat = 0;
    score += basicScore;
    score += hardDropScore;
    score += combo * tSpin * tSpin + combo * ren * ren;


    if (ojmScoreThr * ojmScoreThrCoe <= score) {
        addLine(UnityEngine.Random.Range(D.BLOCK_CELL_LEN - 1, D.MAIN_FIELD_CELL_W - D.BLOCK_CELL_LEN + 1));
        ojmScoreThrCoe = (int) (score / ojmScoreThr) + 1;
    }


    hardDropScore = 0;

    // Debug.Log("score : " + score);

    Color c;
    if (combo == 8) {
        c = new Color(0.239f, 0.957f, 0.957f);
    }
    else if (tSpin >= 2) {
        c = new Color(0.957f, 0.239f, 0.957f);
    }
    else if (ren >= 3) {
        c = new Color(0.957f, 0.957f, 0.239f);
    }
    else {
        c = new Color(0.8f, 0.8f, 0.8f, 1.0f);
    }
    numH1_0.GetComponent<SpriteRenderer>().color = c;
    numH2_0.GetComponent<SpriteRenderer>().color = c;
    numH3_0.GetComponent<SpriteRenderer>().color = c;
    numH4_0.GetComponent<SpriteRenderer>().color = c;
    numW1_0.GetComponent<SpriteRenderer>().color = c;
    numW2_0.GetComponent<SpriteRenderer>().color = c;
    numW3_0.GetComponent<SpriteRenderer>().color = c;
    numH1_1.GetComponent<SpriteRenderer>().color = c;
    numH2_1.GetComponent<SpriteRenderer>().color = c;
    numH3_1.GetComponent<SpriteRenderer>().color = c;
    numH4_1.GetComponent<SpriteRenderer>().color = c;
    numW1_1.GetComponent<SpriteRenderer>().color = c;
    numW2_1.GetComponent<SpriteRenderer>().color = c;
    numW3_1.GetComponent<SpriteRenderer>().color = c;
    numH1_2.GetComponent<SpriteRenderer>().color = c;
    numH2_2.GetComponent<SpriteRenderer>().color = c;
    numH3_2.GetComponent<SpriteRenderer>().color = c;
    numH4_2.GetComponent<SpriteRenderer>().color = c;
    numW1_2.GetComponent<SpriteRenderer>().color = c;
    numW2_2.GetComponent<SpriteRenderer>().color = c;
    numW3_2.GetComponent<SpriteRenderer>().color = c;
    numH1_3.GetComponent<SpriteRenderer>().color = c;
    numH2_3.GetComponent<SpriteRenderer>().color = c;
    numH3_3.GetComponent<SpriteRenderer>().color = c;
    numH4_3.GetComponent<SpriteRenderer>().color = c;
    numW1_3.GetComponent<SpriteRenderer>().color = c;
    numW2_3.GetComponent<SpriteRenderer>().color = c;
    numW3_3.GetComponent<SpriteRenderer>().color = c;


    if (score > 9999) {
        score = 9999;
    }

    freeFallTime = 1.0f - (float) score * 0.00033f;
    if (freeFallTime <= 0.01) freeFallTime = 0.01f;

    switch (score % 10)
    {
        case 0:
            numH1_0.SetActive(true); numH2_0.SetActive(true); numH3_0.SetActive(true); numH4_0.SetActive(true);
            numW1_0.SetActive(true); numW2_0.SetActive(false); numW3_0.SetActive(true); break;
        case 1:
            numH1_0.SetActive(false); numH2_0.SetActive(true); numH3_0.SetActive(false); numH4_0.SetActive(true);
            numW1_0.SetActive(false); numW2_0.SetActive(false); numW3_0.SetActive(false); break;
        case 2:
            numH1_0.SetActive(false); numH2_0.SetActive(true); numH3_0.SetActive(true); numH4_0.SetActive(false);
            numW1_0.SetActive(true); numW2_0.SetActive(true); numW3_0.SetActive(true); break;
        case 3:
            numH1_0.SetActive(false); numH2_0.SetActive(true); numH3_0.SetActive(false); numH4_0.SetActive(true);
            numW1_0.SetActive(true); numW2_0.SetActive(true); numW3_0.SetActive(true); break;
        case 4:
            numH1_0.SetActive(true); numH2_0.SetActive(true); numH3_0.SetActive(false); numH4_0.SetActive(true);
            numW1_0.SetActive(false); numW2_0.SetActive(true); numW3_0.SetActive(false); break;
        case 5:
            numH1_0.SetActive(true); numH2_0.SetActive(false); numH3_0.SetActive(false); numH4_0.SetActive(true);
            numW1_0.SetActive(true); numW2_0.SetActive(true); numW3_0.SetActive(true); break;
        case 6:
            numH1_0.SetActive(true); numH2_0.SetActive(false); numH3_0.SetActive(true); numH4_0.SetActive(true);
            numW1_0.SetActive(true); numW2_0.SetActive(true); numW3_0.SetActive(true); break;
        case 7:
            numH1_0.SetActive(false); numH2_0.SetActive(true); numH3_0.SetActive(false); numH4_0.SetActive(true);
            numW1_0.SetActive(true); numW2_0.SetActive(false); numW3_0.SetActive(false); break;
        case 8:
            numH1_0.SetActive(true); numH2_0.SetActive(true); numH3_0.SetActive(true); numH4_0.SetActive(true);
            numW1_0.SetActive(true); numW2_0.SetActive(true); numW3_0.SetActive(true); break;
        case 9:
            numH1_0.SetActive(true); numH2_0.SetActive(true); numH3_0.SetActive(false); numH4_0.SetActive(true);
            numW1_0.SetActive(true); numW2_0.SetActive(true); numW3_0.SetActive(true); break;
    }
    switch ((int) ((score % 100) / 10))
    {
        case 0:
            numH1_1.SetActive(true); numH2_1.SetActive(true); numH3_1.SetActive(true); numH4_1.SetActive(true);
            numW1_1.SetActive(true); numW2_1.SetActive(false); numW3_1.SetActive(true); break;
        case 1:
            numH1_1.SetActive(false); numH2_1.SetActive(true); numH3_1.SetActive(false); numH4_1.SetActive(true);
            numW1_1.SetActive(false); numW2_1.SetActive(false); numW3_1.SetActive(false); break;
        case 2:
            numH1_1.SetActive(false); numH2_1.SetActive(true); numH3_1.SetActive(true); numH4_1.SetActive(false);
            numW1_1.SetActive(true); numW2_1.SetActive(true); numW3_1.SetActive(true); break;
        case 3:
            numH1_1.SetActive(false); numH2_1.SetActive(true); numH3_1.SetActive(false); numH4_1.SetActive(true);
            numW1_1.SetActive(true); numW2_1.SetActive(true); numW3_1.SetActive(true); break;
        case 4:
            numH1_1.SetActive(true); numH2_1.SetActive(true); numH3_1.SetActive(false); numH4_1.SetActive(true);
            numW1_1.SetActive(false); numW2_1.SetActive(true); numW3_1.SetActive(false); break;
        case 5:
            numH1_1.SetActive(true); numH2_1.SetActive(false); numH3_1.SetActive(false); numH4_1.SetActive(true);
            numW1_1.SetActive(true); numW2_1.SetActive(true); numW3_1.SetActive(true); break;
        case 6:
            numH1_1.SetActive(true); numH2_1.SetActive(false); numH3_1.SetActive(true); numH4_1.SetActive(true);
            numW1_1.SetActive(true); numW2_1.SetActive(true); numW3_1.SetActive(true); break;
        case 7:
            numH1_1.SetActive(false); numH2_1.SetActive(true); numH3_1.SetActive(false); numH4_1.SetActive(true);
            numW1_1.SetActive(true); numW2_1.SetActive(false); numW3_1.SetActive(false); break;
        case 8:
            numH1_1.SetActive(true); numH2_1.SetActive(true); numH3_1.SetActive(true); numH4_1.SetActive(true);
            numW1_1.SetActive(true); numW2_1.SetActive(true); numW3_1.SetActive(true); break;
        case 9:
            numH1_1.SetActive(true); numH2_1.SetActive(true); numH3_1.SetActive(false); numH4_1.SetActive(true);
            numW1_1.SetActive(true); numW2_1.SetActive(true); numW3_1.SetActive(true); break;
    }
    switch ((int) ((score % 1000) / 100))
    {
        case 0:
            numH1_2.SetActive(true); numH2_2.SetActive(true); numH3_2.SetActive(true); numH4_2.SetActive(true);
            numW1_2.SetActive(true); numW2_2.SetActive(false); numW3_2.SetActive(true); break;
        case 1:
            numH1_2.SetActive(false); numH2_2.SetActive(true); numH3_2.SetActive(false); numH4_2.SetActive(true);
            numW1_2.SetActive(false); numW2_2.SetActive(false); numW3_2.SetActive(false); break;
        case 2:
            numH1_2.SetActive(false); numH2_2.SetActive(true); numH3_2.SetActive(true); numH4_2.SetActive(false);
            numW1_2.SetActive(true); numW2_2.SetActive(true); numW3_2.SetActive(true); break;
        case 3:
            numH1_2.SetActive(false); numH2_2.SetActive(true); numH3_2.SetActive(false); numH4_2.SetActive(true);
            numW1_2.SetActive(true); numW2_2.SetActive(true); numW3_2.SetActive(true); break;
        case 4:
            numH1_2.SetActive(true); numH2_2.SetActive(true); numH3_2.SetActive(false); numH4_2.SetActive(true);
            numW1_2.SetActive(false); numW2_2.SetActive(true); numW3_2.SetActive(false); break;
        case 5:
            numH1_2.SetActive(true); numH2_2.SetActive(false); numH3_2.SetActive(false); numH4_2.SetActive(true);
            numW1_2.SetActive(true); numW2_2.SetActive(true); numW3_2.SetActive(true); break;
        case 6:
            numH1_2.SetActive(true); numH2_2.SetActive(false); numH3_2.SetActive(true); numH4_2.SetActive(true);
            numW1_2.SetActive(true); numW2_2.SetActive(true); numW3_2.SetActive(true); break;
        case 7:
            numH1_2.SetActive(false); numH2_2.SetActive(true); numH3_2.SetActive(false); numH4_2.SetActive(true);
            numW1_2.SetActive(true); numW2_2.SetActive(false); numW3_2.SetActive(false); break;
        case 8:
            numH1_2.SetActive(true); numH2_2.SetActive(true); numH3_2.SetActive(true); numH4_2.SetActive(true);
            numW1_2.SetActive(true); numW2_2.SetActive(true); numW3_2.SetActive(true); break;
        case 9:
            numH1_2.SetActive(true); numH2_2.SetActive(true); numH3_2.SetActive(false); numH4_2.SetActive(true);
            numW1_2.SetActive(true); numW2_2.SetActive(true); numW3_2.SetActive(true); break;
    }
    switch ((int) (score / 1000))
    {
        case 0:
            numH1_3.SetActive(true); numH2_3.SetActive(true); numH3_3.SetActive(true); numH4_3.SetActive(true);
            numW1_3.SetActive(true); numW2_3.SetActive(false); numW3_3.SetActive(true); break;
        case 1:
            numH1_3.SetActive(false); numH2_3.SetActive(true); numH3_3.SetActive(false); numH4_3.SetActive(true);
            numW1_3.SetActive(false); numW2_3.SetActive(false); numW3_3.SetActive(false); break;
        case 2:
            numH1_3.SetActive(false); numH2_3.SetActive(true); numH3_3.SetActive(true); numH4_3.SetActive(false);
            numW1_3.SetActive(true); numW2_3.SetActive(true); numW3_3.SetActive(true); break;
        case 3:
            numH1_3.SetActive(false); numH2_3.SetActive(true); numH3_3.SetActive(false); numH4_3.SetActive(true);
            numW1_3.SetActive(true); numW2_3.SetActive(true); numW3_3.SetActive(true); break;
        case 4:
            numH1_3.SetActive(true); numH2_3.SetActive(true); numH3_3.SetActive(false); numH4_3.SetActive(true);
            numW1_3.SetActive(false); numW2_3.SetActive(true); numW3_3.SetActive(false); break;
        case 5:
            numH1_3.SetActive(true); numH2_3.SetActive(false); numH3_3.SetActive(false); numH4_3.SetActive(true);
            numW1_3.SetActive(true); numW2_3.SetActive(true); numW3_3.SetActive(true); break;
        case 6:
            numH1_3.SetActive(true); numH2_3.SetActive(false); numH3_3.SetActive(true); numH4_3.SetActive(true);
            numW1_3.SetActive(true); numW2_3.SetActive(true); numW3_3.SetActive(true); break;
        case 7:
            numH1_3.SetActive(false); numH2_3.SetActive(true); numH3_3.SetActive(false); numH4_3.SetActive(true);
            numW1_3.SetActive(true); numW2_3.SetActive(false); numW3_3.SetActive(false); break;
        case 8:
            numH1_3.SetActive(true); numH2_3.SetActive(true); numH3_3.SetActive(true); numH4_3.SetActive(true);
            numW1_3.SetActive(true); numW2_3.SetActive(true); numW3_3.SetActive(true); break;
        case 9:
            numH1_3.SetActive(true); numH2_3.SetActive(true); numH3_3.SetActive(false); numH4_3.SetActive(true);
            numW1_3.SetActive(true); numW2_3.SetActive(true); numW3_3.SetActive(true); break;
    }
    tSpin = 1;


}

void restart() {
    gameOver = false;
    gameOverScrn.SetActive(false);
    rstClickCnt = 0;
    for (int y = 0; y < D.MAIN_FIELD_CELL_H; y++) {
        for (int x = 0; x < D.MAIN_FIELD_CELL_W; x++) {    
            if (x < D.BLOCK_CELL_LEN - 1 || x > D.MAIN_FIELD_CELL_W - D.BLOCK_CELL_LEN
            || y < D.BLOCK_CELL_LEN - 1 || y > D.MAIN_FIELD_CELL_H - D.BLOCK_CELL_LEN) {
            } else {
                mainFldAry[y, x] = D.ST.NON; 
            }
            mainFldGui[y, x].color(mainFldAry[y, x]);
  
        }
    }

        
    blkOrderCnt = 0;
    blkOrderAryTmp = shuffleAry(blkOrderAryTmp);
    blkOrderAryTmp.CopyTo(blkOrderAry, 0);
    blkOrderAryTmp = shuffleAry(blkOrderAryTmp);
    blkOrderAryTmp.CopyTo(blkOrderAry, blkOrderAryTmp.Length);
  
    rotSt = D.ROT_ST.A;

    holdInit = true;;
    holdEn = true;

    changeBlkShp();


    if (blkIndex == D.ST.III) {
        blkY--;
        blkX--;
    }
    else if (blkIndex == D.ST.OOO) {
        blkX--;
    }
    maxY = blkY;

    putBlk();


    pos.x = D.SCRN_OUT_POS;

    ih.transform.position = pos;
    jh.transform.position = pos;
    lh.transform.position = pos;
    oh.transform.position = pos;
    sh.transform.position = pos;
    th.transform.position = pos;
    zh.transform.position = pos;


    score = 0;
    freeFallTime = 1.0f;
    combo = 0;
    ren = 0;
    tSpin = 1;
    hardDropScore = 0;
    cheat = 0;

    ojmGenCnt = 0;

    calcScore(0);

}

void init() {
    
    blkOrderCnt = 0;
    blkOrderAryTmp = shuffleAry(blkOrderAryTmp);
    blkOrderAryTmp.CopyTo(blkOrderAry, 0);
    blkOrderAryTmp = shuffleAry(blkOrderAryTmp);
    blkOrderAryTmp.CopyTo(blkOrderAry, blkOrderAryTmp.Length);
  
    rotSt = D.ROT_ST.A;

    holdInit = true;;
    holdEn = true;

    changeBlkShp();
    if (blkIndex == D.ST.III) {
        blkY--;
        blkX--;
    }
    else if (blkIndex == D.ST.OOO) {
        blkX--;
    }
    putBlk();
    cheat = 0;
    calcScore(0);


}

void holdBlk() {

    if (gameOver) {
        return;
    }
    
    if (holdInit) {

        fixTimerSetDone = false;
        CancelInvoke();
        actCnt = 0;
        speedFix = false;


        holdInit = false;
        holdEn = false;

        pos.x = D.HOLD_X_POS;
        pos.y = D.HOLD_Y_POS;
        holdIndex = blkIndex;

        switch (holdIndex)
        {
            case D.ST.III: ih.transform.position = pos; break;
            case D.ST.JJJ: jh.transform.position = pos; break;
            case D.ST.LLL: lh.transform.position = pos; break;
            case D.ST.OOO: oh.transform.position = pos; break;
            case D.ST.SSS: sh.transform.position = pos; break;
            case D.ST.TTT: th.transform.position = pos; break;
            case D.ST.ZZZ: zh.transform.position = pos; break;
        }

        delBlk();
        changeBlkShp();

        blkX = D.INIT_POS_X;
        blkY = D.INIT_POS_Y;

        if (blkIndex == D.ST.III) {
            blkY--;
            blkX--;
        }
        else if (blkIndex == D.ST.OOO) {
            blkX--;
        }
        maxY = blkY;


        if (ablePutBlk()) {
            putBlk();
        }

    }

    else if (holdEn) {

        fixTimerSetDone = false;
        CancelInvoke();
        actCnt = 0;
        speedFix = false;

        holdEn = false;

        pos.x = D.SCRN_OUT_POS;

        ih.transform.position = pos;
        jh.transform.position = pos;
        lh.transform.position = pos;
        oh.transform.position = pos;
        sh.transform.position = pos;
        th.transform.position = pos;
        zh.transform.position = pos;

        pos.x = D.HOLD_X_POS;
        pos.y = D.HOLD_Y_POS;
        switch (blkIndex)
        {
            case D.ST.III: ih.transform.position = pos; break;
            case D.ST.JJJ: jh.transform.position = pos; break;
            case D.ST.LLL: lh.transform.position = pos; break;
            case D.ST.OOO: oh.transform.position = pos; break;
            case D.ST.SSS: sh.transform.position = pos; break;
            case D.ST.TTT: th.transform.position = pos; break;
            case D.ST.ZZZ: zh.transform.position = pos; break;
        }


        delBlk();


        D.ST tmp = blkIndex;

        blkIndex = holdIndex;
        holdIndex = tmp;



        blkX = D.INIT_POS_X;
        blkY = D.INIT_POS_Y;
        if (blkIndex == D.ST.III) {
            blkY--;
            blkX--;
        }
        else if (blkIndex == D.ST.OOO) {
            blkX--;
        }
        maxY = blkY;



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
        
        rotSt = D.ROT_ST.A;


        if (ablePutBlk()) {
            putBlk();
        }




    }

}

void changeBlkShp() {
    
    if (gameOver) {
        return;
    }

    if (blkOrderCnt == D.BLOCK_NUM) {
        blkOrderCnt = 0;
        blkOrderAryTmp.CopyTo(blkOrderAry, 0);
        blkOrderAryTmp = shuffleAry(blkOrderAryTmp);
        blkOrderAryTmp.CopyTo(blkOrderAry, blkOrderAryTmp.Length);
    }

    ableMove = false;
    
    pos.x = D.SCRN_OUT_POS;

    fixCnt = 0;

    i.transform.position = pos;
    j.transform.position = pos;
    l.transform.position = pos;
    o.transform.position = pos;
    s.transform.position = pos;
    t.transform.position = pos;
    z.transform.position = pos;
    i2.transform.position = pos;
    j2.transform.position = pos;
    l2.transform.position = pos;
    o2.transform.position = pos;
    s2.transform.position = pos;
    t2.transform.position = pos;
    z2.transform.position = pos;
    i3.transform.position = pos;
    j3.transform.position = pos;
    l3.transform.position = pos;
    o3.transform.position = pos;
    s3.transform.position = pos;
    t3.transform.position = pos;
    z3.transform.position = pos;

    blkIndex = blkOrderAry[blkOrderCnt];

    pos.x = D.NEXT_X_POS;
    pos.y = D.NEXT_Y_POS;

    switch (blkOrderAry[blkOrderCnt + 1])
    {
        case D.ST.III: i.transform.position = pos; break;
        case D.ST.JJJ: j.transform.position = pos; break;
        case D.ST.LLL: l.transform.position = pos; break;
        case D.ST.OOO: o.transform.position = pos; break;
        case D.ST.SSS: s.transform.position = pos; break;
        case D.ST.TTT: t.transform.position = pos; break;
        case D.ST.ZZZ: z.transform.position = pos; break;
    }
    pos.y = D.NEXT_2_Y_POS;
    switch (blkOrderAry[blkOrderCnt + 2])
    {
        case D.ST.III: i2.transform.position = pos; break;
        case D.ST.JJJ: j2.transform.position = pos; break;
        case D.ST.LLL: l2.transform.position = pos; break;
        case D.ST.OOO: o2.transform.position = pos; break;
        case D.ST.SSS: s2.transform.position = pos; break;
        case D.ST.TTT: t2.transform.position = pos; break;
        case D.ST.ZZZ: z2.transform.position = pos; break;
    }
    pos.y = D.NEXT_3_Y_POS;
    switch (blkOrderAry[blkOrderCnt + 3])
    {
        case D.ST.III: i3.transform.position = pos; break;
        case D.ST.JJJ: j3.transform.position = pos; break;
        case D.ST.LLL: l3.transform.position = pos; break;
        case D.ST.OOO: o3.transform.position = pos; break;
        case D.ST.SSS: s3.transform.position = pos; break;
        case D.ST.TTT: t3.transform.position = pos; break;
        case D.ST.ZZZ: z3.transform.position = pos; break;
    }

    // pos.x = -7.5f;
    // pos.y = 10f;
    // zh.transform.position = pos;


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
    
    rotSt = D.ROT_ST.A;


}

byte calcGstY() {
    byte gy;
    for (gy = (byte) blkY; gy <= D.MAIN_FIELD_CELL_H - D.BLOCK_CELL_LEN; gy++) {
        for (byte y = 0; y < D.BLOCK_CELL_LEN; y++) {
            for (byte x = 0; x < D.BLOCK_CELL_LEN; x++) {
                if (blkShp[y, x] != D.ST.NON) {
                    if (mainFldAry[(byte) gy + y, blkX + x] == D.ST.FIX) {
                        return (byte) (gy - 1);
                    }
                }
            }
        }
    }
    return (byte) (gy - 1);
}


void rstBlk() {

    holdEn = true;


    fixTimerSetDone = false;
    CancelInvoke();
    actCnt = 0;
    speedFix = false;

    changeBlkShp();


    blkX = D.INIT_POS_X;
    blkY = D.INIT_POS_Y;

    if (blkIndex == D.ST.III) {
        blkY--;
        blkX--;
    }
    else if (blkIndex == D.ST.OOO) {
        blkX--;
    }

    maxY = blkY;


    if (ablePutBlk()) {
        putBlk();
    }
    else {
        for (int y = blkY; y < blkY + D.BLOCK_CELL_LEN; y++) {
            for (int x = blkX; x < blkX + D.BLOCK_CELL_LEN; x++) {
                if (blkShp[y - blkY, x - blkX] != D.ST.NON) {
                    mainFldAry[y, x] = blkShp[y - blkY, x - blkX];
                    mainFldGui[y, x].color(mainFldAry[y, x]);
                }
            }
        }
        
        fixBlk();
        gameOver = true;
        gameOverScrn.SetActive(true);
    }

}

void delBlk() {

    gstY = calcGstY();

    for (int y = blkY; y < blkY + D.BLOCK_CELL_LEN; y++) {
        for (int x = blkX; x < blkX + D.BLOCK_CELL_LEN; x++) {
            if (mainFldAry[y, x] != D.ST.FIX) {
                if (mainFldAry[y, x] != D.ST.NON) {
                    mainFldAry[y, x] = D.ST.NON;
                    mainFldGui[y, x].color(mainFldAry[y, x]);
                    mainFldGui[y - blkY + gstY, x].colorG(D.ST.NON);

                }
            }
        }
    }
}

void putBlk() {

    gstY = calcGstY();

    for (int y = blkY; y < blkY + D.BLOCK_CELL_LEN; y++) {
        for (int x = blkX; x < blkX + D.BLOCK_CELL_LEN; x++) {
            //if (mainFldAry[y, x] != D.ST.FIX) {
            if (blkShp[y - blkY, x - blkX] != D.ST.NON) {
                mainFldAry[y, x] = blkShp[y - blkY, x - blkX];
                mainFldGui[y - blkY + gstY, x].colorG(mainFldAry[y, x]);
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

bool checkGnd() {
    for (int y = 0; y < D.BLOCK_CELL_LEN; y++) {
        for (int x = 0; x < D.BLOCK_CELL_LEN; x++) {
            if (blkShp[y, x] != D.ST.NON) {
                if (mainFldAry[blkY + y + 1, blkX + x] == D.ST.FIX) {
                    return true;
                }
            }
        }
    }
    return false;
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

void delLine() {
    
    combo = 0;
    for (int y = D.MAIN_FIELD_CELL_H - D.BLOCK_CELL_LEN; y >= D.BLOCK_CELL_LEN - 1; y--) {
        if (checkLine(y)) {
            // Debug.Log("delLine : " + y);
            combo++;
            for (int yy = y; yy >= D.BLOCK_CELL_LEN - 1; yy--) {
                for (int x = D.BLOCK_CELL_LEN - 1 ; x < D.MAIN_FIELD_CELL_W - D.BLOCK_CELL_LEN + 1; x++) {
                    mainFldAry[yy, x] = mainFldAry[yy - 1, x];
                    mainFldGui[yy, x].colorF(mainFldGui[yy - 1, x].getColorId());

                    if (yy == D.BLOCK_CELL_LEN - 1) {
                        mainFldAry[D.BLOCK_CELL_LEN - 1, x] = D.ST.NON;
                        mainFldGui[D.BLOCK_CELL_LEN - 1, x].color(D.ST.NON);
                    }
                }
            }
            y++;
        }
    }
    
    
    if (combo > 0) {
        ren++;
        ojmGenCnt = 0;
    } else {
        ren = 0;
        ojmGenCnt++;
    }
    
}


void addLine(int rmX) {

    for (int y = D.BLOCK_CELL_LEN - 1; y < D.MAIN_FIELD_CELL_H - D.BLOCK_CELL_LEN + 1 - 1; y++) {
        for (int x = D.BLOCK_CELL_LEN - 1; x < D.MAIN_FIELD_CELL_W - D.BLOCK_CELL_LEN + 1; x++) {
            mainFldGui[y, x].colorF(mainFldGui[y + 1, x].getColorId());
            mainFldAry[y, x] = mainFldAry[y + 1, x];
        }
    }
    for (int x = D.BLOCK_CELL_LEN - 1; x < D.MAIN_FIELD_CELL_W - D.BLOCK_CELL_LEN + 1; x++) {
        mainFldAry[D.MAIN_FIELD_CELL_H - D.BLOCK_CELL_LEN, x] = D.ST.FIX;
        mainFldGui[D.MAIN_FIELD_CELL_H - D.BLOCK_CELL_LEN, x].color(D.ST.FIX);                
    }
    mainFldAry[D.MAIN_FIELD_CELL_H - D.BLOCK_CELL_LEN, rmX] = D.ST.NON;
    mainFldGui[D.MAIN_FIELD_CELL_H - D.BLOCK_CELL_LEN, rmX].color(D.ST.NON);                


   
}

void fixDelRstBlk() {

    fixBlk();

    delLine();

    


    calcScore(1);    

    if (ojmGenCnt >= ojmGenTiming) {
        ojmGenCnt = 0;
        addLine(UnityEngine.Random.Range(D.BLOCK_CELL_LEN - 1, D.MAIN_FIELD_CELL_W - D.BLOCK_CELL_LEN + 1));
    }

    rstBlk();

}

bool rotBlk(bool right = true) {

    bool success = true;
    delBlk();
    


    if (blkIndex == D.ST.III) {
        if (right) {
            switch (rotSt) {
                case D.ROT_ST.A:
                    blkShp = blk.shp.B; rotSt = D.ROT_ST.B;
                    if (!ablePutBlk()) {blkX = blkX - 2; blkY = blkY + 0;}
                    if (!ablePutBlk()) {blkX = blkX + 3; blkY = blkY - 0;}
                    if (!ablePutBlk()) {blkX = blkX - 3; blkY = blkY + 1;}
                    if (!ablePutBlk()) {blkX = blkX + 3; blkY = blkY - 3;}
                    if (!ablePutBlk()) {blkX = blkX - 1; blkY = blkY + 2;
                        blkShp = blk.shp.A; rotSt = D.ROT_ST.A; success = false;}
                    break;
                case D.ROT_ST.B:
                    blkShp = blk.shp.C; rotSt = D.ROT_ST.C;
                    if (!ablePutBlk()) {blkX = blkX - 1; blkY = blkY + 0;}
                    if (!ablePutBlk()) {blkX = blkX + 3; blkY = blkY + 0;}
                    if (!ablePutBlk()) {blkX = blkX - 3; blkY = blkY - 2;}
                    if (!ablePutBlk()) {blkX = blkX + 3; blkY = blkY + 3;}
                    if (!ablePutBlk()) {blkX = blkX - 2; blkY = blkY - 1;
                        blkShp = blk.shp.B; rotSt = D.ROT_ST.B; success = false;}
                    break;
                case D.ROT_ST.C:
                    blkShp = blk.shp.D; rotSt = D.ROT_ST.D;
                    if (!ablePutBlk()) {blkX = blkX + 2; blkY = blkY + 0;}
                    if (!ablePutBlk()) {blkX = blkX - 3; blkY = blkY - 0;}
                    if (!ablePutBlk()) {blkX = blkX + 3; blkY = blkY - 1;}
                    if (!ablePutBlk()) {blkX = blkX - 3; blkY = blkY + 3;}
                    if (!ablePutBlk()) {blkX = blkX + 1; blkY = blkY - 2;
                        blkShp = blk.shp.C; rotSt = D.ROT_ST.C; success = false;}
                    break;
                case D.ROT_ST.D:
                    blkShp = blk.shp.A; rotSt = D.ROT_ST.A;
                    if (!ablePutBlk()) {blkX = blkX - 2; blkY = blkY + 0;}
                    if (!ablePutBlk()) {blkX = blkX + 3; blkY = blkY + 0;}
                    if (!ablePutBlk()) {blkX = blkX + 0; blkY = blkY + 2;}
                    if (!ablePutBlk()) {blkX = blkX - 3; blkY = blkY - 3;}
                    if (!ablePutBlk()) {blkX = blkX + 2; blkY = blkY + 1;
                        blkShp = blk.shp.D; rotSt = D.ROT_ST.D; success = false;}
                    break;
            }
        }
        else {
            switch (rotSt) {
                case D.ROT_ST.A:
                    blkShp = blk.shp.D; rotSt = D.ROT_ST.D;
                    if (!ablePutBlk()) {blkX = blkX - 1; blkY = blkY + 0;}
                    if (!ablePutBlk()) {blkX = blkX + 3; blkY = blkY - 0;}
                    if (!ablePutBlk()) {blkX = blkX - 3; blkY = blkY - 2;}
                    if (!ablePutBlk()) {blkX = blkX + 3; blkY = blkY + 3;}
                    if (!ablePutBlk()) {blkX = blkX - 2; blkY = blkY - 1;
                        blkShp = blk.shp.A; rotSt = D.ROT_ST.A; success = false;}
                    break;
                case D.ROT_ST.B:
                    blkShp = blk.shp.A; rotSt = D.ROT_ST.A;
                    if (!ablePutBlk()) {blkX = blkX + 2; blkY = blkY + 0;}
                    if (!ablePutBlk()) {blkX = blkX - 3; blkY = blkY + 0;}
                    if (!ablePutBlk()) {blkX = blkX + 3; blkY = blkY - 1;}
                    if (!ablePutBlk()) {blkX = blkX - 3; blkY = blkY + 3;}
                    if (!ablePutBlk()) {blkX = blkX + 1; blkY = blkY - 2;
                        blkShp = blk.shp.B; rotSt = D.ROT_ST.B; success = false;}
                    break;
                case D.ROT_ST.C:
                    blkShp = blk.shp.B; rotSt = D.ROT_ST.B;
                    if (!ablePutBlk()) {blkX = blkX + 1; blkY = blkY + 0;}
                    if (!ablePutBlk()) {blkX = blkX - 3; blkY = blkY - 0;}
                    if (!ablePutBlk()) {blkX = blkX + 3; blkY = blkY - 0;}
                    if (!ablePutBlk()) {blkX = blkX - 3; blkY = blkY + 2;}
                    if (!ablePutBlk()) {blkX = blkX + 2; blkY = blkY - 3;
                        blkShp = blk.shp.C; rotSt = D.ROT_ST.C; success = false;}
                    break;
                case D.ROT_ST.D:
                    blkShp = blk.shp.C; rotSt = D.ROT_ST.C;
                    if (!ablePutBlk()) {blkX = blkX + 1; blkY = blkY + 0;}
                    if (!ablePutBlk()) {blkX = blkX - 3; blkY = blkY + 0;}
                    if (!ablePutBlk()) {blkX = blkX + 0; blkY = blkY + 1;}
                    if (!ablePutBlk()) {blkX = blkX + 3; blkY = blkY - 3;}
                    if (!ablePutBlk()) {blkX = blkX - 1; blkY = blkY + 2;
                        blkShp = blk.shp.D; rotSt = D.ROT_ST.D; success = false;}
                    break;
            }
        }
    } else {
        if (right) {
            switch (rotSt) {
                case D.ROT_ST.A:
                    blkShp = blk.shp.B; rotSt = D.ROT_ST.B; 
                    if (!ablePutBlk()) {blkX = blkX - 1; blkY = blkY + 0;}
                    if (!ablePutBlk()) {blkX = blkX + 0; blkY = blkY - 1;}
                    if (!ablePutBlk()) {blkX = blkX + 1; blkY = blkY + 3;}
                    if (!ablePutBlk()) {blkX = blkX - 1; blkY = blkY + 0;}
                    if (!ablePutBlk()) {blkX = blkX + 1; blkY = blkY - 2;
                        blkShp = blk.shp.A; rotSt = D.ROT_ST.A; success = false;}
                    break;
                case D.ROT_ST.B:
                    blkShp = blk.shp.C; rotSt = D.ROT_ST.C;
                    if (!ablePutBlk()) {blkX = blkX + 1; blkY = blkY + 0;}
                    if (!ablePutBlk()) {blkX = blkX + 0; blkY = blkY + 1;}
                    if (!ablePutBlk()) {blkX = blkX - 1; blkY = blkY - 3;}
                    if (!ablePutBlk()) {blkX = blkX + 1; blkY = blkY - 0;}
                    if (!ablePutBlk()) {blkX = blkX - 1; blkY = blkY + 2;
                        blkShp = blk.shp.B; rotSt = D.ROT_ST.B; success = false;}
                    break;
                case D.ROT_ST.C:
                    blkShp = blk.shp.D; rotSt = D.ROT_ST.D;
                    if (!ablePutBlk()) {blkX = blkX + 1; blkY = blkY + 0;}
                    if (!ablePutBlk()) {blkX = blkX + 0; blkY = blkY - 1;}
                    if (!ablePutBlk()) {blkX = blkX - 1; blkY = blkY + 3;}
                    if (!ablePutBlk()) {blkX = blkX + 1; blkY = blkY - 0;}
                    if (!ablePutBlk()) {blkX = blkX - 1; blkY = blkY - 2;
                        blkShp = blk.shp.C; rotSt = D.ROT_ST.C; success = false;}
                    break;
                case D.ROT_ST.D:
                    blkShp = blk.shp.A; rotSt = D.ROT_ST.A;
                    if (!ablePutBlk()) {blkX = blkX - 1; blkY = blkY + 0;}
                    if (!ablePutBlk()) {blkX = blkX + 0; blkY = blkY + 1;}
                    if (!ablePutBlk()) {blkX = blkX + 1; blkY = blkY - 3;}
                    if (!ablePutBlk()) {blkX = blkX - 1; blkY = blkY - 0;}
                    if (!ablePutBlk()) {blkX = blkX + 1; blkY = blkY + 2;
                        blkShp = blk.shp.D; rotSt = D.ROT_ST.D; success = false;}
                    break;
            }
        } else {
            ///
            switch (rotSt) {
                case D.ROT_ST.A:
                    blkShp = blk.shp.D; rotSt = D.ROT_ST.D;
                    if (!ablePutBlk()) {blkX = blkX + 1; blkY = blkY + 0;}
                    if (!ablePutBlk()) {blkX = blkX + 0; blkY = blkY - 1;}
                    if (!ablePutBlk()) {blkX = blkX - 1; blkY = blkY + 3;}
                    if (!ablePutBlk()) {blkX = blkX + 1; blkY = blkY + 0;}
                    if (!ablePutBlk()) {blkX = blkX - 1; blkY = blkY - 2;
                        blkShp = blk.shp.A; rotSt = D.ROT_ST.A; success = false;}
                    break;
                case D.ROT_ST.B:
                    blkShp = blk.shp.A; rotSt = D.ROT_ST.A;
                    if (!ablePutBlk()) {blkX = blkX + 1; blkY = blkY + 0;}
                    if (!ablePutBlk()) {blkX = blkX + 0; blkY = blkY + 1;}
                    if (!ablePutBlk()) {blkX = blkX - 1; blkY = blkY - 3;}
                    if (!ablePutBlk()) {blkX = blkX + 1; blkY = blkY - 0;}
                    if (!ablePutBlk()) {blkX = blkX - 1; blkY = blkY + 2;
                        blkShp = blk.shp.B; rotSt = D.ROT_ST.B; success = false;}
                    break;
                case D.ROT_ST.C:
                    blkShp = blk.shp.B; rotSt = D.ROT_ST.B;
                    if (!ablePutBlk()) {blkX = blkX - 1; blkY = blkY + 0;}
                    if (!ablePutBlk()) {blkX = blkX + 0; blkY = blkY - 1;}
                    if (!ablePutBlk()) {blkX = blkX + 1; blkY = blkY + 3;}
                    if (!ablePutBlk()) {blkX = blkX - 1; blkY = blkY - 0;}
                    if (!ablePutBlk()) {blkX = blkX + 1; blkY = blkY - 2;
                        blkShp = blk.shp.C; rotSt = D.ROT_ST.C; success = false;}
                    break;
                case D.ROT_ST.D:
                    blkShp = blk.shp.C; rotSt = D.ROT_ST.C;
                    if (!ablePutBlk()) {blkX = blkX - 1; blkY = blkY + 0;}
                    if (!ablePutBlk()) {blkX = blkX + 0; blkY = blkY + 1;}
                    if (!ablePutBlk()) {blkX = blkX + 1; blkY = blkY - 3;}
                    if (!ablePutBlk()) {blkX = blkX - 1; blkY = blkY - 0;} 
                    if (!ablePutBlk()) {blkX = blkX + 1; blkY = blkY + 2;
                        blkShp = blk.shp.D; rotSt = D.ROT_ST.D; success = false;}
                    break;
            }
            ///
        }
    }

    putBlk();


    return success;

}

static D.ST[] shuffleAry(D.ST[] ary) {

    D.ST[] tmp = new D.ST[ary.Length];
    int ran;

    for (int i = ary.Length - 1; i >= 0 ; i--) {
        ran = UnityEngine.Random.Range(0, i + 1);
        tmp[i] = ary[ran];
        ary[ran] = ary[i];
    }
    return tmp;
}

void checkTspin() {

    if (blkIndex != D.ST.TTT) {
        tSpin = 1;
        return;
    }


    if (rotSt == D.ROT_ST.C) {
        if (mainFldAry[blkY, blkX + 2] == D.ST.FIX) {
            if (mainFldAry[blkY + 2, blkX + 2] == D.ST.FIX) {
                if (mainFldAry[blkY + 2, blkX] == D.ST.FIX) {
                    tSpin = 2;
                    // Debug.Log(tSpin);
                    return;
                }
            }
        }
    }
    else if (rotSt == D.ROT_ST.B || rotSt == D.ROT_ST.D) {
        if (mainFldAry[blkY + 2, blkX + 2] == D.ST.FIX) {
            if (mainFldAry[blkY + 2, blkX] == D.ST.FIX) {
                if (mainFldAry[blkY, blkX + 2] == D.ST.FIX) {
                    if (mainFldAry[blkY, blkX] == D.ST.FIX) {
                        tSpin = 3;
                        // Debug.Log(tSpin);
                        return;
                    }
                }
            }
        }
    }

    tSpin = 1;
    return;

}


// Update is called once per frame
void Update()
{


    if (gameOver) {
        if (Input.GetMouseButtonDown(0)) {
            rstClickCnt++;
        }
        if (rstClickCnt == 3) {
            rstClickCnt++;
            restart();
        }
        fixTimerSetDone = false;
        CancelInvoke();
        actCnt = 0;
        speedFix = false;

        return;
    }




    if (checkGnd()) {
        if (speedFix) {
            speedFix = false;
            actCnt = 0;

            fixDelRstBlk();
            return;
        }
        if (!fixTimerSetDone) {
            CancelInvoke();
            Invoke("fixDelRstBlk", D.FIX_MARGIN);
            fixTimerSetDone = true;
        }
    
    }


    freeFallTimer += Time.deltaTime;
    if (freeFallTimer > freeFallTime){
        mvBlk(0, 1);
        if (blkY > maxY) {
            maxY = blkY;
            actCnt = 0;
            speedFix = false;
        }
        freeFallTimer = 0f;
    }


    if (Input.GetMouseButtonDown(0)) {

        ableMove = true;

        x0 = Input.mousePosition.x;
        y0 = Input.mousePosition.y;
        x1 = x0;
        y1 = y0;


        if (x0 < Screen.width * 0.1) {
            holdBlk();
            touch = false;
            return;
        }
        else if (y0 < Screen.height * 0.1) {
            scoreUpCnt++;
            if (scoreUpCnt >= 5) {
                scoreUpCnt = 0;
                cheat += 1000;
                // calcScore(0);
            }
        }

        touch = true;


    }

    if (Input.GetMouseButtonUp(0)) {

        if (touch && ableMove && !hardDrop) {
            touch = false;

            bool right = true;
            if (x0 < Screen.width * 0.5) right = false;
        
            if (rotBlk(right)) {

                checkTspin();

                actCnt++;
                if (actCnt >= 15) speedFix = true;


                if (fixTimerSetDone) {
                    CancelInvoke();
                    fixTimerSetDone = false;
                }

                if (blkY > maxY) {
                    maxY = blkY;
                    actCnt = 0;
                    speedFix = false;
                }

            }
        }


        if (y1 - y0 > swipeThr && ableMove) { // --- HARD DROP ---
            x0 = x1;
            y0 = y1;
            hardDrop = true;
            for (int i = 0; i < D.MAIN_FIELD_CELL_H; i++) {
                if (!mvBlk(0, 1)) {
                    hardDropScore = 1;
                    fixDelRstBlk();
                    freeFallTimer = 0f;
                    hardDrop = false;
                    return;
                }
            }

        }
    }

    if (Input.GetMouseButton(0)) {
        x1 = Input.mousePosition.x;
        y1 = Input.mousePosition.y;

        if (Mathf.Abs((float) (x1 - x0)) > touchThr || Mathf.Abs((float) (y1 - y0)) > touchThr) {
            touch = false;
        }

    }
    
    if (x1 - x0 > swipeThr && y1 - y0 < swipeThr && ableMove) {
        x0 = x1;
        y0 = y1;
        if (mvBlk(1, 0)) {

            actCnt++;
            if (actCnt >= 15) speedFix = true;


            if (fixTimerSetDone) {
                CancelInvoke();
                fixTimerSetDone = false;

            }
    
        }
    }
    else if (x0 - x1 > swipeThr && y1 - y0 < swipeThr && ableMove) {
        x0 = x1;
        y0 = y1;
        if (mvBlk(-1, 0)) {
            actCnt++;
            if (actCnt >= 15) speedFix = true;

            if (fixTimerSetDone) {
                CancelInvoke();
                fixTimerSetDone = false;

            }
        }
    }
    else if (y0 - y1 > swipeThr && y1 - y0 < swipeThr && ableMove) {
        x0 = x1;
        y0 = y1;
        if (!mvBlk(0, 1)) {
            fixCnt++;
            if (fixCnt == 3) {
                fixCnt = 0;
                fixDelRstBlk();
            }
        }
        else {
           if (blkY > maxY) {
               maxY = blkY;
               actCnt = 0;
               speedFix = false;
           }
        }
         
        freeFallTimer = 0f;
   }




}




}