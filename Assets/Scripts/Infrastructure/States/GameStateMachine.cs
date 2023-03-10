using System;
using System.Collections.Generic;
using Infrastructure.Services;
using Infrastructure.Services.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.Theme;

namespace Infrastructure.States
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, AllServices services)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, services),
                [typeof(LoadProgressState)] = new LoadProgressState(this, services.Single<IPersistentProgressService>(), services.Single<ISaveLoadService>(),services.Single<IThemeService>()),
                [typeof(LateRegistrationState)] = new LateRegistrationState(this, services),
                [typeof(LoadMainState)] = new LoadMainState(this, sceneLoader, services.Single<IUIFactoryService>()),
                [typeof(SelectLevelState)] = new SelectLevelState(this,services.Single<IUIFactoryService>(), services.Single<ISaveLoadService>()),
                [typeof(NewGameState)] = new NewGameState(this,services.Single<IUIFactoryService>(),services.Single<ISaveLoadService>(),services.Single<IThemeService>()),
                [typeof(ContinueGameState)] = new ContinueGameState(this,services.Single<IUIFactoryService>(),services.Single<ISaveLoadService>(),services.Single<IThemeService>()),
                [typeof(GameLoopState)] = new GameLoopState(this),
                [typeof(EndGameState)] = new EndGameState(this,services.Single<IUIFactoryService>(), services.Single<ISaveLoadService>(),services.Single<IPersistentProgressService>()),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayloadedState<TPayLoad>
        {
            TState state = ChangeState<TState>();
            state.Enter(payLoad);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}