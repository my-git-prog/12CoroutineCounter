using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.Changed += ShowCounter;
    }

    private void OnDisable()
    {
        _counter.Changed -= ShowCounter;
    }

    private void ShowCounter(int value)
    {
        Debug.Log(value);
    }
}
