using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TaskController : MonoBehaviour {
    public Image Indecator = null;
    [Range(1, 15)]
    public int NumberTask = 0;

    void Awake()
    {
        AppRootStatic.AddTask(this);
    }
    public int GetNumberTask() { return NumberTask; }

    public void SetActiveIndicator(bool _g) { Indecator.enabled = _g; } 
}
