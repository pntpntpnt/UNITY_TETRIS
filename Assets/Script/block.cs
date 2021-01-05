using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block
{

    internal struct shape
    {
        internal D.ST[,] A;
        internal D.ST[,] B;
        internal D.ST[,] C;
        internal D.ST[,] D;
    }


    internal shape shp;

    internal Block(D.ST shapeIndex) {
        shp = new shape();

        switch (shapeIndex) {
            case D.ST.III:
                shp.A = D.III;
                shp.B = D.III_B;
                shp.C = D.III_C;
                shp.D = D.III_D;
                break;
            case D.ST.JJJ:
                shp.A = D.JJJ;
                shp.B = D.JJJ_B;
                shp.C = D.JJJ_C;
                shp.D = D.JJJ_D;
                break;
            case D.ST.LLL:
                shp.A = D.LLL;
                shp.B = D.LLL_B;
                shp.C = D.LLL_C;
                shp.D = D.LLL_D;
                break;
            case D.ST.OOO:
                shp.A = D.OOO;
                shp.B = D.OOO_B;
                shp.C = D.OOO_C;
                shp.D = D.OOO_D;
                break;                
            case D.ST.SSS:
                shp.A = D.SSS;
                shp.B = D.SSS_B;
                shp.C = D.SSS_C;
                shp.D = D.SSS_D;
                break;                
            case D.ST.TTT:
                shp.A = D.TTT;
                shp.B = D.TTT_B;
                shp.C = D.TTT_C;
                shp.D = D.TTT_D;
                break;               
            case D.ST.ZZZ:
                shp.A = D.ZZZ;
                shp.B = D.ZZZ_B;
                shp.C = D.ZZZ_C;
                shp.D = D.ZZZ_D;
                break;
        }
    }
}

