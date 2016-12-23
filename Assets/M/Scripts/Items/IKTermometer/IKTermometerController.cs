using UnityEngine;
using System;
using System.Collections;

public class IKTermometerController : MonoBehaviour {

	public GameObject physicValues; // На сцене есть геймобджект, на котором висит только скрипт со значениями температуры и скорости ветра
	public bool isOn = false;
	public TextMesh valueText;

	[Range(0.0f, 10.0f)]
	private float value = 0;
	private float roomTemp;
	private float delay = 0.5f; //не верь предупреждению, если оно есть
    private void Awake()
    {
        AppRootStatic.SetIKTermometr(this);
    }
    // Use this for initialization
    void Start () {
		value = 0;
		valueText.text = String.Format("{0:F2}", value);
	}
	
	// Update is called once per frame
	void Update () {
		GetStateInfo();
	}

	void GetStateInfo()
	{
		if (isOn == false)
		{                                                               
			value = 0;                                                  
			valueText.text = String.Format("{0:F2}", value);
			return;
		}
		else if (isOn)
		{
			roomTemp = physicValues.GetComponent<PhysicValues>().temperature;
			if (roomTemp >= 0f)
			{
				value = Mathf.Clamp((value + (Time.deltaTime / delay)), roomTemp*0.95f, roomTemp);
				
			}
			if (valueText != null) 
			{
				valueText.text = String.Format("{0:F2}", value); //обновляем число на экране
			}
		}
	}

	public void SwitchToolState()
	{
        if (!AppRootStatic.isMoviment) return;
        isOn = !isOn;
		GetStateInfo();
	}

    public void ToolOff()
    {
        isOn = false;
        GetStateInfo();
    }
}
