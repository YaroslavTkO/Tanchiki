using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickTest : MonoBehaviour
{
    public Joystick joystick;
    void Start()
    {



    }
    void Update()
    {
        Debug.Log(GetDegree());
    }

    private float GetDegree()
    {
        var x = joystick.Horizontal;
        var y = joystick.Vertical;

        var degree = Mathf.Atan(y / x) * 180 / Mathf.PI;

        //1 quadrant
        if (x > 0 && y > 0)
            return degree;
        //4 Quadrant
        if (x > 0 && y < 0)
            return degree + 360;

        //2, 3 Quadrant
        return degree + 180;
    }
}