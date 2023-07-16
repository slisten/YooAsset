using System;
using UnityEngine;
using YooAsset;

namespace GF
{
    public class Game: MonoBehaviour
    {
        public EPlayMode PlayMode;
        public static Fsm<Game> Procedure;
        private void Awake()
        {
            GLog.Init();
            YooAssets.Initialize();
            
            Procedure = new Fsm<Game>(this);
            Procedure.AddState<LaunchProcedure>();
            Procedure.AddState<GameProcedure>();
            Procedure.AddState<EmptyProcedure>();
            
            Procedure.ChangeState<LaunchProcedure>(PlayMode);
            
            
            DontDestroyOnLoad(this);
        }


        private void Update()
        {
            Procedure.OnUpdate();
        }

        private void OnDestroy()
        {
            Procedure.Destroy();
        }
    }
}