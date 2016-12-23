using UnityEngine;
using System.Collections;

public class RoomNavigation : MonoBehaviour {

	private AppRoot appRoot;
	private PlayerController playerController;
	private uint currentRoom;
	private uint maxRoomNumber;
	private uint minRoomNumber = 0;

    private void Awake()
    {
        AppRootStatic.SetRoomNavigaton(this);
    }

    // Use this for initialization
    void Start () {
		GameObject appRootObject = GameObject.FindWithTag("AppRoot");
		if(appRootObject != null) { appRoot = appRootObject.GetComponent<AppRoot>(); }
		if(appRootObject == null) { Debug.Log("Cannot find 'AppRoot' script"); Application.Quit(); }

		GameObject playerControllerObject = GameObject.FindWithTag("Player");
		if(playerControllerObject != null) { playerController = playerControllerObject.GetComponent<PlayerController>(); }
		if(playerControllerObject == null) { Debug.Log("Cannot find 'PlayerController' script"); Application.Quit(); }

		maxRoomNumber = ((uint)appRoot.beacons.Length)-1;
		currentRoom = 0;
		Teleportation(currentRoom);
	}

	private void Teleportation(uint toRoom)
	{
		playerController.transform.position = appRoot.beacons[toRoom].transform.position;
		currentRoom = toRoom;
	}
	//функции меняют комнаты по кольцу
	public void NextRoom()
	{
		if (currentRoom == maxRoomNumber) { Teleportation(minRoomNumber); return; }
		if (currentRoom < maxRoomNumber) { Teleportation((currentRoom + 1)); }
	}
	public void PreviousRoom()
	{
		if (currentRoom == minRoomNumber) { Teleportation(maxRoomNumber); return; }
		if (currentRoom > minRoomNumber) { Teleportation((currentRoom - 1)); }
	}

}
