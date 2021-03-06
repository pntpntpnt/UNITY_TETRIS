﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class D
{
    // public const float FREE_FALL_TIME = 0.5f;

    public const int MAIN_FIELD_CELL_W = 16;
    public const int MAIN_FIELD_CELL_H = 26;

    public const int BLOCK_CELL_LEN = 4;

    public const float MAIN_FLD_GUI_MARGIN = 2;

    public enum ST {
        NON,
        TMP,
        III,
        JJJ,
        LLL,
        OOO,
        SSS,
        TTT,
        ZZZ,
        FIX,
        OJM
    }

    public enum ROT_ST {
        A,
        B,
        C,
        D
    }

    public const int BLOCK_NUM = 7;

    public const int INIT_POS_X = 7;
    public const int INIT_POS_Y = 3;

    public static readonly ST[,] NON = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.NON, ST.NON, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};


    public static readonly ST[,] III = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.NON, ST.NON, ST.NON, ST.NON},
    {ST.III, ST.III, ST.III, ST.III},
    {ST.NON, ST.NON, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};
    public static readonly ST[,] III_B = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.NON, ST.NON, ST.III, ST.NON},
    {ST.NON, ST.NON, ST.III, ST.NON},
    {ST.NON, ST.NON, ST.III, ST.NON},
    {ST.NON, ST.NON, ST.III, ST.NON}};
    public static readonly ST[,] III_C = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.NON, ST.NON, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON},
    {ST.III, ST.III, ST.III, ST.III},
    {ST.NON, ST.NON, ST.NON, ST.NON}};
    public static readonly ST[,] III_D = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.NON, ST.III, ST.NON, ST.NON},
    {ST.NON, ST.III, ST.NON, ST.NON},
    {ST.NON, ST.III, ST.NON, ST.NON},
    {ST.NON, ST.III, ST.NON, ST.NON}};


    public static readonly ST[,] JJJ = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.JJJ, ST.NON, ST.NON, ST.NON},
    {ST.JJJ, ST.JJJ, ST.JJJ, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};
    public static readonly ST[,] JJJ_B = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.NON, ST.JJJ, ST.JJJ, ST.NON},
    {ST.NON, ST.JJJ, ST.NON, ST.NON},
    {ST.NON, ST.JJJ, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};
    public static readonly ST[,] JJJ_C = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.NON, ST.NON, ST.NON, ST.NON},
    {ST.JJJ, ST.JJJ, ST.JJJ, ST.NON},
    {ST.NON, ST.NON, ST.JJJ, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};
    public static readonly ST[,] JJJ_D = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.NON, ST.JJJ, ST.NON, ST.NON},
    {ST.NON, ST.JJJ, ST.NON, ST.NON},
    {ST.JJJ, ST.JJJ, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};

    public static readonly ST[,] LLL = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.NON, ST.NON, ST.LLL, ST.NON},
    {ST.LLL, ST.LLL, ST.LLL, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};
    public static readonly ST[,] LLL_B = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.NON, ST.LLL, ST.NON, ST.NON},
    {ST.NON, ST.LLL, ST.NON, ST.NON},
    {ST.NON, ST.LLL, ST.LLL, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};
    public static readonly ST[,] LLL_C = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.NON, ST.NON, ST.NON, ST.NON},
    {ST.LLL, ST.LLL, ST.LLL, ST.NON},
    {ST.LLL, ST.NON, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};
    public static readonly ST[,] LLL_D = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.LLL, ST.LLL, ST.NON, ST.NON},
    {ST.NON, ST.LLL, ST.NON, ST.NON},
    {ST.NON, ST.LLL, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};


    public static readonly ST[,] OOO = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
   {{ST.NON, ST.OOO, ST.OOO, ST.NON},
    {ST.NON, ST.OOO, ST.OOO, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};
    public static readonly ST[,] OOO_B = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
   {{ST.NON, ST.OOO, ST.OOO, ST.NON},
    {ST.NON, ST.OOO, ST.OOO, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};
    public static readonly ST[,] OOO_C = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
   {{ST.NON, ST.OOO, ST.OOO, ST.NON},
    {ST.NON, ST.OOO, ST.OOO, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};
    public static readonly ST[,] OOO_D = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
   {{ST.NON, ST.OOO, ST.OOO, ST.NON},
    {ST.NON, ST.OOO, ST.OOO, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};


    public static readonly ST[,] SSS = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.NON, ST.SSS, ST.SSS, ST.NON},
    {ST.SSS, ST.SSS, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};
    public static readonly ST[,] SSS_B = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.NON, ST.SSS, ST.NON, ST.NON},
    {ST.NON, ST.SSS, ST.SSS, ST.NON},
    {ST.NON, ST.NON, ST.SSS, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};
    public static readonly ST[,] SSS_C = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.NON, ST.NON, ST.NON, ST.NON},
    {ST.NON, ST.SSS, ST.SSS, ST.NON},
    {ST.SSS, ST.SSS, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};
    public static readonly ST[,] SSS_D = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.SSS, ST.NON, ST.NON, ST.NON},
    {ST.SSS, ST.SSS, ST.NON, ST.NON},
    {ST.NON, ST.SSS, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};


    public static readonly ST[,] TTT = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.NON, ST.TTT, ST.NON, ST.NON},
    {ST.TTT, ST.TTT, ST.TTT, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};
    public static readonly ST[,] TTT_B = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.NON, ST.TTT, ST.NON, ST.NON},
    {ST.NON, ST.TTT, ST.TTT, ST.NON},
    {ST.NON, ST.TTT, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};
    public static readonly ST[,] TTT_C = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.NON, ST.NON, ST.NON, ST.NON},
    {ST.TTT, ST.TTT, ST.TTT, ST.NON},
    {ST.NON, ST.TTT, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};
    public static readonly ST[,] TTT_D = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.NON, ST.TTT, ST.NON, ST.NON},
    {ST.TTT, ST.TTT, ST.NON, ST.NON},
    {ST.NON, ST.TTT, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};



    public static readonly ST[,] ZZZ = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.ZZZ, ST.ZZZ, ST.NON, ST.NON},
    {ST.NON, ST.ZZZ, ST.ZZZ, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};
    public static readonly ST[,] ZZZ_B = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.NON, ST.NON, ST.ZZZ, ST.NON},
    {ST.NON, ST.ZZZ, ST.ZZZ, ST.NON},
    {ST.NON, ST.ZZZ, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};
    public static readonly ST[,] ZZZ_C = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.NON, ST.NON, ST.NON, ST.NON},
    {ST.ZZZ, ST.ZZZ, ST.NON, ST.NON},
    {ST.NON, ST.ZZZ, ST.ZZZ, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};
    public static readonly ST[,] ZZZ_D = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.NON, ST.ZZZ, ST.NON, ST.NON},
    {ST.ZZZ, ST.ZZZ, ST.NON, ST.NON},
    {ST.ZZZ, ST.NON, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};


    public static float HOLD_X_POS = -6f;
    public static float HOLD_Y_POS = 11f;

    public static float NEXT_X_POS = 6f;
    public static float NEXT_Y_POS = 11f;

    public static float NEXT_2_Y_POS = 8f;
    
    public static float NEXT_3_Y_POS = 5f;
    
    public static float SCRN_OUT_POS = -16f;

    public static float FIX_MARGIN = 0.5f;



}