using EventSystem.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBroadcaster : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO onSpacePressed;
    [SerializeField] private IntEventChannelSO onKeyNPressed;
    private int count = 0;

    void Start()
    {
        onKeyNPressed.Broadcast(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            onSpacePressed.Broadcast();

        if (Input.GetKeyDown(KeyCode.M))
        {
            //Raise another event
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            count++;
            onKeyNPressed.Broadcast(count);
        }
    }
}
