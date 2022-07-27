using EventSystem.Listener;
using System.Collections.Generic;
using UnityEngine;

namespace EventSystem.Event {

    public class BaseEventChannelSO<T> : ScriptableObject
    {
        private List<IEventSystemListener<T>> eventListener = new List<IEventSystemListener<T>>();

        public void Broadcast(T item)
        {
            for (int i = eventListener.Count - 1; i >= 0; i--)
                eventListener[i].OnEventRaised(item);
        }

        public void RegisterListener(IEventSystemListener<T> listener)
        {
            if (eventListener.Contains(listener)) return;
            
            eventListener.Add(listener);
        }

        public void UnregisterListener(IEventSystemListener<T> listener)
        {
            if (!eventListener.Contains(listener)) return;
            
            eventListener.Remove(listener);
        }
    }
}
