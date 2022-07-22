/*
 * Based on https://unitycodemonkey.com/utils.php
 */

using System;
using UnityEngine;
using System.Collections.Generic;

namespace IRLab.Tools.Timer
{
    public class Timer
    {
        private class MonoBehaviourHook : MonoBehaviour
        {
            public Action OnUpdate;

            private void Update()
            {
                if (OnUpdate == null) return;
                OnUpdate();
            }
        }

        private static List<Timer> timerList;
        private static GameObject initGameObject;

        private static void InitIfNeeded()
        {
            if (initGameObject != null) return;

            initGameObject = new GameObject("Timer_Global");
            timerList = new List<Timer>();
        }


        public static Timer Create(Action action, float time)
        {
            return Create(action, time, "", false, false);
        }

        public static Timer Create(Action action, float time, string functionName)
        {
            return Create(action, time, functionName, false, false);
        }

        public static Timer Create(Action action, float time, string functionName, bool useUnscaledDeltaTime)
        {
            return Create(action, time, functionName, useUnscaledDeltaTime, false);
        }
        public static Timer Create(Action action, float time, string functionName, bool useUnscaledDeltaTime, bool stopAllWithSameName)
        {
            InitIfNeeded();

            if (stopAllWithSameName)
                StopAllTimersWithName(functionName);

            GameObject obj = new GameObject("Function Timer Obj " + functionName, typeof(MonoBehaviourHook));
            Timer timer = new Timer(obj, action, time, functionName, useUnscaledDeltaTime);
            obj.GetComponent<MonoBehaviourHook>().OnUpdate = timer.Update;
            timerList.Add(timer);

            return timer;
        }

        public static void RemoveTimer(Timer timer)
        {
            InitIfNeeded();
            timerList.Remove(timer);
        }

        public static void StopAllTimersWithName(string functionName)
        {
            InitIfNeeded();

            for (int i = 0; i < timerList.Count; i++)
            {
                if (timerList[i].functionName == functionName)
                    timerList[i].DestroySelf();
            }
        }

        public static void StopFirstTimerWithName(string functionName)
        {
            InitIfNeeded();
            for (int i = 0; i < timerList.Count; i++)
            {
                if (timerList[i].functionName == functionName)
                {
                    timerList[i].DestroySelf();
                    return;
                }
            }
        }

        private GameObject gameObject;
        private float time;
        private string functionName;
        private bool active;
        private bool useUnscaledDeltaTime;
        private Action action;

        public Timer(GameObject gameObject, Action action, float time, string functionName, bool useUnscaledDeltaTime)
        {
            this.gameObject = gameObject;
            this.time = time;
            this.functionName = functionName;
            this.useUnscaledDeltaTime = useUnscaledDeltaTime;
            this.action = action;
        }

        private void Update()
        {
            if (useUnscaledDeltaTime)
                time -= Time.unscaledDeltaTime;
            else
                time -= Time.deltaTime;

            if (time <= 0)
            {
                action();
                DestroySelf();
            }
        }

        private void DestroySelf()
        {
            RemoveTimer(this);
            if (gameObject == null) return;
            UnityEngine.Object.Destroy(gameObject);
        }
    }
}
