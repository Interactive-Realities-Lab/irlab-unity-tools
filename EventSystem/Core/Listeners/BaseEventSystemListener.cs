using UnityEngine;
using UnityEngine.Events;
using EventSystem.Event;

namespace EventSystem.Listener
{
    public abstract class BaseEventSystemListener<T, E, UER> : MonoBehaviour,
        IEventSystemListener<T> where E : BaseEventChannelSO<T> where UER : UnityEvent<T>
    {
        [SerializeField] private E channel;
        public E Channel { get { return channel; } set { channel = value; } }

        [SerializeField] private UER unityEventResponse;

        private void OnEnable()
        {
            if (channel == null) return;

            channel.RegisterListener(this);
        }

        private void OnDisable()
        {
            if (channel == null) return;

            channel.UnregisterListener(this);
        }

        public void OnEventRaised(T item)
        {
            if (unityEventResponse == null) return;

            unityEventResponse?.Invoke(item);
        }
    }
}