using UnityEngine;
using Zenject;

// скрипт відповідає за додання систем головного меню в DI контейнер
public class MainMenuInstaller : MonoInstaller
{
    [SerializeField] private MainMenu mainMenu; // посилання на скрипт логіки головного меню
    
    public override void InstallBindings() // додання в контейнер
    {
        Container.Bind<MainMenu>().FromInstance(mainMenu).AsSingle().NonLazy(); // додання скрипту логіки головного меню
    }
}