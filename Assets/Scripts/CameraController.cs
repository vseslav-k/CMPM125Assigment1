using UnityEngine;
using UnityEngine.InputSystem;
public class CameraController : MonoBehaviour
{
    public float followSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dy = (Mouse.current.position.y.value - Screen.height / 2) / 200 * followSpeed;
        if (Mathf.Abs(dy) > 0.05f)
        {
            transform.Rotate(-dy, 0, 0);        
        }

    }
}
