using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;

    private GameController gamecontroller;
    private float rotationSpeed;
    private float speed;
    private Rigidbody rb;
    private GameObject mAsteroid;
    private GameObject player;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        //get reference to istance of game controller object and it's gamecontroller script component
        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        if (controller != null) gamecontroller = controller.GetComponent<GameController>();
        else Debug.Log("Can't find game controller");

        //set asteroid moving speed higher with wave level
        speed = 5.0f;

        //shoot asteroid towards player
        player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(player.transform);
        rb.velocity = transform.forward.normalized * speed;


        //randomize asteroid's rotation speed and angle
        rotationSpeed = Random.Range(1.0f, 6.0f);
        rb.angularVelocity = Random.insideUnitSphere * rotationSpeed;



    }

    private void OnTriggerEnter(Collider other)
    {
         if (other.tag == "LaserBolt")
         {
             DestroyObject(other.gameObject);
             DestroyObject(gameObject);
             Instantiate(explosion, transform.position, transform.rotation);
             gamecontroller.UpdateExperience(1);
         }

        if (other.tag == "Player")
         {
             Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
             DestroyObject(gameObject);
             DestroyObject(other.gameObject);
             gamecontroller.GameOver();
         }

    }


}

