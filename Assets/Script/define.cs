using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class D
{
    public const int MAIN_FIELD_CELL_W = 16;
    public const int MAIN_FIELD_CELL_H = 26;

    public const int BLOCK_CELL_LEN = 4;

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
        FIX
    }

    public const int INIT_POS_X = 7;
    public const int INIT_POS_Y = 3;

    public const int SWIPE_THR = 32;


    public static readonly ST[,] III = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.NON, ST.III, ST.NON, ST.NON},
    {ST.NON, ST.III, ST.NON, ST.NON},
    {ST.NON, ST.III, ST.NON, ST.NON},
    {ST.NON, ST.III, ST.NON, ST.NON}};

    public static readonly ST[,] JJJ = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.NON, ST.JJJ, ST.NON, ST.NON},
    {ST.NON, ST.JJJ, ST.NON, ST.NON},
    {ST.JJJ, ST.JJJ, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};

    public static readonly ST[,] LLL = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.LLL, ST.NON, ST.NON, ST.NON},
    {ST.LLL, ST.NON, ST.NON, ST.NON},
    {ST.LLL, ST.LLL, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};

    public static readonly ST[,] OOO = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
   {{ST.OOO, ST.OOO, ST.NON, ST.NON},
    {ST.OOO, ST.OOO, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};
    
    public static readonly ST[,] SSS = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.NON, ST.SSS, ST.SSS, ST.NON},
    {ST.SSS, ST.SSS, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};

    public static readonly ST[,] TTT = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.TTT, ST.TTT, ST.TTT, ST.NON},
    {ST.NON, ST.TTT, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};

    public static readonly ST[,] ZZZ = new ST[BLOCK_CELL_LEN, BLOCK_CELL_LEN]
    {{ST.ZZZ, ST.ZZZ, ST.NON, ST.NON},
    {ST.NON, ST.ZZZ, ST.ZZZ, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON},
    {ST.NON, ST.NON, ST.NON, ST.NON}};






}