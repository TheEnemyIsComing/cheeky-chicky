using UnityEngine;
using Zenject;

// логіка кнопки знищення сейву
public class ResetButton : MonoBehaviour
{
    [Inject] private ISaveService _saveService; // інжект сервісу збереження гри
    [Inject] private ISceneLoaderService _sceneLoaderService; // інжект сервісу завантаження сцен
    
    public void ResetProgress() // нищимо прогрес
    {
        _saveService.ResetProgress(); // кажемо сервісу збереження видалити сейви 
        _sceneLoaderService.ReloadScene(); // кажемо сервісу завантаження сцен перезавантажити поточну сцену
    }
}