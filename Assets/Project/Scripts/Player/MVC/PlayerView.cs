using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform cameraSpawnPoint;
    public Transform CameraSpawnPoint { get { return cameraSpawnPoint; } }
    public Rigidbody RigidBody { get { return rb; } }
    private PlayerController playerController;
    public void Init(PlayerController playerController) => this.playerController = playerController;

    private void Start() => playerController.SetCamera();

    private void Update()
    {
        playerController.Move();
        if (Input.GetKeyDown(KeyCode.LeftArrow)) playerController?.MoveLeft();
        else if (Input.GetKeyDown(KeyCode.RightArrow)) playerController?.MoveRight();
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) playerController.Jump();
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerController.OnCollisionEnter(collision);
    }
}