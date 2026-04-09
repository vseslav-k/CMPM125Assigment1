using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class CarController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Vector2 desired_acceleration;

    [SerializeField]
    private float impulse;

    [SerializeField]
    private float turnrate;

    
    public CheckpointController target;

    public float starttime;
    public TextMeshProUGUI timelbl;
    public int lap;


    void OnMove(InputValue action)
    {
        Vector2 movement = action.Get<Vector2>();
        desired_acceleration = movement;
        
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        lap = 0;
        impulse = 15f;
        turnrate = 1f;

     

        starttime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.AddRelativeForce(Vector3.forward * desired_acceleration.y * impulse * Time.deltaTime*500);
        rigidBody.AddRelativeForce(Vector3.right * desired_acceleration.x * impulse * Time.deltaTime*500);

        float dx = (Mouse.current.position.x.value - Screen.width / 2) / 200 * turnrate;
        if (Mathf.Abs(dx) > 0.01f)
        {
            transform.Rotate(0, dx, 0);
        }

        timelbl.text = string.Format("Current time: {0:F2} seconds \t\t Lap: {1}", (Time.time - starttime), lap);
    }
}
