using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager Instance;

    public GameObject PlayerPrefab;
    public GameObject PlayerFeed;
    public GameObject PlayerGrid;
    public PhotonView photonView;
    [SerializeField] private Text roomCodeText;

    private string roomCode;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        print("player connected");
        GameObject obj = PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity, 0);
        photonView.RPC("ParentPlayer", RpcTarget.AllBuffered);

    }

    private void OnEnable()
    {
        roomCode = PlayerPrefs.GetString("RoomCode", "");
        if (!string.IsNullOrEmpty(roomCode))
        {
            roomCodeText.text = "Room Code: " + roomCode;
        }
    }

    [PunRPC]
    void ParentPlayer()
    {
        GameObject[] allUsernameObjects = GameObject.FindGameObjectsWithTag("UsernamePrefab");

        foreach (GameObject userObject in allUsernameObjects)
        {
            userObject.transform.SetParent(PlayerGrid.transform, false);
        }
    }


    public void OnPhotonPlayerConnect(Photon.Realtime.Player player)
    {
        

    }
}
