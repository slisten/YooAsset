using UnityEngine;

namespace GF
{
    public class LaunchProcedure: FsmState<Game>
    {
        public override void OnEnter()
        {
            GLog.E("Launch Enter");
        }

        public override void OnLeave()
        {
            GLog.E("Launch Leave");
        }

        public override void OnUpdate()
        {
            GLog.E("Launch OnUpdate");
        }

        public override void OnDestroy()
        {
            GLog.E("Launch Destroy");
        }
    }
}