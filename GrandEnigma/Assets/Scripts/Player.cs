using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerScreen : MonoBehaviourPun, IPunInstantiateMagicCallback
{

    public PhotonView photonView;
    public Text PlayerNameText;
/*
    private void Awake()
    {
        if (photonView.IsMine)
        {

            PlayerNameText.text = PhotonNetwork.NickName;

        }
        else
        {
            PlayerNameText.text = photonView.Owner.NickName;
            PlayerNameText.color = Color.cyan;
        }
    }
*/

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        if (photonView.IsMine)
        {

            PlayerNameText.text = PhotonNetwork.NickName;

        }
        else
        {
            PlayerNameText.text = photonView.Owner.NickName;
            PlayerNameText.color = Color.cyan;
        }
    }
}
