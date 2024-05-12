using System.Collections.Generic;
using Zenject;

public class GameModesInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        IReadOnlyCollection<GameMode> gameModes = new GameMode[]
        {
            new DestroyAllGameMode("уничтожьте все шары"),
            new DestroyAnyColorGameMode("уничтожьте все шары с конкретным цветом"),
            new DestroyAnyNumberTypeGameMode("уничтожьте все шары с конкретным типом числа"),
            new DestroyAnyNumberGameMode("уничтожьте все шары с конкретным числом")
        };

        Container.BindInstance(gameModes).AsSingle();
    }
}
