using Cysharp.Threading.Tasks;
using UnityEngine;
using YooAsset;

namespace GF
{
    public class LaunchProcedure: FsmState<Game>
    {
        private EPlayMode _playMode;
        private ResourcePackage _package;
        public override void OnEnter(params object[] args)
        {
            _playMode = (EPlayMode)args[0];
            
            
            string packageName = "DefaultPackage";
            _package = YooAssets.TryGetPackage(packageName);
            if (_package == null)
            {
                _package = YooAssets.CreatePackage(packageName);
                YooAssets.SetDefaultPackage(_package);
            }
           
            InitAsync().Forget();
        }

        private async UniTaskVoid InitAsync()
        {
            InitializationOperation initializationOperation = null;
            if (_playMode == EPlayMode.OfflinePlayMode)
            {
                var createParameters = new OfflinePlayModeParameters();
                initializationOperation = _package.InitializeAsync(createParameters);
                await initializationOperation;
                Game.Procedure.ChangeState<GameProcedure>();
            }
        }

        public override void OnLeave()
        {
        }

        public override void OnUpdate()
        {
            
        }

        public override void OnDestroy()
        {
        }
    }
}