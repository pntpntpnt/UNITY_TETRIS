using System;

class D
{
    internal readonly static int[,]  A = new int[2, 2] {{1, 0}, {0, 1}};
    internal readonly static int[,]  B = new int[2, 2] {{0, 1}, {1, 0}};
    internal readonly static int[,]  C = new int[2, 2] {{0, 0}, {0, 0}};
    internal readonly static int[,] DD = new int[2, 2] {{1, 1}, {1, 1}};
}

class BLOCK
{
    internal struct shape
    {
        internal int[,] A;
        internal int[,] B;
    }

    internal shape shp;
    int shpIndex;
    int rotSt;

    internal BLOCK(int index) {
        shp = new shape();
        shpIndex = index;
        rotSt = 1;
        if (index == 1) {
            shp.A = D.A;
            shp.B = D.B;
        } else if (index == 2) {
            shp.A = D.C;
            shp.B = D.DD;            
        }
    }
}

class MainClass
{
    static void Main()
    {
        BLOCK blk1 = new BLOCK(1);
        BLOCK blk2 = new BLOCK(2);

        BLOCK[] blkAry = new BLOCK[2] {blk1, blk2};

        Console.Write("{0}", blkAry[1].shp.A[0, 0]); 
    }
}
