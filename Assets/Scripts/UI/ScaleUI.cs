using System.Collections;
using UnityEngine;

// анімація збільшення UI
public class ScaleUI : MonoBehaviour
{
    [SerializeField] private float scaleTime = 1f; // час збільшення до 1
    
    private void Start() // викликається на першому кадрі
    {
        StartCoroutine(Scale(scaleTime)); // починаємо анімацію
    }

    private IEnumerator Scale(float time) // анімація
    {
        var scale = transform.localScale; // зберігаємо розмір UI 
        transform.localScale = Vector3.zero; // виставляємо розмір в 0

        var scalePerSecond = scale / time; // визначаємо швидкість збільшення розміру в секунду
        
        while (transform.localScale.x < scale.x) // запускаємо цикл, поки не досягнемо стартового розміру 
        {
            yield return null; // чекаємо 1 кадр
            transform.localScale += scalePerSecond * Time.deltaTime; // додаємо розмір за секунду, помножений на час, який прошов з попереднього кадру
        }
    }
}