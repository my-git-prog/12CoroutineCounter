using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private int _increment = 1;
    [SerializeField] private int _startValue = 0;

    private int _currentValue;
    private bool _isRunned = false;

    public event Action<int> Changed;

    private void Start()
    {
        _currentValue = _startValue;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ChangeCounterState();
        }
    }

    private void ChangeCounterState()
    {
        _isRunned = !_isRunned;
        
        if(_isRunned)
        {
            StartCoroutine(IncrementCounter());
        }
    }

    private IEnumerator IncrementCounter()
    {
        Debug.Log("Start Counter");

        var wait = new WaitForSeconds(_delay);

        while (_isRunned)
        {
            _currentValue += _increment;
            Changed?.Invoke(_currentValue);
            
            yield return wait;
        }

        Debug.Log("Stop Counter");
        
        yield break;
    }
}
