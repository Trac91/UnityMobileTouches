using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour, IControlable
{
    Renderer ourRenderer;
    public Renderer myRenderer;

    private Vector3 drag_position;
    // Start is called before the first frame update
    void Start()
    {
        drag_position = transform.position;
        myRenderer = GetComponent<Renderer>();
        myRenderer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
      transform.position = Vector3.Lerp(transform.position, drag_position, 0.05f);  
    }
     public void youveBeenTapped()
    {
      
       Debug.Log("Cube control tapped");
      myRenderer.material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
    }

    public void youveBeenTouched(){
    Debug.Log("THis is a touch");
    }

    public void MoveTo(Vector3 destination){
      drag_position = destination;  
    }

     void ScaleObject(Vector3 initScale, float factor)
    {
        Debug.Log("Trying to scale");
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