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
        GameObject obj = PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector3(this.transform.position.x , this.transform.position.y, this.transform.position.z), Quaternion.identity, 0);
        
        //obj.transform.SetParent(PlayerGrid.transform, false);
        photonView.RPC("ParentPlayer", RpcTarget.All, obj);

       
    } 
    
    [PunRPC] void ParentPlayer(GameObject yees)
    {
        yees.transform.SetParent(PlayerGrid.transform, false);
    }


    public void OnPhotonPlayerConnected(Player player)
    {

    }
}
