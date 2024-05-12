using System.Collections.Generic;
using Zenject;

public class GameModesInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        IReadOnlyCollection<GameMode> gameModes = new GameMode[]
        {
            new DestroyAllGameMode("���������� ��� ����"),
            new DestroyAnyColorGameMode("���������� ��� ���� � ���������� ������"),
            new DestroyAnyNumberTypeGameMode("���������� ��� ���� � ���������� ����� �����"),
            new DestroyAnyNumberGameMode("���������� ��� ���� � ���������� ������")
        };

        Container.BindInstance(gameModes).AsSingle();
    }
}
