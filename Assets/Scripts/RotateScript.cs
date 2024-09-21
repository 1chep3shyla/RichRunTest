using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 
public class RotateScript : MonoBehaviour
{
     public GameObject targetObject;  // Объект, который нужно вращать
    public float rotationSpeed = 360f; // Скорость вращения в градусах в секунду

    void Start()
    {
        // Проверяем, задан ли объект
        if (targetObject != null)
        {
            // Вращаем объект по оси Y бесконечно
            targetObject.transform.DORotate(new Vector3(0, 360, 0), 1f / (rotationSpeed / 360), RotateMode.FastBeyond360)
                .SetEase(Ease.Linear) // Линейное вращение
                .SetLoops(-1, LoopType.Incremental); // Бесконечный цикл
        }
        else
        {
            Debug.LogError("Целевой объект не назначен.");
        }
    }
}