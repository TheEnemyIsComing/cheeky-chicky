using System.Collections;
using UnityEngine;
using Zenject;

// логіка початкового екрану гри
public class TitleScreen : MonoBehaviour
{
    [SerializeField] private GameObject textCheeky; // посилання на текст Cheeky
    [SerializeField] private GameObject textChicky; // посилання на текст Chicky
    [SerializeField] private GameObject textStart; // посилання на текст Press to start

    [Inject] private MainMenu _mainMenu; // інжект сервісу головного меню

    private static bool _needTitle = true; // чи потрібно показувати початковий екран

    private void Start() // викликається на першому кадрі
    {
        StartCoroutine(ShowTitle()); // починаємо показ екрану
    }

    private void Update() // виконується кожен кадр
    {
        CheckStart(); // перевіряємо чи натиснута будь яка кнопка
    }

    private void CheckStart() // перевірка натискання кнопки
    {
        if (Input.anyKey) // якщо натиснута будь яка кнопка
        {
            _mainMenu.ShowScreen(1); // показуємо головний екран головного меню
            _needTitle = false; // позначаємо що початковий екран показувати вже непотрібно
        }
    }

    private IEnumerator ShowTitle() // показ початкового екрану
    {
        yield return null; // чекаємо один кадр

        if (!_needTitle) // якщо початковий екран не потрібен
        {
            _mainMenu.ShowScreen(1); // вмикаємо головний екран
            yield break; // завершуємо корутину
        }
        
        yield return new WaitForSeconds(.5f); // чекаємо півсекунди

        textCheeky.SetActive(true); // вмикаємо анімований текст Cheeky

        yield return new WaitForSeconds(.1f); // чекаємо 0,1 секунди

        textChicky.SetActive(true); // показуємо анімований текст Chicky

        yield return new WaitForSeconds(1f); // чекаємо секунду

        textStart.SetActive(true); // показуємо пульсуючий текст Press to start
    }
}