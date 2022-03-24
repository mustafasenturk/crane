using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Rotate90Degrees : MonoBehaviour, IDragHandler, IBeginDragHandler
{

    public float
        distance = 20.0f,
        height = 5.0f,
        heightDamping = 2.0f,
        lookAtHeight = 0.0f,
        rotationSnapTime = 0.3F,
        distanceSnapTime,
        distanceMultiplier;

    private Vector3
        lookAtVector;

    private float
        usedDistance;

    float
        wantedRotationAngle,
        wantedHeight,
        currentRotationAngle,
        currentHeight;

    Quaternion
        currentRotation;
    Vector3
        wantedPosition;

    private float
        yVelocity = 0.0F,
        zVelocity = 0.0F;
    public Transform targetObject;
    public GameObject _camera;
    private float targetAngle = 0;
    private Vector2 touchPos;
    float swipeResistance;
    private bool _swipe;
    public float rotationAmount = 1.0f; // the speed of rotation of the camera

    void Awake()
    {

        lookAtVector = new Vector3(0, lookAtHeight, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Trigger functions if Rotate is requested
        if (!_swipe)
        {
            if (Input.GetKeyDown(KeyCode.Q))

            {
                targetAngle -= 90.0f;
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                targetAngle += 90.0f;
            }
          
        }

        if (targetAngle != 0)
        {
            Rotate();

        }
        else
        {
            _swipe = false;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.delta.x < 0)
        {
            targetAngle -= 90f;
        }
        else
        {
            targetAngle = 90f;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }
    //Method for smooth tracking of the target
    void LateUpdate()
    {
        wantedHeight = targetObject.position.y + height;
        currentHeight = _camera.transform.position.y;
        wantedRotationAngle = targetObject.eulerAngles.y;
        currentRotationAngle = _camera.transform.eulerAngles.y;
        currentRotationAngle = Mathf.SmoothDampAngle(currentRotationAngle, wantedRotationAngle, ref yVelocity, rotationSnapTime);
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
        wantedPosition = targetObject.position;
        wantedPosition.y = currentHeight;
        usedDistance = Mathf.SmoothDampAngle(usedDistance, distance, ref zVelocity, distanceSnapTime);
        wantedPosition += Quaternion.Euler(0, currentRotationAngle, 0) * new Vector3(0, 0, -usedDistance);
        _camera.transform.position = wantedPosition;
        _camera.transform.LookAt(targetObject.position + lookAtVector);
    }

    //Method to rotate the camera
    protected void Rotate()
    {
        _swipe = true;
        if (targetAngle > 0)
        {
            targetObject.RotateAround(targetObject.position, Vector3.up, -rotationAmount);
            targetAngle -= rotationAmount;
        }
        else if (targetAngle < 0)
        {
            targetObject.RotateAround(targetObject.position, Vector3.up, rotationAmount);
            targetAngle += rotationAmount;
        }

    }

}
