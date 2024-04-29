public interface ISceneLoaderService // інтерфейс завантаження сцен
{
    public void LoadMainMenu(); // завантаження сцени головного меню
    public void LoadLevel(int level); // завантаження сцени рівня по номеру
    public void LoadNextLevel(); // завантаження сцени наступного рівня
    public void ReloadScene(); // перезавантаження поточної сцени
}