using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CreateMenu : MonoBehaviour {

    public bool locked = true;
    public int maxSize = 100;
    public int x;
    public int y;

	public void callNext()
    {
        PlayerPrefs.SetInt("x-Value", x);
        PlayerPrefs.SetInt("y-Value", y);
        SceneManager.LoadScene("MapEditor");
    }

    public void onXSliderMoved()
    {
        TMP_InputField input = GameObject.Find("x-Value").GetComponent<TMP_InputField>();
        Slider slider = GameObject.Find("x").GetComponent<Slider>();
        input.text = ""+ Mathf.RoundToInt(slider.value * 100);
        x = Mathf.RoundToInt(slider.value * 100);
        TMP_Text errorText = GameObject.Find("ErrorMessage").GetComponent<TMP_Text>();
        errorText.text = "";
        if (locked)
        {
            TMP_InputField inputY = GameObject.Find("y-Value").GetComponent<TMP_InputField>();
            Slider sliderY = GameObject.Find("y").GetComponent<Slider>();
            inputY.text = "" + Mathf.RoundToInt(slider.value * 100);
            sliderY.value = slider.value;
        }
    }
    public void onYSliderMoved()
    {
        TMP_InputField input = GameObject.Find("y-Value").GetComponent<TMP_InputField>();
        Slider slider = GameObject.Find("y").GetComponent<Slider>();
        input.text = "" + Mathf.RoundToInt(slider.value * 100);
        y = Mathf.RoundToInt(slider.value * 100);
        TMP_Text errorText = GameObject.Find("ErrorMessage").GetComponent<TMP_Text>();
        errorText.text = "";
        if (locked)
        {
            TMP_InputField inputX = GameObject.Find("x-Value").GetComponent<TMP_InputField>();
            Slider sliderX = GameObject.Find("x").GetComponent<Slider>();
            inputX.text = "" + Mathf.RoundToInt(slider.value * 100);
            sliderX.value = slider.value;
        }
    }

    public void onXValueChanged()
    {
        TMP_InputField input = GameObject.Find("x-Value").GetComponent<TMP_InputField>();
        Slider slider = GameObject.Find("x").GetComponent<Slider>();
        int wert;
        bool b = int.TryParse(input.text, out wert);
        if (b)
        {
            slider.value = ((float) wert) / 100;
            x = Mathf.RoundToInt(slider.value * 100);
            TMP_Text errorText = GameObject.Find("ErrorMessage").GetComponent<TMP_Text>();
            errorText.text = "";
            if (locked)
            {
                TMP_InputField inputY = GameObject.Find("y-Value").GetComponent<TMP_InputField>();
                Slider sliderY = GameObject.Find("y").GetComponent<Slider>();
                inputY.text = "" + Mathf.RoundToInt(slider.value * 100);
                sliderY.value = slider.value;
            }
        }
        else
        {
            TMP_Text errorText = GameObject.Find("ErrorMessage").GetComponent<TMP_Text>();
            errorText.text = errorText.text += "\nEnter correct value for x!";
        }
    }

    public void onYValueChanged()
    {
        TMP_InputField input = GameObject.Find("y-Value").GetComponent<TMP_InputField>();
        Slider slider = GameObject.Find("y").GetComponent<Slider>();
        int wert;
        bool b = int.TryParse(input.text, out wert);
        if (b)
        {
            slider.value = ((float)wert) / 100;
            y = Mathf.RoundToInt(slider.value * 100);
            TMP_Text errorText = GameObject.Find("ErrorMessage").GetComponent<TMP_Text>();
            errorText.text = "";
            if (locked)
            {
                TMP_InputField inputX = GameObject.Find("x-Value").GetComponent<TMP_InputField>();
                Slider sliderX = GameObject.Find("x").GetComponent<Slider>();
                inputX.text = "" + Mathf.RoundToInt(slider.value * 100);
                sliderX.value = slider.value;
            }
        }
        else
        {
            TMP_Text errorText = GameObject.Find("ErrorMessage").GetComponent<TMP_Text>();
            errorText.text = errorText.text+="\nEnter correct value for y!";
        }
    }

    public void onLockChecked()
    {
        Toggle lockToggle = GameObject.Find("LockToggle").GetComponent<Toggle>();
        if (lockToggle.isOn)
        {
            locked = true;
            TMP_InputField inputX = GameObject.Find("y-Value").GetComponent<TMP_InputField>();
            Slider slider = GameObject.Find("x").GetComponent<Slider>();
            Slider sliderX = GameObject.Find("y").GetComponent<Slider>();
            inputX.text = "" + Mathf.RoundToInt(slider.value * 100);
            y = Mathf.RoundToInt(sliderX.value * 100);
            sliderX.value = slider.value;
        }
        else
        {
            locked = false;
        }
    }
}
