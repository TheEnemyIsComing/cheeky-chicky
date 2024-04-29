using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// логіка UI гри
public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject winUI; // екран виграшу
    [SerializeField] private GameObject loseUI; // екран програшу
    [SerializeField] private Button pauseButton; // кнопка паузи

    public void ShowWinUI() // показати екран виграшу, викликається з контролера рівня
    {
        StartCoroutine(WinCoroutine()); // запуск показу
    }
    
    public void ShowLoseUI() // показати екран програшу, викликається з контролера рівня
    {
        pauseButton.interactable = false; // відключення кнопки паузи
        loseUI.SetActive(true); // вмикання екрану програшу
    }

    private IEnumerator WinCoroutine() // показ екран виграшу 
    {
        yield return new WaitForSeconds(1f); // чекаємо 1 секунду щоб було видно як "вмирає" остання пляшка
        
        pauseButton.interactable = false; // відключення кнопки паузи
        winUI.SetActive(true); // вмикаємо екран виграшу
    }
}