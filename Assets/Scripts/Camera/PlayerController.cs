using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Min(0f)]
    [SerializeField]
    float moveSpeed = 2.5f;
    //Define the speed at which the object moves.
    

    [Min(0f)]
    [SerializeField]
    float rotSpeed = 60f;

    Rigidbody rb;
    Vector2 moveAxis;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        UpdateMoveAxis();
    }

    private void FixedUpdate()
    {
        UpdatePos();
        UpdateRot();
    }

    void UpdateMoveAxis()
    {
        moveAxis.x = Input.GetAxis("Horizontal1");
        moveAxis.y = Input.GetAxis("Vertical1");
    }

    void UpdatePos()
    {
        var posMovement = transform.forward * (moveAxis.y * moveSpeed * Time.deltaTime);
        var newPos = transform.position + posMovement;

        rb.MovePosition(newPos);
    }

    void UpdateRot()
    {
        var rotMovement = moveAxis.x * rotSpeed * Time.deltaTime;
        var currRot = rb.rotation.eulerAngles;
        currRot.y += rotMovement;

        var newRot = Quaternion.Euler(currRot);
        rb.MoveRotation(newRot);
    }



}
