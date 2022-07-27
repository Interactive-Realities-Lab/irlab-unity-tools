namespace EventSystem.Listener
{
    public interface IEventSystemListener<T>
    {
        void OnEventRaised(T item);
    }
}
