using UnityEngine;
using DG.Tweening;
using UnityEditor.Experimental.GraphView;

public class PlayerMovement : MonoBehaviour
{
    public MeshRenderer meshRenderer;

    private Rigidbody rb;
    [SerializeField] private LayerMask layerMask;
    private bool isGrounded = false;
    public float jumpForce;

    private Vector2 control;
    public Vector3 controlForce;
    public Vector3 forwardForce;

    private bool IsRotating = false;
    private float timeTaken;
    private int direction;
    public float time = 1.5f;

    private Vector3 rotationAngle = new(0,90,0);
    private Vector3 baseAngle;

    void Start()
    {
        meshRenderer.material = GameManager.instance.activeMaterial;
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        // Movement
        transform.Translate(forwardForce * Time.deltaTime);
        control = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Jump"));
        transform.Translate(control.x * Time.deltaTime * controlForce);

        // Rotation
        baseAngle = transform.rotation.eulerAngles;
        if (Input.GetKeyDown(KeyCode.J) && !IsRotating)
        {
            IsRotating = true;
            direction = -1;
            timeTaken = 0;
            transform.DORotate(baseAngle + direction * rotationAngle, time);
        }
        if (Input.GetKeyDown(KeyCode.L) && !IsRotating)
        {
            IsRotating = true;
            direction = 1;
            timeTaken = 0;
            transform.DORotate(baseAngle + direction * rotationAngle, time);
        }

        if (IsRotating)
        {
            timeTaken += Time.deltaTime;
            if(timeTaken >= time)
            IsRotating = false;
        }

        // Jump
        isGrounded = Physics.CheckSphere(transform.position,1f,layerMask);
        if(Input.GetKeyDown(KeyCode.Space ) && isGrounded){
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
        }

        /*if (Input.GetKeyDown(KeyCode.Escape)){
            HUDManager.instance.LoadPauseMenu();
        }
        */

    }


}

