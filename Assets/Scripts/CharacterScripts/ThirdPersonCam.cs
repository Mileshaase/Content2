using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;
    public float rotationSpeed;
    public Transform combatLookAt;

    [Header("Keybinds")]
    public KeyCode combatCameraMode = KeyCode.Mouse1;

    public GameObject thirdPersonCam;
    public GameObject combatCam;

    public Player playerScript;

    private void Update()
    {
        orientation = GameObject.Find("Orientation").transform;
        player = GameObject.Find("Player").transform;
        playerObj = player.GetChild(0).transform;
        rb = GameObject.Find("Player").GetComponent<Rigidbody>();
        combatLookAt = orientation.GetChild(0).transform;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // rotate orientation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        // roate player object
        if (!Input.GetKey(combatCameraMode))
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

            if (inputDir != Vector3.zero)
                playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }
        else
        {
            Vector3 dirToCombatLookAt = combatLookAt.position - new Vector3(transform.position.x, combatLookAt.position.y, transform.position.z);
            orientation.forward = dirToCombatLookAt.normalized;

            playerObj.forward = dirToCombatLookAt.normalized;
        }
    }
}
