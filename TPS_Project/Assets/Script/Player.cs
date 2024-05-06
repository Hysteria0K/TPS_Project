using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float Player_Speed = 10.0f;
    private float Player_Zoom_Speed = 1.5f;
    private float rotationSpeed = 360f;

    private float gravity = -8.0f;

    public Vector3 direction;
    public Vector3 Player_Position;

    CharacterController characterController;

    public GameObject Camera;

    public Quaternion Cam_direction;

    public bool Zoom_Check = false;

    Animator animator;

    public int Player_Origin_Hp = 1000;
    public int Player_Hp;

    public GameObject Player_Hp_Bar;

    public int Heal_Pack;

    public GameObject UI_Status;

    public GameObject Heal_Particle;

    public int Position_Check = 0; // 0 = A,B 스폰  , 1 = C, D 스폰

    // Start is called before the first frame update
    private void Awake()
    {
        Player_Hp = Player_Origin_Hp;

        Player_Hp_Update();

        Heal_Pack = 5;
    }

    void Start()
    {
        characterController= GetComponent<CharacterController>();
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

        Player_Hp_Limit();

        if (Player_Hp <= 0)
        {
            // 죽음
        }

        Heal();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
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

            characterController.Move(new Vector3(direction.x, gravity / Player_Speed, direction.z) * Player_Speed * Time.deltaTime);
        }

        else
        {
            characterController.Move(new Vector3(direction.x, gravity / Player_Zoom_Speed, direction.z) * Player_Zoom_Speed * Time.deltaTime);
        }

        animator.SetFloat("Speed", characterController.velocity.magnitude);
    }

    public void Player_Hp_Update()
    {
        Player_Hp_Bar.GetComponent<Image>().fillAmount = (float)Player_Hp / Player_Origin_Hp;
    }

    private void Player_Hp_Limit()
    {
        if (Player_Hp > Player_Origin_Hp)
        {
            Player_Hp = Player_Origin_Hp;
        }
    }
    private void Heal()
    {
        if (Input.GetKeyDown(KeyCode.C) && Heal_Pack > 0 && Player_Hp < Player_Origin_Hp)
        {
            Heal_Pack -= 1;
            Player_Hp += Player_Origin_Hp / 2;
            Player_Hp_Update();
            UI_Status.GetComponent<UI_Status>().UI_Update();
            Instantiate(Heal_Particle, this.gameObject.transform.position, Quaternion.Euler(-90, 0, 0), this.gameObject.transform);
        }
    }
}

