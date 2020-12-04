using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{

    [Range(1,10)]
    public float fuerzaSalto=1;
    [Range(1, 1000)]
    public float speed=10;
    float x;
    float y;
    Rigidbody2D rigidbody;
    Animator animator;
    private bool estaSiendoDespedido = false;
    public bool estaDeslizando = false;

    public FixedJoystick vJoystick;    
 
    //Referencia al sound  manager
    private PlayerSoundManager psm;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        psm = GetComponent<PlayerSoundManager>();
        if (GameObject.Find("Fixed Joystick")!=null)
        {
            vJoystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        }
       
    }
    private void Update()
    {
        if (vJoystick!=null && vJoystick.isActiveAndEnabled)
        {
            x = vJoystick.Horizontal;
            y = vJoystick.Vertical;
        }
        else
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");
        }
      
        if (Input.GetKeyDown(KeyCode.Space))
        {
                Saltar();      

        }
        if (Mathf.Abs(rigidbody.velocity.y) < 0.01f)
        {
            animator.SetBool("Jumping", false);
        }
           
    }

    private void FixedUpdate()
    {
        Desplazar();
    }

    /// <summary>
    /// Se invoca cuando se topa con los pinchos y estos le lanzan hacia atras
    /// </summary>
    public void IniciarDespido()
    {
        estaSiendoDespedido = true;
    }
    void Desplazar()
    {
        if (!estaSiendoDespedido && !estaDeslizando)
        {
            rigidbody.velocity = new Vector2(x * Time.deltaTime * speed, rigidbody.velocity.y);          
        }
       
        if (Mathf.Abs(rigidbody.velocity.x) > 0 && !estaDeslizando)
        {
            animator.SetBool("Running", true);
        } else
        {
            animator.SetBool("Running", false);
        }
    }

    public void Saltar()
    {
       
        if (Mathf.Abs(rigidbody.velocity.y) < 0.01f)
        {
            animator.SetBool("Jumping", true);
            rigidbody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            psm.PlayAudioJump();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        estaSiendoDespedido = false;  
    }           

}
