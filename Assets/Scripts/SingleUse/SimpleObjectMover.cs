using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectMover : MonoBehaviourPun //IPunObservable
{
    [SerializeField]
    private float moveSpeed = 1f;

    private Animator anim;

    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
        
    //}

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    private void Update()
    {
        if (base.photonView.IsMine)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            transform.position += (new Vector3(x, y, 0f) * moveSpeed);

            UpdateMovingBool((x != 0f || y != 0f));
        }
    }

    private void UpdateMovingBool(bool moving)
    {
        anim.SetBool("Moving", moving);
    }
}
