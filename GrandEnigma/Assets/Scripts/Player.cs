using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Player : MonoBehaviourPunCallbacks
{
    public PhotonView photonView;
    public Text PlayerNameText;

    private void Awake()
    {
        UpdatePlayerNameText();
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            CheckInput();
        }
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        UpdatePlayerNameText();
    }

    private void CheckInput()
    {
        // Your input handling code here
    }

    private void UpdatePlayerNameText()
    {
        if (photonView.IsMine)
        {
            PlayerNameText.text = PhotonNetwork.NickName;
        }
        else if (photonView.Owner != null) // Check if owner is not null
        {
            PlayerNameText.text = photonView.Owner.NickName;
            PlayerNameText.color = Color.cyan;
        }
    }
}
