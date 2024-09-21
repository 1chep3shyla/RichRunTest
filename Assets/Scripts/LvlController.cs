using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LvlController : MonoBehaviour
{
    public Image[] lvlImg;
    public GameObject[] levelGM;

    void Start()
    {
        for(int i = 1; i < GameBack.Instance.curLvl; i++)
        {
            lvlImg[i-1].color = new Color(0,255,0);
        }
        for(int i =0; i < levelGM.Length; i++)
        {
            levelGM[i].SetActive(false);
        }
        levelGM[GameBack.Instance.curLvl].SetActive(true);
    }
}
