using UnityEngine;

public class SaveService : ISaveService // реалізація інтерфейсу збереження гри
{
    private const string LevelsCompleteKey = "LevelsComplete"; // ключ збереження кількості пройдених рівнів

    public void Save(int levelsComplete) // збереження гри
    {
        if(levelsComplete <= GetLevelsUnlocked()) // якщо кількість рівнів меньша за збережену
            return; // завершуємо метод
        
        PlayerPrefs.SetInt(LevelsCompleteKey, levelsComplete); // зберігаємо кількість пройдених рівнів по ключу
    }

    public int GetLevelsUnlocked() // завантаження квлькості пройдених рівнів
    {
        return PlayerPrefs.GetInt(LevelsCompleteKey, 0); // повертаємо значення, збережене за ключем
    }

    public void ResetProgress() // знищення сейву
    {
        PlayerPrefs.DeleteAll(); // видаляємо всі ключі і дані
    }
}