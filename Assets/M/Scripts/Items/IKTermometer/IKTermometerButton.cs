using UnityEngine;
using System.Collections;

public class IKTermometerButton : MonoBehaviour {

	private IKTermometerController termometer;
	private MeshCollider mc;
	private int layerMask;
	private string refName;

	// Use this for initialization
	void Start () {
		termometer = gameObject.GetComponentInParent<IKTermometerController>();
		mc = gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider;
		layerMask = 1 << 8;
		layerMask = ~layerMask;
		refName = gameObject.transform.name;
	}
	
	// Update is called once per frame
	void Update () {
		GetMouseInfo();
	}

	void GetMouseInfo()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 50);
			RaycastHit hit;


			if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
			{
				if (hit.collider.transform.name == refName)
				{
					if (termometer.isOn)
					{
						termometer.SwitchToolState();
						Debug.Log("Теперь выключен");
					}
					else
					{
						termometer.SwitchToolState();
						Debug.Log("Теперь включен");
                        AppRootStatic.SetRunedTask();
                    }
				}
			}
		}
	}
}
