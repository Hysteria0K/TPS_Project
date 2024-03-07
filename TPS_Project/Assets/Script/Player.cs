using UnityEngine;

public class Player : MonoBehaviour
{
    public float Player_Speed = 100.0f;
    public float rotationSpeed = 360f;

    public Vector3 direction;
    public Vector3 Player_Position;

    CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController= GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (direction.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp(transform.forward, direction,
            rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction));
            transform.LookAt(transform.position + forward);
        }

        characterController.Move(direction * Player_Speed * Time.deltaTime);
        Player_Position = this.transform.position;

    }
}
