using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControl : MonoBehaviour,IControlable
{
  
    public Renderer myRenderer;
    Color original;
    public void MoveTo(Vector3 destination)
    {
        transform.position = destination;
    }

    public void youveBeenTapped()
    {
        myRenderer.material.color = Color.cyan;

    }

    public void youveBeenTouched()
    { 
                         
        myRenderer.material.color = Color.red;
       
    }

    public void unselectObject()
    {
        myRenderer.material.color = Color.red;
    }

  
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        myRenderer.enabled = true;


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
