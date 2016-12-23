using UnityEngine;
using System;
using System.Collections;

public class AnemometrController : MonoBehaviour {
	
	public GameObject physicValues; // На сцене есть геймобджект, на котором висит только скрипт со значениями температуры и скорости ветра
	public Transform fan;
	public bool isOn = false;
	public TextMesh valueText;
	
	[Range(0.0f,10.0f)]
	private float value = 0;
	private float roomWindSpeed;
	private float delay = 4; //не верь предупреждению, если оно есть
    private void Awake()
    {
        AppRootStatic.SetAnemometr(this);
    }
    // Use this for initialization
    void Start () {
		value = 0;
		valueText.text = String.Format("{0:F2}", value);
	}
	
	// Update is called once per frame
	void Update () {
		GetStateInfo(); //возможно это затратно, но не затратнее рендеринга комнат :)
	}

	// Функция занимается непосредственно вращением лопастей. Правда Махонько накосячила и косяк свой так и не исправила: пивот у лопастей немного смещён, вращается криво
	void GetStateInfo()
	{
		if (isOn == false)
		{																//Если пользователь выключил прибор, то лопасти не вращаются и value сбрасывается на 0
			value = 0;                                                  //чтобы при следующем включении лопасти начинала крутиться с нулевой скоростью
			valueText.text = String.Format("{0:F2}", value);             
			return;
		}               
		else if (isOn)
		{
			roomWindSpeed = physicValues.GetComponent<PhysicValues>().windSpeed;
			if (roomWindSpeed >= 0f)
			{
				value = Mathf.Clamp(value + (Time.deltaTime / delay), 0, roomWindSpeed); //это всё для того, чтобы лопасти плавно набирали скорость
			}
			if (valueText != null) //Не помню, зачем вставлял эту и следующую проверки ещё в прошлом семестре, но они тут есть
			{
				valueText.text = String.Format("{0:F2}", value); //обновляем число на экране
			}
			if (fan != null)
			{
				fan.Rotate(Vector3.right, Time.deltaTime * 60 * value); //вращаются вокруг своей оси Х. Документация гласит, что просто "Time.deltaTime" во втором аргументе вращают на 1 градус в секунду.
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
