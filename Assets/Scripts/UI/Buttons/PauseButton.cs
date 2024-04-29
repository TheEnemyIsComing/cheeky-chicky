using UnityEngine;

// логіка кнопки паузи
public class PauseButton : MonoBehaviour
{
    private bool _paused; // чи поставлена гра на паузу

    public void Pause() // метод викликається при натисканні на кнопку
    {
        if (!_paused) // якщо гра не на паузі
        {
            _paused = true; // запам'ятовуємо що ставимо гру на паузу

            Time.timeScale = 0f; // виставляємо швидкість ігрового часу в 0 
        }
        else // в іншому випадку
        {
            _paused = false; // запам'ятовуємо що ставимо гру на паузу
            
            Time.timeScale = 1f; // повертаємо нормальну швидкість ігрового часу
        }
    }
}