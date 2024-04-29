using System.Collections;
using UnityEngine;
using Zenject;

// скрипт відповідає за логіку пляшки 
public class Bottle : MonoBehaviour
{
    [SerializeField] private GameObject deathEffect; // fx при розбитті
    [SerializeField] private float health = 4f; // "здоров'я" пляшки
    [SerializeField] private SpriteRenderer spriteRenderer; // спрайт пляшки
    [SerializeField] private AudioSource audioSource; // джерело звуку розбиття пляшки 

    private bool _dead; // чи "мертва" пляшка

    [Inject] private LevelController _levelController; // інджект контролера рівня

    private void Start() // викликається на першому кадрі
    {
        _levelController.BottleRegister(this); // реєструємо пляшку у контролері рівня
    }

    private void OnCollisionEnter2D(Collision2D colInfo) // викликається при зіткненні об1єкта з пляшкою
    {
        if (_dead) return; // якщо пляшка "мертва", завершуємо метод

        if (colInfo.relativeVelocity.magnitude > health) // якщо відносна швидкість об'єкта більше за "здоров'я" пляшки
        {
            StartCoroutine(Die()); // "вбиваємо" пляшку
        }
    }

    private IEnumerator Die() // "смерть" пляшки
    {
        _dead = true; // позначаємо пляшку "мертвою"
        _levelController.BottleDeath(this); // кажемо про це контролеру рівня

        audioSource.Play(); // програємо звук розбиття
        spriteRenderer.enabled = false; // відключаємо спрайт пляшки

        Instantiate(deathEffect, transform.position, Quaternion.identity); // спавнимо ефект розбиття

        yield return new WaitForSeconds(1f); // чекаємо одну секунду
        Destroy(gameObject); // видаляємо об'єкт пляшки
    }
}