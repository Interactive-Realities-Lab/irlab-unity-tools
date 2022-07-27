using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScale : MonoBehaviour
{
    private float originalScale;
    [SerializeField] private float newScale; 

    private void Start()
    {
        originalScale = transform.localScale.x;
    }

    public void Change()
    {
        transform.localScale = transform.localScale.x == originalScale ? transform.localScale = new Vector3(newScale, newScale, newScale): transform.localScale = new Vector3(originalScale, originalScale, originalScale);
    }
}
