using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

// скрипт відповідає за логіку рівня: таймер програшу, перевірка умов перемоги, виклик відповідної UI в кінці гри  
public class LevelController : MonoBehaviour 
{
    [SerializeField] private float _loseDealy = 6f; // час в секундах до програшу пістя пострілу

    private HashSet<Bottle> _bottles = new HashSet<Bottle>(); // хешсет з пляшками на рівні

    [Inject] private GameMenu _gameMenu; // інжект контроллера ігрової UI

    private bool _gameOver; // чи закінчилась гра

    public void Shoot() // викликається при пострілі
    {
        StartCoroutine(LoseTimerCoroutine(_loseDealy)); // початок таймеру програшу 
    }

    public void BottleRegister(Bottle bottle) // викликається кожним ворогомна початку рівня
    {
        _bottles.Add(bottle); // додання пляшки до хешсету
    }

    public void BottleDeath(Bottle bottle) // викликається при розбитті пляшки
    {
        _bottles.Remove(bottle); // вилучення пляшки з хешсету
        WinCHeck(); // виклик перевірки умов перемоги
    }
    
    private void WinCHeck() // перевірк умов перемоги
    {
        if (_gameOver) return; // якщо гра скінчилася - завершуємо метод
        
        if(_bottles.Count == 0) // якщо в хешсеті немає пляшок - виграємо
            Win(); // виклик виграшу
    }

    private void Win() // виграш
    {
        _gameOver = true; // гра закінчилась
        
        _gameMenu.ShowWinUI(); // виклик UI виграшу
    }

    private void Lose() // програш
    {
        if (_gameOver) return; // якщо гра скінчилася - завершуємо метод 

        _gameOver = true; // гра закінчилась
        
        _gameMenu.ShowLoseUI(); // виклик UI програшу
    }

    private IEnumerator LoseTimerCoroutine(float time) // таймер програшу
    {
        yield return new WaitForSeconds(time); // чекаємо заданий час
        
        Lose(); // виклик програшу
    }
}