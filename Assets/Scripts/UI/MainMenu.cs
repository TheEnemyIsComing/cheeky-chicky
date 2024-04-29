using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

// логіка головного меню
public class MainMenu : MonoBehaviour
{
    [SerializeField] private List<Button> levelButtons; // кнопки рівнів
    [SerializeField] private List<GameObject> menuScreens; // екрани головного меню

    [Inject] private ISaveService _saveService; // інжект сервісу збереження гри
    [Inject] private ISceneLoaderService _sceneLoaderService; // інжект сервісу завантаження сцен
    [Inject] private UISoundService _soundService; // інжект сервісу звуків UI

    private void Start() // викликається у першому кадрі
    {
        RefreshButtons(); // оновлюємо кнопки
    }

    private void RefreshButtons() // оновлення кнопок
    {
        var levelsUnlocked = _saveService.GetLevelsUnlocked(); // завантажуємо кількість пройдених рівнів

        for (var i = 0; i < levelButtons.Count; i++) // проходимо по кожній кнопці вибору рівня
            levelButtons[i].interactable = i <= levelsUnlocked; // якщо рівень ще не відкритий - робимо кнопку неактивною
    }

    public void ShowScreen(int id) // показати екран по ід
    {
        _soundService.PlayButtonClick(); // звук натискання кнопки
        for (var i = 0; i < menuScreens.Count; i++) // проходимо по всім екранам меню
            menuScreens[i].SetActive(i == id); // якщо це потрібний екран - вмикаємо його, якщо непотрібний - вимикаємо
    }

    public void Quit() // вихід з гри
    {
        _soundService.PlayButtonClick(); // звукнатискання кнопки 
        Application.Quit(); // закриваємо застосунок
    }
}