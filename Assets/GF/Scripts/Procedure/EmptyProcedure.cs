using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YooAsset;

namespace GF
{
    public class EmptyProcedure: FsmState<Game>
    {
        public override void OnEnter(params object[] args)
        {
            EnterScene().Forget();
        }

        private async UniTaskVoid EnterScene()
        {
            SceneOperationHandle sceneOperationHandle = YooAssets.LoadSceneAsync("Empty");
            await sceneOperationHandle;
            await SceneManager.LoadSceneAsync("Empty");
        }
    }
}