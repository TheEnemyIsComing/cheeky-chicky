using System.Collections;
using UnityEngine;
using Zenject;

// логіка курки
public class Chicken : MonoBehaviour
{
	[SerializeField] private Rigidbody2D rb; // компонент, що відповідає за симуляцію фізики
	[SerializeField] private Rigidbody2D hook; // "рогатка", що відповідає за запуск курки

	[SerializeField] private float releaseTime = .15f; // час запуску курки в секундах 
	[SerializeField] private float maxDragDistance = 2f; // максимальна дистанція "заряжання" курки

	[SerializeField] private AudioSource audioSource; // джерело звуку запуску курки

	private bool isPressed = false; // чи тримують курку

	[Inject] private LevelController _levelController; // інжект контролера рівня

	private void Update() // викликається кожний кадр
	{
		if (isPressed) // якщо на курку натиснули
		{
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // перетворюємо позицію миші з координат екрану на координату у світі гри 

			Vector2 hookPosition; // ініціалізуємо змінну нової позиції курки

			if (Vector3.Distance(mousePos, hook.position) > maxDragDistance) // перевіряємо чи не відтягнули ми курку занадто далеко
				hookPosition = hook.position + (mousePos - hook.position).normalized * maxDragDistance; // якщо так - наближуємо позицію до центру "рогатки" 
			else
				hookPosition = mousePos; // якщо ні - просто беремо позицію миші 
 
			rb.position = hookPosition; // присвоюємо курці нову позицію
		}
	}

	private void OnMouseDown() // викликається при натисканні миші на курку 
	{
		isPressed = true; // запам'ятовуємо що на курку натиснули
		rb.isKinematic = true; // відключаємо симуляцію фізики
	}

	private void OnMouseUp() // викликається при відпусканні миші з курки
	{
		isPressed = false; // запам'ятовуємо що на курку більше не тиснуть
		rb.isKinematic = false; // вмикаємо симуляцію фізики

		StartCoroutine(Shoot()); // починаємо постріл
	}

	private IEnumerator Shoot() // "постріл"
	{
		yield return new WaitForSeconds(releaseTime); // чекаємо час відпускання рогатки

		_levelController.Shoot(); // кажемо контролеру рівня що ми вистрілили
		audioSource.Play(); // програємо звук курки

		GetComponent<SpringJoint2D>().enabled = false; // відклю чаємо "рогатку"
		this.enabled = false; // відключаємо цей скрипт, далі курки летить по симуляції фізики
	}
}