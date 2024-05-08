using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private IState _currentState;

    
    
    private void Update()
    {
        _currentState.UpdateStats();    
    }


    private void ChangeState<T>(T newState) where T : IState
    {
        _currentState.OnExit();
        _currentState = newState;
        _currentState.OnEnter();
    }
}
