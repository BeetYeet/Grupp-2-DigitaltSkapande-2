using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void eventAnim()
    {
        PhotonLobby.lobby.AddConnectUI();
    }
}
