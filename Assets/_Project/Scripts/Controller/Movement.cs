using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Transform _ObjectTransform;
    CharacterController charController;
    [SerializeField]
    float _movementSpeed = 5f;

    private void Awake()
    {
        _ObjectTransform = GetComponent<Transform>();
        charController = GetComponent<CharacterController>();
    }

    void MoveTarget()
    {
        float xAxis = Input.GetAxis("Horizontal") * _movementSpeed * Time.deltaTime;
        float zAxis = Input.GetAxis("Vertical") * _movementSpeed * Time.deltaTime;

        Vector3 DesiredPosition = _ObjectTransform.right * xAxis + _ObjectTransform.forward * zAxis;

        charController.Move(DesiredPosition); 
    }

    private void Update()
    {
        MoveTarget();
    }
}
