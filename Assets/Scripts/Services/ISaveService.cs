public interface ISaveService // інтерфейс збереження та завантаження гри
{
    public void Save(int levelsComplete); // збереження гри
    public int GetLevelsUnlocked(); // завантаження пройдених рівнів
    public void ResetProgress(); // знищення сейву гри
}