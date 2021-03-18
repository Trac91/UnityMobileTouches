using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControlable 
{
    void youveBeenTouched();

    void youveBeenTapped();

    void MoveTo(Vector3 destination);

    void setRotation(Quaternion quaternion);
   
    void getScale(Vector3 initscale, float factor);

    Quaternion getRotation();

    void deselectObject();
}
