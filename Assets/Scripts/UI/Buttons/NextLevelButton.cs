using UnityEngine;
using Zenject;

// логіка кнопки наступного рівня
public class NextLevelButton : MonoBehaviour
{
    [Inject] private ISceneLoaderService _sceneLoaderService; // інжект сервісу завантаження сцен 

    public void NextLevel() // завантажуємо наступний рівень
    {
        _sceneLoaderService.LoadNextLevel(); // кажемо сервісу завантажити наступний рівень
    }
}