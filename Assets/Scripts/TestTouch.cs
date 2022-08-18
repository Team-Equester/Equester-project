using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTouch : MonoBehaviour
{

    private Movable InputManager;
    private Camera cameraMain;
    // Start is called before the first frame update
    void Awake()
    {
        InputManager = Movable.Instance;
        cameraMain = Camera.main;
    }
    private void OnEnable()
    {
        InputManager.OnHoldTouchStart += Move;
    }
    private void OnDisable()
    {
        InputManager.OnHoldTouchStop -= Move;
    }
    public void Move(Vector2 screenPosition , float time)
    {
        Vector3 screenCoordinates = new Vector3(screenPosition.x, screenPosition.y, cameraMain.nearClipPlane);
        Vector3 worldCoordinated = cameraMain.ScreenToWorldPoint(screenCoordinates);
        worldCoordinated.z = 0;
        transform.position = worldCoordinated;
    }
}
