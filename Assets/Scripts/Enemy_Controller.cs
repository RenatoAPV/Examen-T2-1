using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public float Velocity = 10;

    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_sr.flipX == true)
        {
            _rb.velocity = new Vector2(Velocity * -1, _rb.velocity.y);
        }
        if (_sr.flipX == false)
        {
            _rb.velocity = new Vector2(Velocity * 1, _rb.velocity.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        var tag = other.gameObject.tag;

        if (tag == "Limite")
        {
            _sr.flipX = true;
        }
        if (tag == "Limite2")
        {
            _sr.flipX = false;
        }
    }
}
