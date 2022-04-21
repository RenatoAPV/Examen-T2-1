using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    public float Velocity = 10;
    private Player_Controller _controller;

    private Rigidbody2D _rb;
    public void SetCatController(Player_Controller playercontroller)
    {
        _controller = playercontroller;
    }
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = new Vector2(Velocity, _rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        var tag = other.gameObject.tag;
        Debug.Log(tag);
        if (tag == "Enemy")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            _controller.IncrementarPuntaje(10);
        }
    }
}
