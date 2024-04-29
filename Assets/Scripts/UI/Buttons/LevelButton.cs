using UnityEngine;
using Zenject;

// логіка кнопки завантаження обраного рівню
public class LevelButton : MonoBehaviour
{
    [Inject] private ISceneLoaderService _sceneLoaderService; // інжект сервісу завантаження сцен

    public void LoadLevel(int level) // завантаження сцени по ід, який задається у сцені головного меню
    {
        _sceneLoaderService.LoadLevel(level); // кажемо сервісу завантажити рівень по ід
    }
}