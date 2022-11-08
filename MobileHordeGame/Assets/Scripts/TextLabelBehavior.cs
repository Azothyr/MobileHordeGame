using System.Globalization;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextLabelBehavior : MonoBehaviour
{
    private Text label;
    public UnityEvent startEvent;

    private void Start()
    {
        label = GetComponent<Text>();
        startEvent.Invoke();
    }
    
    public void UpdateLabel(FloatData obj)
    {
        label.text = obj.value.ToString(CultureInfo.InvariantCulture);
    }

    public void UpdateLabel(IntData obj)
    {
        label.text = obj.value.ToString(CultureInfo.InvariantCulture); 
    }

    private string FormatTime(float num)
    {
        float minutes = Mathf.FloorToInt(num / 60);
        float seconds = Mathf.FloorToInt(num % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    public void UpdateLabelTimeFormat(FloatData obj)
    {
        label.text = FormatTime(obj.value);
    }
}