using UnityEngine;
using System.Collections;

public class ToolScroller : MonoBehaviour {

	private AppRoot appRoot;
	private uint currentTool;
	private uint maxToolNumber;
	private uint minToolNumber = 0;

    private void Awake()
    {
        AppRootStatic.SetToolScroller(this);
    }
    // Use this for initialization
    void Start () {
		GameObject appRootObject = GameObject.FindWithTag("AppRoot");
		if (appRootObject != null) { appRoot = appRootObject.GetComponent<AppRoot>(); }
		if (appRootObject == null) { Debug.Log("Cannot find 'AppRoot' script"); Application.Quit(); }
		

		currentTool = 0;
		ChangeTool(currentTool);
		maxToolNumber = ((uint)appRoot.tools.Length) - 1;
	}

	void Update()
	{

	}

	void ChangeTool(uint switchTo)
	{
		appRoot.tools[currentTool].SetActive(false);
		appRoot.tools[switchTo].SetActive(true);
		currentTool = switchTo;
	}
	//функции гоняют инструменты по кольцу
	public void NextTool()
	{
		if (currentTool == maxToolNumber) { ChangeTool(minToolNumber); return; }
		if (currentTool < maxToolNumber) { ChangeTool(currentTool + 1); }
	}

	public void PrevTool()
	{
		if (currentTool == minToolNumber) { ChangeTool(maxToolNumber); return; }
		if (currentTool > minToolNumber) { ChangeTool(currentTool - 1); }
	}

	
}
