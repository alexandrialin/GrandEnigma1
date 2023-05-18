using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerScreen : MonoBehaviourPunCallbacks, IPunInstantiateMagicCallback
{
    public PhotonView photonView;
    public Text PlayerNameText;

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        UpdatePlayerNameText();
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

    // Call UpdatePlayerNameText() in Update() so that it is called once per frame.
    private void Update()
    {
        UpdatePlayerNameText();
    }
}
