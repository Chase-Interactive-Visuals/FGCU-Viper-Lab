/*
 * Notice:
 * This script was prepared by Chase Interactive Visuals, LLC, 
 * and is provided to FGCU for educational purposes only!
 * 
 * Class Summary:
 * Triggers PUBLIC script methods/functions with UI Events 
 */

using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject buttonEvents;

    //Text Mesh Pro Text Object Reference
    [SerializeField] TextMeshProUGUI uiDemoText;

    [SerializeField] TMP_InputField inputField2;

    //int Counter to keep track of button clicks
    int counter = 1;

    //bool to store current canvas state
    bool buttonEventCanvasActive = true;

    public void DisplayButtonEventExamples()
    {
        buttonEvents.SetActive(buttonEventCanvasActive);
        buttonEventCanvasActive = !buttonEventCanvasActive;
    }

     public void ButtonEvent_1()
    {
        uiDemoText.text = "Button 1 Pressed " + counter + " time(s)!";
        Debug.Log("\nButton 1 Pressed " + counter + " time(s)!");
        counter++;
    }
    public void SliderEvent_1(float sliderValue)
    {
        uiDemoText.text = "Slider Value is now: " + sliderValue;
        Debug.Log("\nSlider Value is now: " + sliderValue);
    }
    public void InputFieldEvent_1(string inputFieldValue)
    {
        uiDemoText.text = "OnValueChanged Text: " + inputFieldValue;
        Debug.Log("\nInputField Value is now: " + inputFieldValue);
    }
    public void InputFieldEvent_2()
    {
        uiDemoText.text = "Saved Text: " + inputField2.text;
        Debug.Log("\nInputField Value is now: " + inputField2.text);
    }
    public void ChangeTextColor(int colorSelected)
    {
        if (colorSelected == 0)
        {
            uiDemoText.color = Color.red;
        }
        else if (colorSelected == 1)
        {
            uiDemoText.color = Color.blue;
        }
        else if (colorSelected == 2)
        {
            uiDemoText.color = Color.green;
        }
        else
        {
            uiDemoText.color = Color.yellow;
        }
    }
}
