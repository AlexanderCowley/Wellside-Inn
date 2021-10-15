using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    Transform _ObjectTransform;
    Transform _playerXAxis;

    [SerializeField]
    float _cameraSensitivity;

    float _rotX;
    float _rotY;

    float _xVelocity;
    float _yVelocity;

    float _snappiness = 10f;

    float _rotationRange = 90f;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _ObjectTransform = GetComponent<Transform>();
        _playerXAxis = transform.parent.GetComponentInParent<Transform>();
    }

    void RotateCamera()
    {
        _rotY -= Input.GetAxis("Mouse Y") * _cameraSensitivity;
        _yVelocity = Mathf.Lerp(_yVelocity, _rotY, _snappiness * Time.deltaTime);

        _rotY = Mathf.Clamp(_rotY, -_rotationRange, _rotationRange);
        _ObjectTransform.localEulerAngles = Vector3.right * _rotY;
    }

    void RotatePlayer()
    {
        _rotX = Input.GetAxis("Mouse X") * _cameraSensitivity;

        _xVelocity = Mathf.Lerp(_xVelocity, _rotX, _snappiness * Time.deltaTime);
        _playerXAxis.Rotate(Vector3.up * _rotX);
    }

    void Update()
    {
        RotateCamera();
        RotatePlayer();
    }

    /*void AlternateRot()
    {
        Rotation for later

        float angleY = Vector3.Angle(_ObjectTransform.localRotation.eulerAngles, RotVector);
        angleY = Mathf.Clamp(-angleY, -_rotationRange, _rotationRange);
        Quaternion yRotation = Quaternion.AngleAxis(angleY, Vector3.right);
        _ObjectTransform.localRotation = yRotation;
        _ObjectTransform.Rotate(RotVector);
    }

    Maybe helpful later
    private Quaternion ClampRotation(Quaternion quaternion)
    {
        quaternion.x /= quaternion.w;
        quaternion.y /= quaternion.w;
        quaternion.z /= quaternion.w;
        quaternion.w = 1.0f;

        float angleX = 2.0f * Mathf.Atan(quaternion.x);
        angleX = Mathf.Clamp(angleX, -_rotationRange, _rotationRange);
        quaternion.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return quaternion;
    }*/
}
