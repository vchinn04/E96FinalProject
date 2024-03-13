using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMajorInput : MonoBehaviour
{
    MajorManager major_manager;

    public void OnMajorSwitch(InputValue value)
    {
        major_manager.OnMajorSwitch(value);
    }

    // Start is called before the first frame update
    void Start()
    {
        major_manager = GameObject.Find("MajorManager").GetComponent<MajorManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
