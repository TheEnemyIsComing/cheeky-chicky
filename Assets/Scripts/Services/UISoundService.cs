using UnityEngine;

// відповідає за звуки UI
public class UISoundService : MonoBehaviour
{
    [SerializeField] private AudioSource _buttonClickAudio; // джерело звуку натискання кнопки
    
    public void PlayButtonClick() // звук натискання кнопки
    {
        _buttonClickAudio.Play(); // програє звук натискання кнопки з джерела
    }
}