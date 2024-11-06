using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float MaxSpeed;
    private float Speed;

    private Collider[] hitColliders;
    private RaycastHit Hit;
    
    public float SightRange;
    public float DetectionRange;

    public Rigidbody rb;
    public GameObject Target;

    private bool seePlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Speed = MaxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //detect any players in range
        
        if (!seePlayer)
        {
            hitColliders = Physics.OverlapSphere(transform.position, DetectionRange);
            foreach (var HitCollider in hitColliders)
            {
                if(HitCollider.tag == "Player")
                {
                    Target = HitCollider.gameObject;
                    seePlayer = true;
                }
            }
        }
        else
        {
            if(Physics.Raycast(transform.position, (Target.transform.position - transform.position), out Hit, SightRange))
            {
                if(Hit.collider.tag != "Player")
                {
                    seePlayer = false;
                }
                else
                {
                    // calculate the direction

                    var Heading = Target.transform.position - transform.position;
                    var Distance = Heading.magnitude;
                    var Direction = Heading / Distance;

                    Vector3 Move = new Vector3(Direction.x * Speed, 0, Direction.z * Speed);
                    rb.linearVelocity = Move;
                    transform.forward = Move;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            Debug.Log("GAME OVER");
            // Jumpscare
            // Game over
        }
    }

}
