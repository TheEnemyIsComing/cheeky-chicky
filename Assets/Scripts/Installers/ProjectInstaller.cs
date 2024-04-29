using UnityEngine;
using Zenject;

// скрипт відповідає за додання систем гри у контейнер проєкту
public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private UISoundService _uiSoundService; // посилання на контроллер звуку UI
    
    public override void InstallBindings() // додання в контейнер
    {
        Container.Bind<ISaveService>().To<SaveService>().AsSingle().NonLazy(); // додання сервісу збереження та завантаження гри
        Container.Bind<ISceneLoaderService>().To<SceneLoaderService>().AsSingle().NonLazy(); // додання сервісу завантаження сцен
        Container.Bind<UISoundService>().FromInstance(_uiSoundService).AsSingle().NonLazy(); // додання контролеру звуку UI
    }
}