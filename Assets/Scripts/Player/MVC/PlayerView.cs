using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform cameraSpawnPoint;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private int colliderInitialHeight;
    public Transform CameraSpawnPoint { get { return cameraSpawnPoint; } }
    public Rigidbody RigidBody { get { return rb; } }
    public Animator PlayerAnimator { get { return playerAnimator; } }
    private PlayerController playerController;
    public void Init(PlayerController playerController) => this.playerController = playerController;

    private void Start() 
    { 
        playerController.SetCamera();
        SetColliderHeight(colliderInitialHeight);
    }

    private void Update()
    {
        if (!playerController.IsPlayerDead)
        {
            playerController.UpdateState();
            if (Input.GetKeyDown(KeyCode.LeftArrow)) playerController?.MoveLeft();
            else if (Input.GetKeyDown(KeyCode.RightArrow)) playerController?.MoveRight();
            else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) playerController.ChangeState(States.JUMPING);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerController.OnCollisionEnter(collision);
    }

    public void SetColliderHeight(int height) => gameObject.GetComponent<CapsuleCollider>().height = height;
}