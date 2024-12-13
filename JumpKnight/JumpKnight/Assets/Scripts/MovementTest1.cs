using System.Collections;
using System.Collections.Generic;

using Unity.Collections;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;

public class MovementTest1 : MonoBehaviour
{

    public Rigidbody2D rb;
    
    
    public float speed;
    private float jumpStrength = 0.5f;
    public float jumpSpeed;
    public GameObject Arrow;
    
    public LayerMask ground;
    public Transform currentObject;
    public GameObject pivot;

    public float ArrowRotation;
    public float SpeedRotationFast;
    public float SpeedRotation;


    private bool jumped;
    private Quaternion locked;
    private Quaternion lockedRotation;
    private float Rotationtime;
    private float Jumptime;
    private Vector2 direction;
    private float timeInAir;
    private float jumpstreghtlock;

 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpSpeed = 10;
        speed = 10;
    }

   
    void Update()
    {

        
        Vector2 vectemp1 = new Vector2(currentObject.position.x + (currentObject.transform.localScale.x / 2), currentObject.position.y);
        Vector2 vectemp2 = new Vector2(currentObject.position.x - (currentObject.transform.localScale.x / 2), currentObject.position.y);
        bool groundedleft = Physics2D.Raycast(vectemp1, Vector2.down, 0.6f, ground);
        bool groundedright = Physics2D.Raycast(vectemp2, Vector2.down, 0.6f, ground);

        ArrowUpdate();

        if (groundedleft|| groundedright)
        {
            timeInAir = 0;
            if (Input.GetKey(KeyCode.Space))
            {
                Jumptime += 1 * Time.deltaTime;
                pivot.transform.rotation = lockedRotation;
                jumpStrength = Mathf.Abs(Mathf.Sin(Jumptime) * jumpSpeed);
                return;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                Vector2 direction = Arrow.transform.position - pivot.transform.position;
              
                rb.AddForce(direction * jumpStrength, ForceMode2D.Impulse);
                jumpstreghtlock = jumpStrength;
                jumpStrength = 1;
                Jumptime = 0;
            }
            

        }
        pivot.transform.rotation = lockedRotation;
        Rotationtime += SpeedRotation * Time.deltaTime;

        if (Input.GetKey(KeyCode.F))
        {
            Rotationtime += SpeedRotationFast * Time.deltaTime;
        }

        lockedRotation = Quaternion.AngleAxis(Mathf.Sin(Rotationtime) * ArrowRotation, new Vector3(0, 0, 1));
        timeInAir += 1 * Time.deltaTime;
        //Debug.Log(timeInAir);
    }
    
    private void ArrowUpdate()
    {
        Arrow.transform.localScale = new Vector2(0.5f, jumpStrength / 5);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

       if(timeInAir > 0.1)
        {
            Debug.Log(rb.velocity);
            rb.AddForce(((rb.velocity*-1) * jumpstreghtlock) * 0.2f, ForceMode2D.Impulse);
            jumpstreghtlock = 0;
        }

    }
}
