using UnityEngine;
using Zenject;

// логіка екрану виграшу
public class WinUI : MonoBehaviour
{
    [SerializeField] private int level; // номер рівня, задається на сцені

    [Inject] private ISaveService _saveService; // інжект сервісу збереження гри
    [Inject] private ISceneLoaderService _sceneLoaderService; // інжект сервісу завантаження сцен 

    private void Start() // викликається на першому кадрі, в якому об'єкт буде активним
    {
        _saveService.Save(level); // збереження проходження рівню
    }

    public void NextLevel() // перехід на наступний рівень, викликається з кнопки
    {
        _sceneLoaderService.LoadNextLevel(); // кажемо сервісу завантаження сцен завантажити наступний рівень
    }
}