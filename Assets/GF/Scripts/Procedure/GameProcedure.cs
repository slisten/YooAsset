using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YooAsset;

namespace GF
{
    public class GameProcedure: FsmState<Game>
    {
        public override void OnEnter(params object[] args)
        {
            EnterScene().Forget();
        }

        private async UniTaskVoid EnterScene()
        {
            SceneOperationHandle sceneOperationHandle = YooAssets.LoadSceneAsync("Game");
            await sceneOperationHandle;
            await SceneManager.LoadSceneAsync("Game");
            GLog.I("场景加载完毕");
            //设置背景
            var handle = YooAssets.LoadAssetAsync<Sprite>("BG");
            await handle;
            Sprite sprite = handle.GetAssetObject<Sprite>();
            GameObject.Find("Canvas/Image").GetComponent<Image>().sprite = sprite;
            
            //加载敌人
            var handle2 = YooAssets.LoadAssetAsync<GameObject>("Enemy");
            await handle2;
            GameObject prefab = handle2.GetAssetObject<GameObject>();
            for (int i = 0; i < 10; i++)
            {
                float x = Random.Range(-2.5f, 2.5f);
                float y = Random.Range(-3.5f, 5.5f);
                GameObject obj = GameObject.Instantiate(prefab);
                obj.transform.position = new Vector3(x, y, 0);
            }

            var handle3 = YooAssets.LoadAssetAsync<GameObject>("Player");
            await handle3;
            GameObject player = GameObject.Instantiate(handle3.GetAssetObject<GameObject>());
            player.transform.position=Vector3.zero;
            
        }

        public override void OnLeave()
        {
            
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Game.Procedure.ChangeState<EmptyProcedure>();
            }   
        }

        public override void OnDestroy()
        {
            
        }
    }
}