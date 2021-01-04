using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block
{

  internal Block() {
  }
    D.ST index;



    D.ROT_ST rotSt;
    internal D.ST[,] shp = new D.ST[D.BLOCK_CELL_LEN, D.BLOCK_CELL_LEN];


    internal D.ST[,] shpA = new D.ST[D.BLOCK_CELL_LEN, D.BLOCK_CELL_LEN];
    internal D.ST[,] shpB = new D.ST[D.BLOCK_CELL_LEN, D.BLOCK_CELL_LEN];
    internal D.ST[,] shpC = new D.ST[D.BLOCK_CELL_LEN, D.BLOCK_CELL_LEN];
    internal D.ST[,] shpD = new D.ST[D.BLOCK_CELL_LEN, D.BLOCK_CELL_LEN];
    
    internal void rotShp() {
        switch (rotSt)
        {
            case D.ROT_ST.A:
                rotSt = D.ROT_ST.B;
                shp = shpB;
                break;
            case D.ROT_ST.B:
                rotSt = D.ROT_ST.C;
                shp = shpC;
                break;
            case D.ROT_ST.C:
                rotSt = D.ROT_ST.D;
                shp = shpD;
                break;
             case D.ROT_ST.D:
                rotSt = D.ROT_ST.A;
                shp = shpA;
                break;
        }
    }

    internal void changeShp() {

        int tmp = Random.Range(1, 8) + 1;


        rotSt = D.ROT_ST.A;

        index = (D.ST) tmp;

        switch (index)
        {
            case D.ST.III:
                shpA = D.III;
                shpB = D.III_B;
                shpC = D.III_C;
                shpD = D.III_D;
                break;
            case D.ST.JJJ:
                shpA = D.JJJ;
                shpB = D.JJJ_B;
                shpC = D.JJJ_C;
                shpD = D.JJJ_D;
                break;
            case D.ST.LLL:
                shpA = D.LLL;
                shpB = D.LLL_B;
                shpC = D.LLL_C;
                shpD = D.LLL_D;
                break;
            case D.ST.OOO:
                shpA = D.OOO;
                shpB = D.OOO_B;
                shpC = D.OOO_C;
                shpD = D.OOO_D;
                break;          
            case D.ST.SSS:
                shpA = D.SSS;
                shpB = D.SSS_B;
                shpC = D.SSS_C;
                shpD = D.SSS_D;
                break;                
            case D.ST.TTT:
                shpA = D.TTT;
                shpB = D.TTT_B;
                shpC = D.TTT_C;
                shpD = D.TTT_D;
                break;                
            case D.ST.ZZZ:
                shpA = D.ZZZ;
                shpB = D.ZZZ_B;
                shpC = D.ZZZ_C;
                shpD = D.ZZZ_D;
                break;                
                        }

    }

}