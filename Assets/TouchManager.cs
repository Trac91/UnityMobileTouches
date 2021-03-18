using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    private float timeOfTap;
    private float startTime;
    private float tapThreshold = 0.4f;
    private float starting_distance_to_selected_object;
    private float initDistance;

    public RaycastHit info;

    private Vector3 startingObjectScale;
    private Vector3 initScale;
    private float scaleSize;

    private float sensitivity = 0.01f;
    private float speed = 0.01f;

    private float startingTouchAngle;
    Quaternion startingOrientation;
    private float startingTouchDistance;
    //private CameraControl camera;

    IControlable selectedObject;


    // Start is called before the first frame update
    void Start()
    {

        //GameObject ourCameraPlane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        // ourCameraPlane.transform.position = new Vector3(0, Camera.main.transform.position.y, 0);
        // ourCameraPlane.transform.up = (Camera.main.transform.position - ourCameraPlane.transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Ray ourRay = Camera.main.ScreenPointToRay(Input.touches[0].position);

            Debug.DrawRay(ourRay.origin, 30 * ourRay.direction);

            switch (Input.touches[0].phase)
            {
                case TouchPhase.Began:
                    timeOfTap = 0;

                    break;

                case TouchPhase.Ended:

                    if (timeOfTap < tapThreshold)
                    {
                        RaycastHit info;

                        if (Physics.Raycast(ourRay, out info))
                        {

                            IControlable object_hit = info.transform.GetComponent<IControlable>();
                            if (object_hit != null)
                            {
                                object_hit.youveBeenTapped();
                                Debug.Log("This a tap");
                                selectedObject = object_hit;
                                starting_distance_to_selected_object = Vector3.Distance(Camera.main.transform.position, info.transform.position);
                                //Color newColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);

                            }
                            else
                            {
                                selectedObject.deselectObject();

                            }
                        }
                    }
                    else if (timeOfTap > tapThreshold)
                    {
                        Debug.Log("This is a touch");

                    }
                    break;
                // Drag Code
                case TouchPhase.Moved:

                    Ray new_position_ray = Camera.main.ScreenPointToRay(Input.touches[0].position);

                    if (selectedObject != null)
                    {
                        selectedObject.MoveTo(new_position_ray.GetPoint(starting_distance_to_selected_object));
                    }
                    else
                    {
                        Camera.main.transform.position += (Input.touches[0].deltaPosition.x * Camera.main.transform.right + Input.touches[0].deltaPosition.y * Camera.main.transform.up) * sensitivity;
                    }

                    Debug.Log("This is a drag");
                    break;
            }


            if (Input.touchCount == 2)
            {
                // Store both touches
                Touch touch0 = Input.GetTouch(0);
                Touch touch1 = Input.GetTouch(1);
                if (touch0.phase == TouchPhase.Began || touch1.phase == TouchPhase.Began)
                {

                    initDistance = Vector3.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);                                

                    startingTouchAngle = Mathf.Rad2Deg * Mathf.Atan2(touch1.position.y - touch0.position.y, touch1.position.x - touch0.position.x);

                    startingOrientation = (selectedObject == null) ? Camera.main.transform.rotation : selectedObject.getRotation();

                }

                if (touch0.phase == TouchPhase.Moved || touch1.phase == TouchPhase.Moved)
                {

                    float currentTouchAngle = Mathf.Rad2Deg * Mathf.Atan2(touch1.position.y - touch0.position.y, touch1.position.x - touch0.position.x);
                    float actualTurningAngle = currentTouchAngle - startingTouchAngle;


                    if (selectedObject != null)
                    {

                        selectedObject.setRotation(startingOrientation * Quaternion.AngleAxis(actualTurningAngle, Camera.main.transform.forward));

                        startingTouchDistance = Vector3.Distance(touch0.position, touch1.position);

                        scaleSize = startingTouchDistance / initDistance;
                        selectedObject.getScale(initScale, scaleSize);

                    }
                    else
                    {
                        Camera.main.transform.rotation = startingOrientation * Quaternion.AngleAxis(actualTurningAngle, Camera.main.transform.forward);
                        
                    }

                }

            }
            if (Input.touchCount == 2)
            {
                Touch touch0 = Input.GetTouch(0);
                Touch touch1 = Input.GetTouch(1);
                if (touch0.phase == TouchPhase.Began || touch1.phase == TouchPhase.Began)
                {
                    initDistance = Vector3.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
                }
                if (touch0.phase == TouchPhase.Moved || touch1.phase == TouchPhase.Moved)
                {
                
                   startingTouchDistance = Vector3.Distance(touch0.position, touch1.position);

                        if(selectedObject != null)
                    {
                         scaleSize = (startingTouchDistance / initDistance);
                        selectedObject.getScale(initScale, scaleSize);

                    }
                    else
                    {
                        // Camera.main.transform = Vector3.Distance(touch0.position, touch1.position);
                    }
                    initDistance = startingTouchDistance;
                }
               

            }

        }

    }
}

//startingTouchDistance = Vector3.Distance(touch0.position, touch1.position);                                              //newest distance moved

//initDistance = Vector3.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);                                 //startdistace began

//scaleSize = startingTouchDistance / initDistance;                                                                        //factor is the scale size


// Why is this throw a convert error
//Vector 3                                      Vector3   float
//selectedObject.getScale(initScale, scaleSize);