using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public GameObject cancasWin;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Win();
        }
    }

    public void Win()
    {
        Debug.Log("Победа");
        cancasWin.SetActive(true);
        PlayerBounty.instance.GetComponent<PlayerMovement>().stop = true;
       // PlayerBounty.instance.GetComponent<PlayerMovement>().enabled = false;
        GameBack.Instance.curLvl++;
    }
}