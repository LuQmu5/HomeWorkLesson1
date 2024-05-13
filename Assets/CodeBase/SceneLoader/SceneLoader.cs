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

    public void Load(string sceneName, Action<DiContainer> action = null)
    { 
        _sceneLoader.LoadScene(sceneName, LoadSceneMode.Single, container => action?.Invoke(container));
    }
}
