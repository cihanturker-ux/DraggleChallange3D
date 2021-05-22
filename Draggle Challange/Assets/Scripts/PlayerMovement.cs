using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float verticalSpeed;
    [SerializeField] private float horizontalSpeed;
    
    private float deltaX;

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetAxis("Horizontal") != 0)
        {
            TrailController.Instance.ToggleTrails(true);
            
            deltaX = Input.GetAxis("Horizontal");
            if (GameManager.hasGameStarted == false)
            {
                GameManager.hasGameStarted = true;
            }
        }
        else
        {
            TrailController.Instance.ToggleTrails(false);
        }
#elif UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            TrailController.Instance.ToggleTrails(true);

            Touch touch = Input.GetTouch(0);
            deltaX = touch.deltaPosition.x;
            if (GameManager.instance.hasGameStarted == false)
            {
               GameManager.instance.hasGameStarted = true;
            }
        }
        else
        {
            TrailController.Instance.ToggleTrails(false);
        }
#endif
    }

    void FixedUpdate()
    {
        if (GameManager.hasGameStarted)
        {
            transform.position += new Vector3(deltaX * horizontalSpeed, 0, verticalSpeed) * Time.fixedDeltaTime;
        }
    }
}
