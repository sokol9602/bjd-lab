using UnityEngine;
using System.Collections;

public class PhysicValues : MonoBehaviour {

	[Range(-50, 50)]
	public float temperature;
	[Range(0, 10)]
	public float windSpeed;
    private void Awake()
    {
        AppRootStatic.SetPhysicValues(this);
    }
    // Use this for initialization
    void Start()
	{

	}
}
