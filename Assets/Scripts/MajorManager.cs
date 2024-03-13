using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MajorManager : MonoBehaviour
{
    public static MajorManager Instance;

    string[] Majors = new string[5];

    int MinMajor = 0;
    int MaxMajor = 0;

    int CurrentMajor = 0;

    public void OnMajorSwitch(InputValue value)
    {
        int move_dir = (int) value.Get<float>();
        MajorManager.Instance.CurrentMajor += move_dir;
        if (MajorManager.Instance.CurrentMajor > MajorManager.Instance.MaxMajor)
            MajorManager.Instance.CurrentMajor = MajorManager.Instance.MinMajor;
        if (MajorManager.Instance.CurrentMajor < MajorManager.Instance.MinMajor)
            MajorManager.Instance.CurrentMajor = MajorManager.Instance.MaxMajor;
        UpdateCollisions();
        Debug.Log(MajorManager.Instance.CurrentMajor);
        Debug.Log(MajorManager.Instance.Majors[MajorManager.Instance.CurrentMajor]);

    }

    public void AddMajor(string major)
    {
        MajorManager.Instance.MaxMajor += 1;
        MajorManager.Instance.Majors[MajorManager.Instance.MaxMajor] = major;
    }

    public void ClearMajors()
    {
        MajorManager.Instance.MaxMajor = 0;
    }

    private void UpdateCollisions()
    {
        for (int i = 0; i < MaxMajor+1; i++)
        {
            string tag = MajorManager.Instance.Majors[i];
            GameObject[] major_objects = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject obj in major_objects)
            {
                if (MajorManager.Instance.CurrentMajor == i)
                    obj.layer = LayerMask.NameToLayer("Ignore Raycast");
                else
                    obj.layer = LayerMask.NameToLayer("Default");

            }
        }

        return;
    }
    // Start is called before the first frame update
    //void Start()
    //{
    //    Majors[0] = "Undeclared";
    //    UpdateCollisions();
    //}
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        MajorManager.Instance.Majors[0] = "Undeclared";
        UpdateCollisions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
