using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickPlayerController : MonoBehaviour
{
    private Vector3 _movementVector;

    private CharacterController _characterController;

    [SerializeField]
    private DynamicJoystick _joyStick;


    [SerializeField, Header("Character Properties"), Tooltip("Reference to the rotation speed of the character")]
    private float _rotationSpeed = 50.0f;

    [SerializeField, Tooltip("The character movement speed")]
    private float _speed;



    // Game Loop Methods---------------------------------------------------------------------------
    
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _movementVector = new Vector3(_joyStick.Direction.x, 0.0f, _joyStick.Direction.y);
        Debug.Log(_movementVector.sqrMagnitude);
        // Debug.Log(_orientationVector);
        
        if (_movementVector != Vector3.zero)
        {
            GetCharacterDirection();
            MoveCharacter();
        }

        // transform.Translate(_movementVector * Time.deltaTime * 2);
    }

    // Member Methods------------------------------------------------------------------------------

    private void GetCharacterDirection()
    {
        // Get the angle of the joy stick vectors
        float headingAngle = Mathf.Atan2(_joyStick.Horizontal, _joyStick.Vertical);

        // Take the camera rotation in the calculation wheil removing the x and z axis rotation
        Quaternion cameraRotation = new Quaternion(0.0f, Camera.main.transform.rotation.y, 0.0f, Camera.main.transform.rotation.w);
        
        // Apply the rotation to the transform
        transform.rotation = Quaternion.Euler(0.0f, headingAngle * Mathf.Rad2Deg, 0.0f) * cameraRotation;
    }


    private void MoveCharacter()
    {
        _characterController.Move(transform.forward * _movementVector.sqrMagnitude * Time.deltaTime * _speed);
    }
}
