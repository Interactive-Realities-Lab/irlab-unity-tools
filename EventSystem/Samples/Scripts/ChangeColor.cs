
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Color color;
    private Material m;

    private void Start()
    {
        m = GetComponent<Renderer>().material;
        GetRandomColor();   
    }

    /// <summary> Chooses a random color and apply it to the object's material </summary>
    public void GetRandomColor()
    {
        m.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    }
}
