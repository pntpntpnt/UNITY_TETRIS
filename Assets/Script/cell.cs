using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cell {

  SpriteRenderer sR;

  internal Cell(SpriteRenderer sr) {
    sR = sr;
  }

  internal void color(D.ST st) {
    switch (st)
    {
      case D.ST.NON: sR.color = new Color(0.6f, 0.6f, 0.6f, 1.0f);
        break;
      case D.ST.III: sR.color = new Color(0.239f, 0.957f, 0.957f); // 61, 244, 244
        break;
      case D.ST.JJJ: sR.color = new Color(0.239f, 0.596f, 0.957f); // 61, 152, 244
        break;
      case D.ST.LLL: sR.color = new Color(0.957f, 0.596f, 0.239f); // 244, 152, 61
        break;
      case D.ST.OOO: sR.color = new Color(0.957f, 0.957f, 0.239f); // 244, 244, 61
        break;
      case D.ST.SSS: sR.color = new Color(0.596f, 0.957f, 0.239f); // 152, 244, 61
        break;
      case D.ST.TTT: sR.color = new Color(0.957f, 0.239f, 0.957f); // 244, 61, 244
        break;
      case D.ST.ZZZ: sR.color = new Color(0.957f, 0.239f, 0.239f); // 244, 61, 61
        break;
    }
  }
  internal void colorF(D.ST st) {
    switch (st)
    {
      case D.ST.NON: sR.color = new Color(0.6f, 0.6f, 0.6f, 1.0f);
        break;
      case D.ST.III: sR.color = new Color(0.020f, 0.376f, 0.376f); // 5, 96, 96
        break;
      case D.ST.JJJ: sR.color = new Color(0.020f, 0.196f, 0.376f); // 5, 50, 96
        break;
      case D.ST.LLL: sR.color = new Color(0.376f, 0.196f, 0.020f); // 96, 50, 5
        break;
      case D.ST.OOO: sR.color = new Color(0.376f, 0.376f, 0.020f); // 96, 96, 5
        break;
      case D.ST.SSS: sR.color = new Color(0.196f, 0.376f, 0.020f); // 50, 96, 5
        break;
      case D.ST.TTT: sR.color = new Color(0.376f, 0.020f, 0.376f); // 96, 5, 96
        break;
      case D.ST.ZZZ: sR.color = new Color(0.376f, 0.020f, 0.020f); // 96, 5, 5
        break;
    }
  }

}