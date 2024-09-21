using System.Collections;
using System.Collections.Generic;
using UnityEngine;
interface IPick
{
    public void Pick();
}
public class PickUp : MonoBehaviour, IPick
{
    public int powerGive;
    public void Pick()
    {
        PlayerBounty.instance.AddBounty(powerGive);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pick();
            Destroy(gameObject);
        }
    }
}
