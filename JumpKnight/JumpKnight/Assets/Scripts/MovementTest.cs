using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class MovementTest : MonoBehaviour
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
    
    private Quaternion locked;
    private Quaternion lockedRotation;
    private float time;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpSpeed = 10;
        speed = 10;
    }

   
    void Update()
    {
        bool grounded = Physics2D.Raycast(currentObject.position, Vector2.down, 0.55f, ground);

        //pivot.transform.rotation = Quaternion.AngleAxis(Mathf.Sin(Time.fixedTime) * 30, new Vector3(0, 0, 1));
        //jumpStrength = Mathf.Abs(Mathf.Sin(Time.fixedTime) * jumpSpeed);

        ArrowUpdate();

        if (grounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                pivot.transform.rotation = lockedRotation;
                jumpStrength = Mathf.Abs(Mathf.Sin(Time.fixedTime) * jumpSpeed);
                return;
            }




            if (Input.GetKeyUp(KeyCode.Space))
            {
                Vector2 d = Arrow.transform.position - pivot.transform.position;
                rb.AddForce(d * jumpStrength, ForceMode2D.Impulse);
                jumpStrength = 1;
            }

        }
        pivot.transform.rotation = lockedRotation;
        time += 1f * Time.deltaTime;
        if (Input.GetKey(KeyCode.F))
            time += SpeedArowFast * Time.deltaTime;




        lockedRotation = Quaternion.AngleAxis(Mathf.Sin(time) * ArrowRotation, new Vector3(0, 0, 1));
        
    }
    private void ArrowUpdate()
    {
        //Arrow.transform.position = this.transform.position + new Vector3(0, 5);
        Arrow.transform.localScale = new Vector2(0.5f, jumpStrength / 5);
    }
}
