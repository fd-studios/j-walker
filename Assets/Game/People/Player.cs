using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera Camera;

    Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetInteger("direction", (int) _lastDir);
        _animator.SetBool("walk", false);
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

        var walk = dir != Direction.None;


        if (dir != _lastDir || walk != _animator.GetBool("walk"))
        {
            if (dir == Direction.None)
                _animator.SetInteger("direction", (int)_lastDir);
            else
                _animator.SetInteger("direction", (int)dir);

            _animator.SetBool("walk", walk);
            _lastDir = dir;
        }
        else if (_lastDir != Direction.None && walk)
        {
            //set to none so animation just repeats without transition
            _animator.SetInteger("direction", (int)Direction.None);
        }

        if(walk)
        {
            const float speed = .05f;

            transform.Translate(x * speed, y * speed, 0);

            var camX = Mathf.Clamp(transform.position.x, -5, 4);
            var camY = Mathf.Clamp(transform.position.y, 0, 14);
            Camera.transform.SetPositionAndRotation(new Vector3(camX, camY, Camera.transform.position.z), Camera.transform.rotation);
        }
    }
}
