using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UpdateCounter : MonoBehaviour
{
    [SerializeField] private string buttonTag;
    private Label label;
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        label = root.Q<Label>(buttonTag);
    }

    /// <summary> Update the UI with the new information </summary>
    public void RefreshCounter(int newValue)
    {
        label.text = newValue.ToString();
    }
}
