using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public FixedJoystick FixedJoystick;
    private float FixedJoystickHorizontal;
    private float FixedJoystickVertical;

    private float OldInpuSystemHorizontal;
    private float OldInpuSystemVerical;

    public float Vertical;
    public float Horizontal;

    private void Awake()
    {
        if (FixedJoystick == null)
        {
            FixedJoystick = FindObjectOfType<FixedJoystick>();
            Debug.LogWarning("FixedJoystick is not innited, trying to find it in the scene!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        FixedJoystickHorizontal = FixedJoystick.Horizontal;
        FixedJoystickVertical = FixedJoystick.Vertical;

        OldInpuSystemHorizontal = Input.GetAxis("Horizontal");
        OldInpuSystemVerical = Input.GetAxis("Vertical");

        Vertical = FixedJoystickVertical + OldInpuSystemVerical;
        Horizontal = FixedJoystickHorizontal + OldInpuSystemHorizontal;

        Vertical = Mathf.Clamp(Vertical, -1, 1);
        Horizontal = Mathf.Clamp(Horizontal, -1, 1);
    }
}