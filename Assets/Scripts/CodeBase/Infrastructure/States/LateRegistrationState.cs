using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.UI.Services.Factory;
using CodeBase.UI.Services.Theme;

namespace CodeBase.Infrastructure.States
{
    public class LateRegistrationState : IState
    {
        private readonly AllServices _services;
        private GameStateMachine _stateMachine;

        public LateRegistrationState(GameStateMachine stateMachine, AllServices services)
        {
            _stateMachine = stateMachine;
            _services = services;
        }

        public void Enter()
        {
            LateRegistration();

            _stateMachine.Enter<LoadMainState>();
        }

        public void Exit()
        {
        }

        private void LateRegistration()
        {
            SubscribleToFactory();
        }

        private void SubscribleToFactory()
        {
            _services.Single<IUIFactory>().Registered(_services.Single<ISaveLoadService>());
            _services.Single<IUIFactory>().Registered(_services.Single<IThemeService>());
        }
    }
}