using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickPlayerController : MonoBehaviour
{
    private Vector3 _orientationVector;

    private CharacterController _characterController;

    [SerializeField]
    private DynamicJoystick _joyStick;


    [SerializeField, Header("Character Properties"), Tooltip("Reference to the rotation speed of the character")]
    private float _rotationSpeed = 50.0f;



    // Game Loop Methods---------------------------------------------------------------------------
    
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _orientationVector = new Vector3(_joyStick.Direction.x, 0.0f, _joyStick.Direction.y);
        // Debug.Log(_orientationVector);
        GetCharacterDirection();

        // transform.Translate(_movementVector * Time.deltaTime * 2);
    }

    // Member Methods------------------------------------------------------------------------------

    private void GetCharacterDirection()
    {
        // Get the angle of the joy stick vectors
        float headingAngle = Mathf.Atan2(_joyStick.Horizontal, _joyStick.Vertical);
        Debug.Log(headingAngle * Mathf.Rad2Deg);

        // Take the camera rotation in the calculation wheil removing the x and z axis rotation
        Quaternion cameraRotation = new Quaternion(0.0f, Camera.main.transform.rotation.y, 0.0f, Camera.main.transform.rotation.w);
        
        // Apply the rotation to the transform
        transform.rotation = Quaternion.Euler(0.0f, headingAngle * Mathf.Rad2Deg, 0.0f) * cameraRotation;
    }
}