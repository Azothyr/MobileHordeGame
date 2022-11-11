using System;
using System.Globalization;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class TextMeshProBehavior : MonoBehaviour
{
    private TextMeshProUGUI label;
    public UnityEvent startEvent;

    private void Start()
    {
        label = GetComponent<TextMeshProUGUI>();
        startEvent.Invoke();
    }

    public void UpdateLabel(string text)
    {
        label.text = text.ToString(CultureInfo.InvariantCulture);
    }
    
    public void UpdateLabel(FloatData obj)
    {
        label.text = obj.value.ToString(CultureInfo.InvariantCulture);
    }

    public void UpdateLabel(IntData obj)
    {
        label.text = obj.value.ToString(CultureInfo.InvariantCulture);
    }    
    
    public void UpdateLabel(DoubleData obj)
    {
        label.text = obj.value.ToString(CultureInfo.InvariantCulture);
    }
    
    private string FormatTime(float num)
    {
        float hour = Mathf.FloorToInt(num / 3600);
        float minutes = Mathf.FloorToInt(num / 60) % 60;
        float seconds = Mathf.FloorToInt(num % 60);
        //float milliseconds = Mathf.FloorToInt((num * 100 ) % 100);
        return string.Format("{0:00}:{1:00}:{2:00}", hour, minutes, seconds);
    }
    
    public void UpdateLabelTimeFormat(FloatData obj)
    {
        label.text = FormatTime(obj.value);
    }
}