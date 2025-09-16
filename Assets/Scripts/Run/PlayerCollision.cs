using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private HUDManager hudManager;
    [SerializeField] private float additionalBoost = 2f;
    [SerializeField] private float jumpBoosterForce = 5f;
    [SerializeField] private float BoosterDuration = 2f;

    private bool IsGameOver = false;
    private bool IsLevelCompleted = false;

    private int roundNumber = 0;

    void Start()
    {
        hudManager = HUDManager.Instance;
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if (transform.position.y < -5)
        {
            IsGameOver = true;
            hudManager.InGameTriggeredPanel[0].SetActive(true);
            playerMovement.enabled = false;
        }

        if (IsGameOver)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                hudManager.Restart();
            }
        }
        if (IsLevelCompleted)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hudManager.LoadNextLevelScene();
            }
        }
    }
    private void OnTriggerEnter(Collider Other)
    {

        if (Other.CompareTag("Obstackle"))
        {
            IsGameOver = true;
            hudManager.InGameTriggeredPanel[0].SetActive(true);
            playerMovement.enabled = false;
        }

        if (Other.CompareTag("Booster"))
        {
            playerMovement.PlayerBooster(additionalBoost, BoosterDuration);
        }

        if (Other.CompareTag("Jumper"))
        {
            playerMovement.PlayerJump(jumpBoosterForce);
        }

        if (Other.CompareTag("CheckPoint"))
        {
            ++roundNumber;
            Debug.Log("Round" + roundNumber + "Completed");
            if (roundNumber >= 2)
            {
                hudManager.InGameTriggeredPanel[1].SetActive(true);
                playerMovement.enabled = false;
                IsLevelCompleted = true;
            }
        }
    }
}
