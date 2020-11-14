using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Camera camara;
    public float velocidadHorizontal;
    public float velocidadVertical;

    public static Camara access;
    public float velocidad;
    private float h;
    private float v;
    private Animator _animator;
    public float vel;
    public bool shiP;
    public bool jump;

    [Header("Movement Status")]
    public bool down;
    public bool up, right, left;
    public float horizontal_speed, vertical_speed;


    private void Awake()
    {
        //toma el componente animador del los hijos que tiene attached
        _animator = GetComponentInChildren<Animator>();
        
    }

    public void Start()
    {
        velocidad = 0.8f;
        vel = 0f;
        shiP = false;
        jump = false;
        access = this;


        down = false;
        up = false;
        right= false;
        left = false;
        horizontal_speed = 10f;
        vertical_speed = 10f;
    }


    // Update is called once per frame
    public void Update()
    {
        _animator.SetFloat("Speed", vel);
        _animator.SetBool("ShiftP", shiP);
        _animator.SetBool("Jump", jump);

        //Con los Inputs se toma la direccion del mouse dependiendo de su orientacion
        //h = velocidadHorizontal * Input.GetAxis("Mouse X");
        v = velocidadVertical * Input.GetAxis("Mouse Y");

        transform.Rotate(0, h, 0);
        camara.transform.Rotate(-v, 0, 0);

        if (up)
        {
            Moverse(new Vector3(0, 0, velocidad));
            Animar();
        }
        else if (down)
        {
            Moverse(new Vector3(0, 0, -velocidad));
            Animar();
        }
        else if (left)
        {
            //Moverse(new Vector3(-velocidad, 0, 0));
            //Animar();

            transform.Rotate(0, -horizontal_speed, 0);

        }
        else if (right)
        {
            //Moverse(new Vector3(velocidad, 0, 0));
            //Animar();
            transform.Rotate(0, horizontal_speed, 0);
        }
        else
        {
            //Sino toca ninguna animación se reinicia a los valores iniciales
            vel = 0;
            shiP = false;
            velocidad = 0.8f;
            jump = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //jump = true;
            _animator.SetTrigger("JumpUP");
            transform.Translate(new Vector3(0, 3f, 0));
        }
    }

    public void Animar()
    {
        //Cambia el parametro
        vel = 1;
        //Cambia el animator a speed
        _animator.SetFloat("Speed", vel);

        //Cambia el estado para moverse mejor
        if (Input.GetKey("left shift"))
        // if (Input.GetButton("Correr"))
        {
            // Debug.Log("entre");
            shiP = true;
            _animator.SetBool("ShiftP", shiP);
            velocidad = 0.2f;
        }
        else
        {
            shiP = false;
            velocidad = 0.8f;
        }
    }


    public void Moverse(Vector3 vector)
    {
        transform.Translate(vector);
    }
}
