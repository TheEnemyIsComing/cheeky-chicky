using System.Collections;
using TMPro;
using UnityEngine;

// логіка анімації повільного затухання та з'явлення тексту
public class PulseText : MonoBehaviour
{
    [SerializeField] private TMP_Text text; // посилання на текст
    [SerializeField] private float pulseTime = 1f; // час циклу анімації в секундах

    private void Awake() // викликається при створенні об'єкта
    {
        if (!text) // якщо посилання на текст не задане
            text = GetComponent<TMP_Text>(); // шукаємо текст в компонентах об'єкту
    }

    private void Start() // викликається при першому кадрі
    {
        StartCoroutine(PulseCoroutine(pulseTime)); // починаємо анімацію
    }

    private IEnumerator PulseCoroutine(float time) // анімація
    {
        SetTextAlpha(0f); // виставляємо альфу кольору тексту в 0

        var alphaPerSecond = 1f / time; // визначаємо швидкість зміни прозорості за секунду

        var up = true; // збільшуємо чи зменьшуємо альфу (чим більше альфа - тим меньше прозорість)
        
        while (true) // безкінечний цикл
        {
            yield return null; // чекаємо 1 кадр
            
            if (up) // якщо збільшуємо альфу
            {
                SetTextAlpha(text.alpha + alphaPerSecond * Time.deltaTime); // додаємо альфу за секунду, помножену на час, який минув з попереднього кадру
                if (text.alpha >= 1f) // якщо альфа більше 1
                    up = false; // починаємо її зменьшувати
            }
            else // якщо зменьшуємо альфу
            {
                SetTextAlpha(text.alpha - alphaPerSecond * Time.deltaTime); // віднімаємо альфу за секунду, помножену на час, який минув з попереднього кадру
                if (text.alpha <= 0f) // якщо альфа меньше 0
                    up = true; // починаємо її збільшувати
            }
        }
    }

    private void SetTextAlpha(float alpha) // виставлення альфа кольору тексту
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, alpha); // копіюємо колір тексту, змінюємо в ньому альфу і виставляємо туксту новий колір 
    }
}