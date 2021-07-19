using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // All Variables
    public Rigidbody _rigidbody;
    public Camera finishCam;
    [SerializeField] private float _firstLine;
    [SerializeField] private float _secondLine;
    [SerializeField] private float _thirdLine;
    [SerializeField] private float _moveThreshold;
    [SerializeField] private float _speed;
    [SerializeField] private float _moveSpeed;
    private float _lastMoveTime;
    private Vector3 moveTo;

    enum Lane
    {
        First,
        Second,
        Third
    }

    private Lane _lane = Lane.Second;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            float movePow = touch.deltaPosition.normalized.x;
            if (Mathf.Abs(movePow) > _moveThreshold && Time.time - _lastMoveTime > 0.5f)
            {
                _lastMoveTime = Time.time;
                if (movePow < 0)
                {
                    switch (_lane)
                    {
                        case Lane.First:
                            break;
                        case Lane.Second:
                            moveTo = new Vector3(_firstLine, transform.position.y, transform.position.z);
                            _lane = Lane.First;
                            break;
                        case Lane.Third:
                            moveTo = new Vector3(_secondLine, transform.position.y, transform.position.z);
                            _lane = Lane.Second;
                            break;
                    }
                }

                if (movePow > 0)
                {
                    switch (_lane)
                    {
                        case Lane.First:
                            moveTo = new Vector3(_secondLine, transform.position.y, transform.position.z);
                            _lane = Lane.Second;
                            break;
                        case Lane.Second:
                            moveTo = new Vector3(_thirdLine, transform.position.y, transform.position.z);
                            _lane = Lane.Third;
                            break;
                        case Lane.Third:
                            break;
                    }
                }
            }
        }

        Move(moveTo);
    }


    private void FixedUpdate()
    {
        _rigidbody.velocity = transform.forward * (Time.deltaTime * _moveSpeed);
    }


    private void Move(Vector3 moveTo)
    {
        moveTo = new Vector3(moveTo.x, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, moveTo, Time.deltaTime * _speed);
    }


    // Player's speed down slowly when reach at finish line
    public void PlayerSpeedDown()
    {
        StartCoroutine(FinishGame());
    }

    // IEnumerator Coroutine to get slow effect
    IEnumerator FinishGame()
    {
        float timer = 0;
        float fixSpeed = _moveSpeed;
        while (true)
        {
            timer += Time.deltaTime;
            _moveSpeed = Mathf.Lerp(fixSpeed, 0, timer);
            if (timer >= 1f)
            {
                break;
            }

            yield return new WaitForEndOfFrame();
        }
    }
}