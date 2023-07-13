using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GF
{
    public class Fsm<T> where T : class
    {
        public T Owner { get; private set; }
        private FsmState<T> currState;
        private Dictionary<Type, FsmState<T>> stateDic;
        private Dictionary<string, object> paramDic;

        public Fsm(T owner, FsmState<T>[] states = null)
        {
            stateDic = new Dictionary<Type, FsmState<T>>();
            paramDic = new Dictionary<string, object>();
            Owner = owner;

            if (states != null)
            {
                int len = states.Length;
                for (int i = 0; i < len; i++)
                {
                    FsmState<T> state = states[i];
                    if (state != null)
                    {
                        state.CurrFsm = this;
                    }

                    stateDic[state.GetType()] = state;
                }
            }
        }

        public void AddState<S>() where S: FsmState<T>
        {
            var stateType = typeof(S);
            FsmState<T> state = Activator.CreateInstance(stateType) as FsmState<T>;
        }

        public FsmState<T> GetState<S>() where S: FsmState<T>
        {
            FsmState<T> state = null;
            stateDic.TryGetValue(typeof(S), out state);
            return state;
        }

        public void OnUpdate()
        {
            if (currState != null)
            {
                currState.OnUpdate();
            }
        }

        public void ChangeState<S>() where S: FsmState<T>
        {
            Type stateType = typeof(S);
            if (currState == null)
            {
                currState = stateDic[stateType];
                currState.OnEnter();
                return;
            }
            
            if (currState.GetType() == stateType)
            {
                return;
            }

            currState.OnLeave();
            currState = stateDic[stateType];
            currState.OnEnter();
        }

        public void SetData<S>(string key, S value)
        {
            paramDic[key] = value;
        }

        public S GetData<S>(string key)
        {
            if (paramDic.TryGetValue(key, out var value))
            {
                return (S)value;
            }

            return default(S);
        }

        public void Destroy()
        {
            if (currState != null)
            {
                currState.OnLeave();
            }

            foreach (KeyValuePair<Type, FsmState<T>> state in stateDic)
            {
                if (state.Value != null)
                {
                    state.Value.OnDestroy();
                }
            }
            stateDic.Clear();
            paramDic.Clear();
        }
    }
}