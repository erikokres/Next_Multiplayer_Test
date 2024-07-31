using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerMovement : MonoBehaviour
{

    float horizontal;
    float vertical;

    public float speed;
    [SerializeField] Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<PhotonView>().IsMine == true)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        }
        
    }

    

}
