using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float SPEED = 5.0f;

    private bool is_moving = false;
    private float scan_distance_addition = 1.0f;

    private Vector2 move_direction = new Vector2(0, 0);

    private UnityEngine.Vector2 target = UnityEngine.Vector2.zero;
    private UnityEngine.Vector2 cur_pos = UnityEngine.Vector2.zero;

    private GameObject PlayerTarget;
    private PlayerCollision CollisionHandler;

    public void OnMove(InputValue value)
    {
        Vector2 move_dir = value.Get<Vector2>();
        float x_dir = move_dir.x;
        float y_dir = move_dir.y;

        if (x_dir != 0)
            move_dir.x = x_dir / Mathf.Abs(x_dir);

        if (y_dir != 0)
            move_dir.y = y_dir / Mathf.Abs(y_dir);

        move_direction = move_dir;
    }

    private void UpdateLocation() 
    {
        float y_axis = move_direction.y;
        float x_axis = move_direction.x;

        PlayerTarget.transform.position = new UnityEngine.Vector2(cur_pos.x, cur_pos.y); 

        if (x_axis != 0 && !is_moving) // X Axis
        {
            is_moving = true;

            if (!CollisionHandler.CheckCollision(new UnityEngine.Vector2(x_axis, 0), 0.45f + scan_distance_addition, PlayerTarget))
            {
                target = new UnityEngine.Vector2(cur_pos.x + x_axis, cur_pos.y);
                cur_pos = target;
                PlayerTarget.transform.position = new UnityEngine.Vector2(cur_pos.x + x_axis, cur_pos.y); 
            }
        }

        if (y_axis != 0 && !is_moving) // Y Axis
        {
            is_moving = true;

            if (!CollisionHandler.CheckCollision(new UnityEngine.Vector2(0, y_axis), 0.45f + scan_distance_addition, PlayerTarget))
            {
                target = new UnityEngine.Vector2(cur_pos.x, cur_pos.y + y_axis);
                cur_pos = target;
                PlayerTarget.transform.position = new UnityEngine.Vector2(cur_pos.x, cur_pos.y + y_axis); 
            }
        }
    }

    private void MovePlayer() 
    {
        transform.position = UnityEngine.Vector3.MoveTowards(transform.position, target, SPEED * Time.deltaTime);

        if ((transform.position.x == target.x) && (transform.position.y == target.y))
        {
            is_moving = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        cur_pos = transform.position;
        target = transform.position;

        PlayerTarget = GameObject.Find("PlayerTarget");
        PlayerTarget.transform.parent = null;
        PlayerTarget.transform.position = cur_pos;
        CollisionHandler = PlayerTarget.GetComponent<PlayerCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_moving) 
            UpdateLocation();

        if (is_moving)
            MovePlayer();
    }
}
