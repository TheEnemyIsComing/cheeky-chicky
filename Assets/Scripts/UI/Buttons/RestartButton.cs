using UnityEngine;
using Zenject;

// логіка кнопки рестарту рівня
public class RestartButton : MonoBehaviour
{
    [Inject] private ISceneLoaderService _sceneLoaderService; // інжект сервісу завантаження сцен
    
    public void Restart() // викликається при натисканні кнопки
    {
        _sceneLoaderService.ReloadScene(); // кажемо сервісу перезавантажити сцену
    }
}