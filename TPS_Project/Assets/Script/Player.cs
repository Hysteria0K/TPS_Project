using UnityEngine;

public class Player : MonoBehaviour
{
    public float Player_Speed = 10.0f;
    public float Player_Zoom_Speed = 1.5f;
    public float rotationSpeed = 360f;

    public Vector3 direction;
    public Vector3 Player_Position;

    CharacterController characterController;

    public GameObject Camera;

    public Quaternion Cam_direction;

    public bool Zoom_Check = false;
    // Start is called before the first frame update
    void Start()
    {
        characterController= GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        Player_Position = this.transform.position;
    }

    void FixedUpdate()
    {
        Cam_direction = Camera.GetComponent<Transform>().rotation;

        direction = Cam_direction * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (Zoom_Check == false)
        {
            if (direction.sqrMagnitude > 0.01f)
            {
                Vector3 forward = Vector3.Slerp(transform.forward, direction,
                rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction));

                transform.LookAt(transform.position + forward);
            }

            characterController.Move(direction * Player_Speed * Time.deltaTime);
        }

        else
        {
            if(Input.GetKey(KeyCode.W))
            {
                this.transform.Translate(Vector3.forward * Player_Zoom_Speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A))
            {
                this.transform.Translate(Vector3.left * Player_Zoom_Speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                this.transform.Translate(Vector3.right * Player_Zoom_Speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S))
            {
                this.transform.Translate(Vector3.back * Player_Zoom_Speed * Time.deltaTime);
            }
        }
    }
}
