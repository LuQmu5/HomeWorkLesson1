using UnityEngine;
using Zenject;

public class BallsInstaller : MonoInstaller
{
    [SerializeField] private CoroutinePerformer _coroutinePerformer;

    public override void InstallBindings()
    {
        Container.BindInstance(_coroutinePerformer);

        Container.Bind<BallFactory>().AsSingle();
        Container.Bind<BallSpawner>().AsSingle();
        Container.Bind<TargetReachHandler>().AsSingle().NonLazy();
    }
}
