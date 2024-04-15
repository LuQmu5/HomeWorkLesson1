using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Game
{
    public GameStateMachine StateMachine;

    public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain)
    {
        StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), AllServices.Container, curtain);
    }
}
