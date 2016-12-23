using UnityEngine;
using System.Collections;

public class ObjectRotationViewers : MonoBehaviour {
    private float RotationSpeed = 1500;
    private float MoveSpeed = 10.0f;
    private float ZoomSpeed = 15.3f;


    public float MinDist = 5.0f;
    public float MaxDist = 40.0f;
    public Camera cam;
    [Range(1, 19)]
    public int NumberModel;

    void Awake(){AppRootStatic.AddObjectViewer(this);}

	// Use this for initialization
	void Start () {
        cam = GetComponentInParent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!isActive()) return;

        Vector3 dir =transform.position - cam.transform.position;
        float dist = Mathf.Abs(dir.magnitude);

        Vector3 camDir = cam.transform.forward;
        Vector3 camLeft = Vector3.Cross(camDir, Vector3.down);
        Vector3 camDown = Vector3.Cross(camDir, camLeft);
        //Vector3 camUp = Vector3.Cross(camLeft, camDir);

        float dx = Input.GetAxis("Mouse X");
        float dy = Input.GetAxis("Mouse Y");

        // rotate
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(camLeft, dy * RotationSpeed * Time.deltaTime, Space.World);
            transform.Rotate(Vector3.down, dx * RotationSpeed * Time.deltaTime, Space.Self);
        }
        // zoom
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            if (dist > MinDist)
                transform.Translate(-dir * ZoomSpeed * Time.deltaTime, Space.World);
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            if (dist < MaxDist)
                transform.Translate(dir * ZoomSpeed * Time.deltaTime, Space.World);
    }

    public void SetActive(bool _g) { gameObject.SetActive(_g); }

    public bool isActive() { return gameObject.activeInHierarchy; }
}
