using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBust : MonoBehaviour
{
    public GameObject offNeed;
       private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Bust();
        }
    }

    public void Bust()
    {
        Debug.Log("Победа");
        if(offNeed!=null)
        {
            offNeed.SetActive(false);
        }
        PlayerBounty.instance.GetComponent<PlayerMovement>().forwardSpeed += 1f;

    }
}