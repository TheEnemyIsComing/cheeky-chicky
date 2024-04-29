using UnityEngine;
using Zenject;

// скрипт відповідає за додання систем рівня в DI контейнер
public class LevelInstaller : MonoInstaller 
{
    [SerializeField] private GameMenu _gameMenu; // посилання на контроллер UI гри
    [SerializeField] private LevelController _levelController; // посилання на контролер рівня
    
    public override void InstallBindings() // додання в контейнер
    {
        Container.Bind<GameMenu>().FromInstance(_gameMenu).AsSingle().NonLazy(); // додання UI гри
        Container.Bind<LevelController>().FromInstance(_levelController).AsSingle().NonLazy(); // додання контролера рівня
    }
}