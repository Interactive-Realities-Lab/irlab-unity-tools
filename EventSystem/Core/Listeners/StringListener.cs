using EventSystem.Event;
using EventSystem.UnityEvent;
using UnityEngine;

namespace EventSystem.Listener
{
    public class StringListener : BaseEventSystemListener<string, StringEventChannelSO, UnityStringEvent> { }
}