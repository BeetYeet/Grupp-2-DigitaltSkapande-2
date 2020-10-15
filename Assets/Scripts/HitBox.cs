using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class HitBox : MonoBehaviour
{
    public GameObject target = null;
    public bool inBox = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<PhotonView>().IsMine)
            inBox = true;

    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.GetComponent<PhotonView>().IsMine)
            inBox = false;
    }
}
