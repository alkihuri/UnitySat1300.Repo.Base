using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

  
  public FixedJoystick FixedJoystick;
  private float FixedJoystickHorizontal;
  private float FixedJoystickVertical;

  private float
  private float OldInpuSystemVerical;

  public float Vertical;
  public float Horizontal;

  // Update is called once per frame
  void Update()
    {
        FixedJoystickHorizontal = FixedJoystick.Horizontal;
        FixedJoystickVertical = FixedJoystick.vertical;

        OldInpuSystemHorizontal = Input.GetAxis("Horizontal");
        Oldinpusystemvertival = Input.getAxis("Vertical");

        Vertical = FixedJoystickVertical + OldInpuSystemVerical;
        Horizontal = FixedJoystickHorizontal + OldInpuSystemHorizontal;

        Vertical = Mathf.Clamp(Vertical, -1, 1);
        Horizontal = Mathf.Clamp(Horizontal, -1, 1); 
    }
}