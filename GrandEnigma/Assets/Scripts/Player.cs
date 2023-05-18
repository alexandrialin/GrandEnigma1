using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Player : MonoBehaviour
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

        UpdatePlayerNameText();
    }

    private void CheckInput()
    {
        // Your input checking code here...
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
