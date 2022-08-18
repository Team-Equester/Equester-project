using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[DefaultExecutionOrder(-1)]
public class Movable : Singleton<Movable>
{
    public delegate void TouchStartEvent(Vector2 position, float time);
    public event TouchStartEvent OnHoldTouchStart;
    public delegate void TouchStopEvent(Vector2 position, float time);
    public event TouchStopEvent OnHoldTouchStop;

    private PlayerControl TouchControls;
    private void Awake()
    {
        TouchControls = new PlayerControl();
    }
    private void OnEnable()
    {
        TouchControls.Enable();   
    }
    private void OnDisable()
    {
        TouchControls.Disable();
    }
    private void Start()
    {
        TouchControls.Touch.TouchHold.started += ctx => HoldTouchStart(ctx);
        TouchControls.Touch.TouchHold.canceled += ctx => HoldTouchEnd(ctx);
    }

    private void HoldTouchStart(InputAction.CallbackContext obj)
    {
        Debug.Log("Touch Started " + TouchControls.Touch.TouchPosition.ReadValue<Vector2>());
        if(OnHoldTouchStart != null) { OnHoldTouchStart(TouchControls.Touch.TouchPosition.ReadValue<Vector2>(),(float) obj.startTime); }
    }

    private void HoldTouchEnd(InputAction.CallbackContext obj)
    {
        Debug.Log("Touch Ended");
        if (OnHoldTouchStop != null) { OnHoldTouchStop(TouchControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)obj.time); }
    }
}
