// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// namespace SF
// {
//     /// <summary>
//     /// 状态机管理器
//     /// </summary>
//     public class FsmManager
//     {
//         /// <summary>
//         /// 状态机字典
//         /// </summary>
//         private Dictionary<int, FsmBase> fsmDic;
//         
//         /// <summary>
//         /// 状态机的临时编号
//         /// </summary>
//         private int tempFsmId = 0;
//
//         public FsmManager()
//         {
//             fsmDic = new Dictionary<int, FsmBase>();
//         }
//
//         /// <summary>
//         /// 初始化
//         /// </summary>
//         public void Init()
//         {
//
//         }
//         
//         /// <summary>
//         /// 创建状态机
//         /// </summary>
//         /// <typeparam name="T">拥有者类型</typeparam>
//         /// <param name="owner">拥有者</param>
//         /// <param name="states">状态数组</param>
//         /// <returns></returns>
//         public Fsm<T> Create<T>(T owner, FsmState<T>[] states) where T : class
//         {
//             return Create<T>(tempFsmId++, owner, states);
//         }
//
//         /// <summary>
//         /// 创建状态机
//         /// </summary>
//         /// <typeparam name="T">拥有者类型</typeparam>
//         /// <param name="fsmId">状态机编号</param>
//         /// <param name="owner">拥有者</param>
//         /// <param name="states">状态数组</param>
//         /// <returns></returns>
//         public Fsm<T> Create<T>(int fsmId, T owner, FsmState<T>[] states) where T : class
//         {
//             Fsm<T> fsm = new Fsm<T>(fsmId, owner, states);
//             fsmDic[fsmId] = fsm;
//             return fsm;
//         }
//
//         /// <summary>
//         /// 销毁状态机
//         /// </summary>
//         /// <param name="fsmId"></param>
//         public void DestroyFsm(int fsmId)
//         {
//             FsmBase fsm = null;
//             if (fsmDic.TryGetValue(fsmId, out fsm))
//             {
//                 fsm.Destroy();
//                 fsmDic.Remove(fsmId);
//             }
//         }
//
//         public void Destroy()
//         {
//             var enumerator = fsmDic.GetEnumerator();
//             while (enumerator.MoveNext())
//             {
//                 enumerator.Current.Value.Destroy();
//             }
//             fsmDic.Clear();
//         }
//     }
// }