using System;
using Cysharp.Threading.Tasks;
using ET;
using UnityEngine;
using YooAsset;

namespace GF
{
    public class Game: MonoBehaviour
    {
        public Fsm<Game> Procedure;
        private void Start()
        {
            GLog.Init();
            // 初始化资源系统
            YooAssets.Initialize();
            // 创建默认的资源包
            var package = YooAssets.CreatePackage("DefaultPackage");
            // 设置该资源包为默认的资源包，可以使用YooAssets相关加载接口加载该资源包内容。
            YooAssets.SetDefaultPackage(package);
            
            Procedure = new Fsm<Game>(this);
            Procedure.AddState<LaunchProcedure>();
            Procedure.AddState<MainProcedure>();
            
            Procedure.ChangeState<LaunchProcedure>();
            
        }


        private void Update()
        {
            // if (Input.GetKeyDown(KeyCode.A))
            // {
            //     Procedure.ChangeState<MainProcedure>();
            // }
            // Procedure.OnUpdate();
        }

        private void OnDestroy()
        {
            Procedure.Destroy();
        }
    }
}