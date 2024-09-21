using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RotateNotLoop : MonoBehaviour
{
   public RotateData[] datas;
   public ParticleSystem ps;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(RotateObject());
        }
        if(ps !=null)
        {
            ps.Play();
        }
    }

    private IEnumerator RotateObject()
    {
        Debug.Log("Поворот");
        foreach (RotateData data in datas)
        {
            data.tranData.DORotate(data.rotationAngle, data.duration).SetEase(Ease.Linear);
        }
        yield return null;
    }
}

[System.Serializable]
public class RotateData
{
    public Transform tranData;
    public Vector3 rotationAngle;
    public float duration;
}