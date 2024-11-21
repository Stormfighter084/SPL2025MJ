using System.Threading;
using System.Timers;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Variables

    public Rigidbody2D rb;
    public float xAxisInput;
    //public float yAxisInput;
    public float speed;
    private float jumpStrength = 0;
    public float jumpSpeed;
    public GameObject Arrow;
    private int temp = 0;
    public LayerMask ground;
    public Transform currentObject;
    public GameObject pivot;
    private Quaternion locked;
    


    private Quaternion lockedRotation;
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        jumpSpeed = 10;
        speed = 10;
        
    }

    private void Update()
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
                rb.AddForce(d* jumpStrength, ForceMode2D.Impulse);
                jumpStrength = 1;
            }

        }
        pivot.transform.rotation = lockedRotation;
        lockedRotation = Quaternion.AngleAxis(Mathf.Sin(Time.fixedTime) * 30, new Vector3(0, 0, 1));


    }

    private void ArrowUpdate()
    {
        //Arrow.transform.position = this.transform.position + new Vector3(0, 5);
        Arrow.transform.localScale = new Vector2(0.5f, jumpStrength / 5);
    }
}
