using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateType
{
    Idle, Attack
}

public class StateMachine
{
    private Dictionary<StateType, PlayerState> _stateContainer;
    public StateType CurrentType { get; private set; }
    // 여기서 오버플로우 문제 발생..
    private PlayerState CurrentState => _stateContainer[CurrentType];

    public StateMachine(params PlayerState[] states)
    {
        _stateContainer = new Dictionary<StateType, PlayerState>();

        foreach (var s in states)
        {
            if (!_stateContainer.ContainsKey(s.ThisType))
            {
                _stateContainer.Add(s.ThisType, s);    
            }
            s.Machine = this;
        }

        CurrentType = states[0].ThisType;
        CurrentState.Enter();
    }

    public void OnUpdate()
    {
        CurrentState.OnUpdate();
    }

    public void ChangeState(StateType state)
    {
        // 상태를 변경해주는데 조건이 없음
        if (CurrentType != state)
        {
            CurrentState.Exit();
            CurrentType = state;
            CurrentState.Enter();
        }      
    }
}
