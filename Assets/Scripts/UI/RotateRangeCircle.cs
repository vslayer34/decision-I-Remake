using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRangeCircle : MonoBehaviour
{
    [SerializeField, Tooltip("rotation range of the aim range")]
    private float _rotationRange;

    [SerializeField, Tooltip("time for rotation")]
    private float _rotationTime;

    [SerializeField, Tooltip("The twean type")]
    private LeanTweenType _tweenType;

    // private void Start()
    // {
    //     LeanTween.rotateY(gameObject, _rotationRange, _rotationTime).setLoopPingPong().setEase(_tweenType);
    // }

    private void Update()
    {
        transform.Rotate(Vector3.forward, _rotationRange * Time.deltaTime);
    }
}
