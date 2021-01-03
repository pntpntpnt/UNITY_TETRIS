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
      case D.ST.NON:
        sR.color = new Color(0.6f, 0.6f, 0.6f, 1.0f);
        break;

    case D.ST.TTT:
        sR.color = new Color(1.0f, 0.196f, 1.0f);
        break;
    }
  }

}