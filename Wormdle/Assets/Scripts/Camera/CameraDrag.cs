using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraDrag : MonoBehaviour
{
    private Vector3 _origin;
    private Vector3 _difference;
    private Camera _mainCamera;
    private bool _isDragging;
    private float maxZoom = 0.75f;
    private float minZoom = 10f;
    private void Awake()
    {
        _mainCamera = Camera.main;
    }
    public void ZoomIn()
    {
        if(_mainCamera.orthographicSize>maxZoom) _mainCamera.orthographicSize -= .25f;
    }
    public void ZoomOut()
    {
        if (_mainCamera.orthographicSize < minZoom) _mainCamera.orthographicSize += .25f;
    }
    public void ResetPos()
    {

    }
    public void OnDrag(InputAction.CallbackContext ctx)
    {
        if (ctx.started) _origin = GetMousePosition;
        _isDragging = ctx.started || ctx.performed;
    }
    private void LateUpdate()
    {
        if (!_isDragging) return;
        _difference = GetMousePosition - transform.position;
        transform.position = _origin - _difference;
    }
    private Vector3 GetMousePosition => _mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
}
