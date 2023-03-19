using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 nextDirection { get; set; }
    public bool isJumping { get; set; }
    public bool isShooting { get; set; }
    public bool isGrounded {get;private set;}
    public bool isButtonChange{get;set;}
    public int fuel{get; private set;}
    private float fuelDuration = 3.0f;
    private float timestep = 0.0f;
    public float movementSpeed  =5.0f;
    public static PlayerController Instance;
    [SerializeField]private JumpnRunMovement jumpnRunMov;
    [SerializeField]private ShottemUpMovement shootUpMov;
    [SerializeField]private ParticleSystem particles;
    [SerializeField]private SpriteRenderer PlayerObject;
    private enum MoveState
    {
        JumpnRun,
        ShootEmUp
    }
    private MoveState moveState;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {   fuel = 3;
        ChangeState(MoveState.JumpnRun);
        // jumpnRunMov = gameObject.GetComponent<JumpnRunMovement>();
        // shootUpMov = gameObject.GetComponent<ShottemUpMovement>();
    }
    private void ChangeState(MoveState state)
    {
        moveState = state;
        particles.Play();
        if (moveState == MoveState.JumpnRun)
        {
            shootUpMov.enabled = false;
            jumpnRunMov.enabled = true;
            PlayerObject.color = Color.white;
        }else{
            jumpnRunMov.enabled = false;
            shootUpMov.enabled = true;
            PlayerObject.color = Color.gray;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Respawn"))
        {
            ChangeState(MoveState.ShootEmUp);
        }
        if(other.CompareTag("Obstacle") && moveState == MoveState.ShootEmUp)
        {
            ChangeState(MoveState.JumpnRun);
        }
        if(other.CompareTag("Ground")&& moveState == MoveState.JumpnRun)
        {
            isGrounded = true;
        }else{
            isGrounded = false;
        }
    }
    private void FixedUpdate() {
        if(isButtonChange)
        {
            isButtonChange = false;
            if (moveState == MoveState.JumpnRun)
            {
              ChangeState(MoveState.ShootEmUp);
            }else{
               ChangeState(MoveState.JumpnRun);
            }
        }
        if(moveState == MoveState.ShootEmUp)
        {
            timestep+= Time.deltaTime;
            if(timestep >= fuelDuration)
            {
                fuel --;
                if(fuel <= 0)
                {
                    ChangeState(MoveState.JumpnRun);
                }
                timestep = 0.0f;
            }
        }
    }
}
