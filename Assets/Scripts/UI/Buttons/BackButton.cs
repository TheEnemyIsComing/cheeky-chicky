using UnityEngine;
using Zenject;

// скрипт кнопки повернення до головного меню
public class BackButton : MonoBehaviour
{
    [Inject] private ISceneLoaderService _sceneLoaderService; // інжект сервісу завантаження сцен
    
    public void ToMainMenu() // повернення до головного меню
    {
        _sceneLoaderService.LoadMainMenu(); // кажемо сервісу завантажити головне меню
    }
}