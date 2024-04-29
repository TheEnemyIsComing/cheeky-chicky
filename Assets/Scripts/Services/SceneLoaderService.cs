using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

// реалізація інтерфейсу завантаження сцен
public class SceneLoaderService : ISceneLoaderService, IInitializable
{
    private const int MainMenuSceneId = 0; // ід сцени головного меню
    private const int NonLevelScenesCount = 1; // кількість сцен, що не є рівнями

    [Inject] private ISaveService _saveService; // інжект сервісу збереження і завантаження гри

    private int _levelsCount; // кількість рівнів

    public void Initialize() // спрацьовує на старті
    {
        _levelsCount = SceneManager.sceneCount - NonLevelScenesCount; // визначаємо кількість рівнів у гри, віднявши кількість сцен не рівнів від кількості сцен у грі вцілому
    }

    public void LoadMainMenu() // завантаження сцени головного меню
    {
        SceneManager.LoadScene(MainMenuSceneId); // завантажуємо сцену з ід головного меню
    }

    public void LoadLevel(int level) // завантаження сцени рівня по номеру
    {
        level = Mathf.Clamp(level, 0, _levelsCount); // впевнюємось що не намагаємось завантажити неіснуючий рівень
        SceneManager.LoadScene(level + NonLevelScenesCount); // завантаєуємо рівень по номеру
    }

    public void LoadNextLevel() // завантаження сцени наступного рівня
    {
        var nextLevel = _saveService.GetLevelsUnlocked();  // беремо номер наступного рівня з сервісу завантаження
        if (nextLevel >= _levelsCount) // якщо наступного рівня не існує - обираємо перший рівень
            nextLevel = 0;

        LoadLevel(nextLevel); // викликаємо завантаження рівня
    }

    public void ReloadScene() // перезавантаження поточної сцени
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // завантажуємо поточну сцену
    }
}