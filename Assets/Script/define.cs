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

    public const int SWIPE_THR = 16;


}