using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[Serializable]
public class ScoreData 
{
    //scores : zenmode
    public List<Score> scores;
    //scores2 : wave
    public List<Score> scores2;

    public ScoreData(List<Score> scores, List<Score> scores2)
    {
        this.scores = scores;
        this.scores2 = scores2;
    }
}
