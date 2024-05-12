using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private SelectGameModeMenu _selectGameModeMenu;

    public override void InstallBindings()
    {
        Container.BindInstance(_selectGameModeMenu);

        Container.Bind<GameManagement>().AsSingle();
        Container.Bind<SceneLoader>().AsSingle();

        Container.Bind<GameManagementMediator>().AsSingle().NonLazy();
    }
}
