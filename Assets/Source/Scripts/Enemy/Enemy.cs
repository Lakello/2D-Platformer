using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private List<Point> _points = new List<Point>();

    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        UnSubscribe();
    }
    
    protected virtual void OnExtremePointEnter() { }

    private void Subscribe()
    {
        foreach(var point in _points)
        {
            point.ExtremePointEnter += OnExtremePointEnter;
        }
    }

    private void UnSubscribe()
    {
        foreach (var point in _points)
        {
            point.ExtremePointEnter -= OnExtremePointEnter;
        }
    }
}
