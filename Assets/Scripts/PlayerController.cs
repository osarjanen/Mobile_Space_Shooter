using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public GameObject laserBolt;
    public VirtualJoystick virtualJoystic;
    public FireButton1 fireButton1; //Basic laser fire button

    private Rigidbody rb;
    private float xMin, xMax, zMin, zMax; //boundaries of game area
    private float laserFireRate; //how fast can player fire laser shots
    private float laserReadyToFire; //how much time till next laser fire




    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerSpeed = 6.0f;
        xMin = -24.0f;
        xMax = 24.0f;
        zMin = -24.0f;
        zMax = 24.0f;
        laserFireRate = 0.5f;
        laserReadyToFire = 0.0f;
    }

    private void FixedUpdate()
    {
        //move player
        Vector2 touchPosition = virtualJoystic.GetPosition();
        float moveHorizontal = touchPosition.x;
        float moveVertical = touchPosition.y;
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = (movement.magnitude > 1) ? movement.normalized * playerSpeed : movement * playerSpeed;

        //rotate player to faca movement direction
        if (moveHorizontal != 0.0f || moveVertical != 0.0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);
        }

        
        //Keep player in play area
        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, xMin, xMax),
            0.0f,          
            Mathf.Clamp(rb.position.z, zMin, zMax)
            );
        
    }

    private void Update()
    {
        //handle weapon firing
        
        if (fireButton1.IsButtonPressed() && Time.time > laserReadyToFire)
        {
            Instantiate(laserBolt, transform.position, transform.rotation);
            AudioSource singleLaser = GetComponent<AudioSource>();
            singleLaser.Play();
            laserReadyToFire = Time.time + laserFireRate;
        }

        //make camera follow player
        Camera.main.transform.position = new Vector3(transform.position.x, 10.0f, transform.position.z);
    }

}
