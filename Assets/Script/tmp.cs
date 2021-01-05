// using System;

// class D
// {
//     internal readonly static int[,]  A = new int[2, 2] {{1, 0}, {0, 1}};
//     internal readonly static int[,]  B = new int[2, 2] {{0, 1}, {1, 0}};
//     internal readonly static int[,]  C = new int[2, 2] {{0, 0}, {0, 0}};
//     internal readonly static int[,] DD = new int[2, 2] {{1, 1}, {1, 1}};
// }

// class BLOCK
// {
//     internal struct shape
//     {
//         internal int[,] A;
//         internal int[,] B;
//     }

//     internal shape shp;
//     int shpIndex;
//     int rotSt;

//     internal BLOCK(int index) {
//         shp = new shape();
//         shpIndex = index;
//         rotSt = 1;
//         if (index == 1) {
//             shp.A = D.A;
//             shp.B = D.B;
//         } else if (index == 2) {
//             shp.A = D.C;
//             shp.B = D.DD;            
//         }
//     }
// }

// class MainClass
// {
//     static int[] shuffleAry(int[] ary) {

//         Random r = new System.Random();
//         int[] tmp = new int[ary.Length];
//         int ran;

//         for (int i = ary.Length - 1; i >= 0 ; i--) {
//             ran = r.Next(0, i + 1);
//             tmp[i] = ary[ran];
//             ary[ran] = ary[i];
//         }
//         return tmp;
//     }


//     static void Main()
//     {
//         BLOCK blk1 = new BLOCK(1);
//         BLOCK blk2 = new BLOCK(2);

//         BLOCK[] blkAry = new BLOCK[2] {blk1, blk2};

//         int[] ary = new int[7]{1, 2, 3, 4, 5, 6, 7};
//         int[] ary2 = new int[ary.Length * 2];


//         ary = shuffleAry(ary);
//         ary.CopyTo(ary2, 0);
//         ary = shuffleAry(ary);
//         ary.CopyTo(ary2, ary.Length);
//         Console.Write("\n{0} {1} {2} {3} {4} {5} {6} - ", ary2[0], ary2[1], ary2[2], ary2[3], ary2[4], ary2[5], ary2[6]);
//         Console.Write("{0} {1} {2} {3} {4} {5} {6}\n", ary2[7], ary2[8], ary2[9], ary2[10], ary2[11], ary2[12], ary2[13]);

//         ary.CopyTo(ary2, 0);
//         ary = shuffleAry(ary);
//         ary.CopyTo(ary2, ary.Length);
//         Console.Write("\n{0} {1} {2} {3} {4} {5} {6} - ", ary2[0], ary2[1], ary2[2], ary2[3], ary2[4], ary2[5], ary2[6]);
//         Console.Write("{0} {1} {2} {3} {4} {5} {6}\n", ary2[7], ary2[8], ary2[9], ary2[10], ary2[11], ary2[12], ary2[13]);

//         ary.CopyTo(ary2, 0);
//         ary = shuffleAry(ary);
//         ary.CopyTo(ary2, ary.Length);
//         Console.Write("\n{0} {1} {2} {3} {4} {5} {6} - ", ary2[0], ary2[1], ary2[2], ary2[3], ary2[4], ary2[5], ary2[6]);
//         Console.Write("{0} {1} {2} {3} {4} {5} {6}\n", ary2[7], ary2[8], ary2[9], ary2[10], ary2[11], ary2[12], ary2[13]);

//     }
// }
