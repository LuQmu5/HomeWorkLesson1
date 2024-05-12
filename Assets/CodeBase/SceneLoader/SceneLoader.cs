using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneLoader
{
    private readonly ZenjectSceneLoader _sceneLoader;

    [Inject]
    public SceneLoader(ZenjectSceneLoader sceneLoader)
    {
        Debug.Log("SceneLoader");

        _sceneLoader = sceneLoader;
    }

    public void Load(int sceneID, Action<DiContainer> action = null)
    { 
        _sceneLoader.LoadScene(sceneID, LoadSceneMode.Single, container => action?.Invoke(container));
    }
}
