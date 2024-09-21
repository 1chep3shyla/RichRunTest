using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerBounty : MonoBehaviour
{
   public int bountyCount;
   public GameObject[] models;  
    public int[] thresholds;
    public string[] titles;
    [Space]
    public Slider bountySlider;
    public TMP_Text lvlTMP;
    public TMP_Text endLvlTMP;
    public TMP_Text bountyTMP;
    public TMP_Text bountTitleTMP;
    public TMP_Text loseMoneyTMP;
    public TMP_Text addMoneyTMP;
    public ParticleSystem addPS;
    public ParticleSystem losePS;
    public GameObject canvasLose;

    public static PlayerBounty instance;

    private int addCombo;
    private int loseCombo;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        ChangeBountyUI();
    }

    public void AddBounty(int addBounty)
    {
        Debug.Log("Добавка");
        bountyCount += addBounty;
         if (bountyCount < 0)
        {
            bountyCount = 0;
            GetComponent<PlayerMovement>().stop = true;
           // GetComponent<PlayerMovement>().enabled = false;
            canvasLose.SetActive(true);
        }
        CreateParticle(addBounty);
        ChangeBountyUI();
    }

    public void ChangeBountyUI()
    {
        Debug.Log("Cмена UI");
        lvlTMP.text = "Уровень " + (GameBack.Instance.curLvl+1).ToString("");
        endLvlTMP.text = "Уровень " + (GameBack.Instance.curLvl+1).ToString("");
        bountySlider.value = bountyCount;
        bountyTMP.text = bountyCount.ToString("");
        addMoneyTMP.text = addCombo.ToString();
        loseMoneyTMP.text = loseCombo.ToString();
        if(bountyCount >= thresholds[thresholds.Length-1])
        {
             ActivateModel(thresholds.Length-1);  
        }
        for (int i = 0; i < thresholds.Length; i++)
        {
            if (bountyCount < thresholds[i])
            {
                ActivateModel(i);  
                bountTitleTMP.text = titles[i];
                break;
            }
        }
    }

    public void CreateParticle(int bounty)
    {
        Debug.Log("Партиклы");
        
        if (bounty > 0)
        {
            addPS.Play();
            if (addMoneyTMP.transform.parent.gameObject.activeSelf)
            {
                addCombo += bounty;
                addMoneyTMP.transform.parent.GetComponent<Animator>().Play("Dissappear", 0, 0f);
                addMoneyTMP.transform.parent.GetComponent<DisableObject>().timer = 0f;
            }
            else
            {
                addMoneyTMP.transform.parent.gameObject.SetActive(true);
                
                addCombo = bounty;
            }
        }
        else if (bounty < 0)
        {
            losePS.Play();
            if (loseMoneyTMP.transform.parent.gameObject.activeSelf)
            {
                loseCombo += bounty;
                loseMoneyTMP.transform.parent.GetComponent<Animator>().Play("Dissappear", 0, 0f);
                loseMoneyTMP.transform.parent.GetComponent<DisableObject>().timer = 0f;
            }
            else
            {
                loseMoneyTMP.transform.parent.gameObject.SetActive(true);
                loseCombo = bounty;

            }
        }
    }
    private void ActivateModel(int activeIndex)
    {
        for (int i = 0; i < models.Length; i++)
        {
            models[i].SetActive(i == activeIndex); 

        }
    }
}