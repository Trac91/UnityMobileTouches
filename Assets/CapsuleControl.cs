using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleControl : MonoBehaviour, IControlable
{

    private Vector3 drag_position;
    public Renderer myRenderer;

    //public RigidBody rb;

    // Start is called before the first frame update
    void Start()
    {
        drag_position = transform.position;
        myRenderer = GetComponent<Renderer>();
        myRenderer.enabled = true;

      //  rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        
       
    }


    void FixedUpdate()
    {
      //  Vector3 movement = Vector3.zero;
      //  movement = new Vector3(-Input.acceleration.y, 0.0f, Input.acceleration.x);

       // rb.AddForce(movement * speed);
    }
    public void youveBeenTapped()
    {  
        myRenderer.material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
    }

    public void youveBeenTouched()
    {
        transform.position += Vector3.right;
        myRenderer.material.color = Color.red;
    }
    public void MoveTo(Vector3 destination)
    {
        drag_position = destination;
    }
    public void setRotation(Quaternion quaternion)
    {
        transform.rotation = quaternion;
    }

    public void getScale(Vector3 initscale, float factor)
    {
        transform.localScale = initscale * factor;
    }

    public Quaternion getRotation()
    {
        throw new System.NotImplementedException();
    }

    public void deselectObject()
    {
        myRenderer.material.color = Color.red;
    }
}