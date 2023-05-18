using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviour
{
   public GameObject PlayerPrefab;
    public GameObject PlayerFeed;
    public GameObject PlayerGrid;
    public PhotonView photonView;

    // Start is called before the first frame update
    private void Awake()
    {
        print("player connected");
        GameObject obj = PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity, 0);
        photonView.RPC("ParentPlayer", RpcTarget.All, obj.GetComponent<PhotonView>().ViewID);
    }


    [PunRPC]
    void ParentPlayer(int viewID)
    {
        PhotonView targetView = PhotonView.Find(viewID);
        if (targetView != null)
        {
            targetView.transform.SetParent(PlayerGrid.transform, false);
        }
        else
        {
            Debug.LogError("Failed to find target PhotonView with ViewID: " + viewID);
        }
    }



    public void OnPhotonPlayerConnected(Player player)
    {

    }
}
