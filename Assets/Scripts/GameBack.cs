using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBack 
{
    private static GameBack _instance; 
    public int curLvl = 0;
    public static GameBack Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameBack(); 
            }
            return _instance;
        }
    }
}