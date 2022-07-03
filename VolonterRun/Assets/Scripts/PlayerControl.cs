using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float jumpForce = 6.0f;
    private Rigidbody2D _rb;
    private bool _isGrounded;
    [SerializeField] private GameObject body1;
    [SerializeField] private GameObject body2;
    [SerializeField] private GameObject groundCheck;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    private void SizeDown()
    {
        if(GameManager.Instance.isPaused||GameManager.Instance.isGameOver)
            return;
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.S))
        {
            body2.SetActive(true);
            body1.SetActive(false);
        }
        else
        {
            body2.SetActive(false);
            body1.SetActive(true);
        }
    }

    private void Jump()
    {
        _isGrounded =
            Physics2D.OverlapCircle(groundCheck.transform.position, 0.1f, 1 << LayerMask.NameToLayer("Ground"));
        if (!_isGrounded) return;
        _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
        SizeDown();
    }
}