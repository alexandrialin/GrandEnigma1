using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public InputField roomNameInputField; // Input field for room name, assign this in Inspector
    public Text roomCodeText; // Text field to display the room code, assign this in Inspector

    // Method called when "Create Room" button is clicked
    public void OnCreateRoomButtonClicked()
    {
        // Get the name from input field
        string roomName = roomNameInputField.text;

        // Create the room
        if (!string.IsNullOrEmpty(roomName))
        {
            RoomOptions options = new RoomOptions();
            options.MaxPlayers = 10; // Or any other number
            PhotonNetwork.CreateRoom(roomName, options, TypedLobby.Default);
        }
    }

    public override void OnCreatedRoom()
    {
        roomCodeText.text = "Room Code: " + PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Failed to create room: " + message);
    }
}
