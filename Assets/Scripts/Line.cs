using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private float _minTime = 0.1f;
    [SerializeField] private Camera _camera;
    private Vector3 _lastPoint;
    private float _currentTime;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lineRenderer.positionCount = 0;
        }
        if (Input.GetMouseButton(0))
        {
            AddPoint();
        }
    }

    private void AddPoint()
    {
        _currentTime += Time.deltaTime;
        if (_minTime > _currentTime)
        {
            return;
        }
        var mousePosition = Input.mousePosition;
        
        var newPoint = _camera.ScreenToWorldPoint(mousePosition);
        newPoint.z = 0;
        _lineRenderer.positionCount += 1;
        _lineRenderer.SetPosition(_lineRenderer.positionCount -1, newPoint);
        _currentTime = 0f;
    }
}
