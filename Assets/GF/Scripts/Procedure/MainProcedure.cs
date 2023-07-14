using UnityEngine;

namespace GF
{
    public class MainProcedure: FsmState<Game>
    {
        public override void OnEnter()
        {
            GLog.E("MainProcedure Enter");
        }

        public override void OnLeave()
        {
            GLog.E("MainProcedure Leave");
        }

        public override void OnUpdate()
        {
            GLog.E("MainProcedure OnUpdate");
        }

        public override void OnDestroy()
        {
            GLog.E("MainProcedure Destroy");
        }
    }
}