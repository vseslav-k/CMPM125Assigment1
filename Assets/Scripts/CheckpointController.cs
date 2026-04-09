using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public CheckpointController next;
    public MeshRenderer left;
    public MeshRenderer right;
    public bool isStart;

    void Start()
    {
        if (isStart) {
            left.materials[0].color = Color.red;
            right.materials[0].color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        CarController vehicle = other.gameObject.GetComponent<CarController>();
        if (vehicle != null)
        {

            if (vehicle.target == this) {
                next.left.materials[0].color = Color.red;
                next.right.materials[0].color = Color.red;
                left.materials[0].color = Color.white;
                right.materials[0].color = Color.white;

                vehicle.target = next;
                if (isStart) {
                    vehicle.lap++;
                }
            }
           
        }
    }
}
