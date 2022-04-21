using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    public float JumpForce = 10;
    public float Velocity = 10;
    public GameObject BulletPrefab;

    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _sr;
    public Text monedas1;
    public Text monedas2;
    public Text monedas3;
    public Text puntos;

    private int monedaR1 = 0;
    private int monedaR2 = 0;
    private int monedaR3 = 0;
    private int puntaje = 0;

    private static readonly string ANIMATOR_STATE = "Estado";
    private static readonly int ANIMATOR_IDLE = 0;
    private static readonly int ANIMATOR_RUN = 1;
    private static readonly int ANIMATOR_JUMP = 2;
    private static readonly int ANIMATION_SLIDE = 3;

    private static readonly int Right = 1;
    private static readonly int Left = -1;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        monedas1.text = "Moneda 1: " + monedaR1;
        monedas2.text = "Moneda 2: " + monedaR2;
        monedas3.text = "Moneda 3: " + monedaR3;
        puntos.text = "Puntos: " + puntaje; 
        _rb.velocity = new Vector3(0, _rb.velocity.y);
        ChangeAnimation(ANIMATOR_IDLE);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Desplazarse(Right);

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Desplazarse(Left);

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            ChangeAnimation(ANIMATOR_JUMP);
        }
        if (Input.GetKey(KeyCode.C))
        {
            Deslizarse();
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            Disparar();
        }
    }
    private void Deslizarse()
    {
        ChangeAnimation(ANIMATION_SLIDE);
    }

    private void Desplazarse(int position)
    {
        _rb.velocity = new Vector2(Velocity * position, _rb.velocity.y);
        _sr.flipX = position == Left;
        ChangeAnimation(ANIMATOR_RUN);
    }
    private void ChangeAnimation(int animation)
    {
        _animator.SetInteger(ANIMATOR_STATE, animation);
    }
    private void Disparar()
    {
        var x = this.transform.position.x;
        var y = this.transform.position.y;
        var bulletGo = Instantiate(BulletPrefab, new Vector2(x, y), Quaternion.identity) as GameObject;
        var controller = bulletGo.GetComponent<Bullet_Controller>();
        controller.SetCatController(this);


        if (_sr.flipX)
        {
            controller.Velocity = controller.Velocity * -1;
        }

    }
    public void IncrementarPuntaje(int cantidad)
    {
        puntaje += cantidad;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        var tag = other.gameObject.tag;
        if (tag == "Coin_1")
        {
            monedaR1 += 1;
            Destroy(other.gameObject);
        }
        if (tag == "Coin_2")
        {
            monedaR2 += 1;
            Destroy(other.gameObject);
        }
        if (tag == "Coin_3")
        {
            monedaR3 += 1;
            Destroy(other.gameObject);
        }
    }

}
