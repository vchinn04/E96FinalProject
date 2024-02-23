using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MajorManager : MonoBehaviour
{
    string[] Majors = new string[5];

    int MinMajor = 0;
    int MaxMajor = 0;

    int CurrentMajor = 0;

    public void OnMajorSwitch(InputValue value)
    {
        int move_dir = (int) value.Get<float>();
        CurrentMajor += move_dir;
        if (CurrentMajor > MaxMajor)
            CurrentMajor = MinMajor;
        if (CurrentMajor < MinMajor)
            CurrentMajor = MaxMajor;
        UpdateCollisions();
        Debug.Log(CurrentMajor);
    }

    public void AddMajor(string major)
    {
        MaxMajor += 1;
        Majors[MaxMajor] = major;
    }

    public void ClearMajors()
    {
        MaxMajor = 0;
    }

    private void UpdateCollisions()
    {
        for (int i = 0; i < MaxMajor+1; i++)
        {
            string tag = Majors[i];
            GameObject[] major_objects = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject obj in major_objects)
            {
                if (CurrentMajor == i)
                    obj.layer = LayerMask.NameToLayer("Ignore Raycast");
                else
                    obj.layer = LayerMask.NameToLayer("Default");

            }
        }

        return;
    }
    // Start is called before the first frame update
    void Start()
    {
        Majors[0] = "Undeclared";
        UpdateCollisions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
