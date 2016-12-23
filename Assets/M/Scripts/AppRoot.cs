using UnityEngine;
using System.Collections;

public class AppRoot : MonoBehaviour {

	public GameObject[] beacons; // массив для маячков, к которым надо телепортироваться
	public GameObject[] tools;


	// Use this for initialization
	void Start () {
		DeactivateAllTools(); //в эдиторе всегда включен какой-нибудь инструмент. А начинать надо с первого)
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void DeactivateAllTools()
	{
		foreach (GameObject elem in tools)
		{
			elem.SetActive(false);
		}
	}

}
