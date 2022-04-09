using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Score 
{
    public string name;
    public int wave;
    public float score;


    public Score(string name, float score, int wave=0)
    {
        this.name = name;
        this.score = score;
        this.wave = wave;
    }
}
