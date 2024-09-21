using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObject : MonoBehaviour
{
    public float disableDelay = 1f;

    public float timer;
    private bool isActive = true;

    private void Update()
    {
        if (isActive)
        {
            timer += Time.deltaTime;

            if (timer >= disableDelay)
            {
                gameObject.SetActive(false);
                isActive = false;
                timer = 0; 
            }
        }
        else
        {
            timer += Time.deltaTime;

            if (timer >= disableDelay)
            {
                gameObject.SetActive(true);
                isActive = true; 
                timer = 0;
            }
        }
    }
}