﻿public interface IPayLoadedState<TPayload> : IExitableState
{
    void Enter(TPayload payload);
}
