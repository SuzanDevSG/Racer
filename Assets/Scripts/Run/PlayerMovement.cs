using UnityEngine;
using DG.Tweening;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    private Rigidbody rb;

    [SerializeField] private LayerMask layerMask;
    public float jumpForce = 3f;

    private Vector2 control;
    [Range(10, 30)] public float controlForce = 10f;
    [Range(0, 30)] public float forwardForce = 15f;
    [SerializeField] private float currentSpeed;

    private bool IsRotating = false;
    private float timeTaken;
    private int direction;
    public float rotationDuration = 1.5f;

    private Vector3 rotationAngle = new(0, 90, 0);
    private Vector3 baseAngle;

    void Start()
    {
        currentSpeed = forwardForce;
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody>();
        meshRenderer.material = GameManager.instance.activeMaterial;
    }

    void Update()
    {
        // Movement
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        control = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"));
        transform.Translate(control.x * Time.deltaTime * Vector3.right * controlForce);

        // Rotation
        baseAngle = transform.rotation.eulerAngles;
        if (Input.GetKeyDown(KeyCode.Q) && !IsRotating)
        {
            IsRotating = true;
            direction = -1;
            timeTaken = 0;
            transform.DORotate(baseAngle + direction * rotationAngle, rotationDuration);
        }
        if (Input.GetKeyDown(KeyCode.E) && !IsRotating)
        {
            IsRotating = true;
            direction = 1;
            timeTaken = 0;
            transform.DORotate(baseAngle + direction * rotationAngle, rotationDuration);
        }

        if (IsRotating)
        {
            timeTaken += Time.deltaTime;
            if (timeTaken >= rotationDuration)
                IsRotating = false;
        }

        // Jump

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.CheckSphere(transform.position, 1.5f, layerMask))
            {
                PlayerJump(jumpForce);
                //rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HUDManager.Instance.LoadPauseMenu();
        }
    }

    public void PlayerJump(float jumpForce)
    {
        //rb.AddForce(jumpforce * Vector3.up, ForceMode.Impulse);
        //rb.velocity = new Vector3(rb.velocity.x, jumpforce, rb.velocity.z);
        StartCoroutine(JumpTween(jumpForce));
    }

    IEnumerator JumpTween(float jumpForce)
    {
        rb.useGravity = false;
        transform.DOMoveY(transform.position.y + jumpForce, 0.5f);
        yield return new WaitForSeconds(0.5f);
        rb.useGravity = true;
    }

    public void PlayerBooster(float additionalBoost, float boostDuration)
    {
        StartCoroutine(ResetBoost(additionalBoost, boostDuration));
    }

    private IEnumerator ResetBoost(float additionalBoost, float duration)
    {
        currentSpeed += additionalBoost;
        yield return new WaitForSeconds(duration);

        while (currentSpeed >= forwardForce)
        {
            currentSpeed -= (additionalBoost / 2) * Time.deltaTime;
            yield return null;
        }
    }

}

