using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public enum Direction { None = 0, Up, Down, Left, Right }

    Direction _lastDir;

    // Update is called once per frame
    void Update()
    {
        var dir = Direction.None;

        var y = Input.GetAxis("Vertical");
        if (y < 0)
        {
            dir = Direction.Down;
        }
        else if (y > 0)
        {
            dir = Direction.Up;
        }

        var x = Input.GetAxis("Horizontal");
        if (x < 0)
        {
            dir = Direction.Left;
        }
        else if (x > 0)
        {
            dir = Direction.Right;
        }

        if (dir != _lastDir)
        {
            _animator.SetInteger("direction", (int) dir);
            _lastDir = dir;
        }
        else if(_lastDir != Direction.None)
        {
            //set to none so animation just repeats without transition
            _animator.SetInteger("direction", (int) Direction.None);
        }

        const float speed = .05f;
        
        transform.Translate(x * speed, y * speed, 0);
    }
}
