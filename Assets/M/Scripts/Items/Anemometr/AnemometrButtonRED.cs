using UnityEngine;
using System.Collections;

public class AnemometrButtonRED : MonoBehaviour {

	private AnemometrController anemometr;
	private Vector3 deactivePos;// = new Vector3(-0.014f, 1.743001f, 0.1524169f);
	private Vector3 activePos;//new Vector3(0, 1.743001f, 0.1524169f);
	private Vector3 currPos;
	private MeshCollider mc;
	private int layerMask;
	private string refName;

	// Use this for initialization
	void Start()
	{
		anemometr = gameObject.GetComponentInParent<AnemometrController>();
		mc = gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider;
		layerMask = 1 << 8;
		layerMask = ~layerMask;
		refName = gameObject.transform.name;
		//currPos = gameObject.GetComponent<Transform>();
		activePos = gameObject.transform.localPosition;
		deactivePos = activePos + new Vector3(-0.014f, 0, 0);
		transform.localPosition = deactivePos;
	}

	void Update()
	{
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
					if (!anemometr.isOn)
					{
						Debug.Log("Уже выключен");
					}
					else
					{
						anemometr.SwitchToolState();
						//transform.localPosition = deactivePos;
						Debug.Log("Теперь выключен");
					}
				}
			}
		}
	}

	void SwitchButtonTransform()
	{
		//if(gameObject.transform.localPosition==activePos) ga
	}
}
