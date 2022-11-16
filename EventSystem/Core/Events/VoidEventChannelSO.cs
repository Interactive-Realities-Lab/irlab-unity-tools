
using UnityEngine;

namespace IRLab.EventSystem.Event
{
    [CreateAssetMenu(fileName = "New Void Event", menuName = "Event System/Void Event")]
    public class VoidEventChannelSO : BaseEventChannelSO<Void>
    {
        public void Broadcast() => Broadcast(new Void());
    }
}