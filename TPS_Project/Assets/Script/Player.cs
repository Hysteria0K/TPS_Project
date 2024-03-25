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

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        characterController= GetComponent<CharacterController>();
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Ignore Raycast"));
        animator = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Player_Position = this.transform.position;

        if (Zoom_Check == true)
        {
            animator.SetBool("Aim", true);
        }
        else
        {
            animator.SetBool("Aim", false);
        }
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
                this.transform.rotation = Quaternion.Euler(0.0f, transform.eulerAngles.y, transform.eulerAngles.z);
            }

            characterController.Move(new Vector3(direction.x, 0.0f, direction.z) * Player_Speed * Time.deltaTime);
        }

        else
        {
            characterController.Move(new Vector3(direction.x, 0.0f, direction.z) * Player_Zoom_Speed * Time.deltaTime);
        }

        animator.SetFloat("Speed", characterController.velocity.magnitude);
    }
}
