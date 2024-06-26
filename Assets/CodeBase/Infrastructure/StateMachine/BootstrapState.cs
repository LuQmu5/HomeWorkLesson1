﻿using Unity.VisualScripting;
using UnityEngine;

public class BootstrapState : IState
{
    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly AllServices _services;

    public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
    {
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;
        _services = services;

        RegisterServices();
    }

    public void Enter()
    {
        _sceneLoader.Load(SceneNames.Initial.ToString(), onLoaded: EnterLoadLevel);
    }

    public void Exit()
    {
        Debug.Log("Exit Bootstrapstate");
    }

    private void EnterLoadLevel()
    {
        _stateMachine.Enter<LoadLevelState, string>(SceneNames.Hub.ToString());
    }

    private void RegisterServices()
    {
        _services.RegisterSingle<IGameStateMachine>(_stateMachine);
        _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IGameStateMachine>()));
    }
}
