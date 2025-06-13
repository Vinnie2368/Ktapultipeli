using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class KATAPULTT : MonoBehaviour

{
    public Rigidbody characterRb;

    public BUNNYEXPLODE bunnyExploder;
    public Transform launchPosition;

    public Animator armAnimator;

    public Transform turret;

    public float launchForce = 15f;
    public float verticalLift = 0.5f;
    public float rotationSpeed;
    //Rip Vector:(
    public int bunnyCount = 5;
    public Slider forceSlider;
    public TextMeshProUGUI forceText;
    public Slider liftSlider;
    public TextMeshProUGUI liftText;

    public TextMeshProUGUI bunnyCountText;
    private Quaternion initialBunnyRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialBunnyRotation = characterRb.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (Input.GetKeyDown(KeyCode.Space))

            {
                Launch();
            }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetCatapult();
        }
        HandleRotation();
    }

    void UpdateUI()
    {
        launchForce = forceSlider.value;
        verticalLift = liftSlider.value;
        forceText.text = "Force:" + Mathf.RoundToInt(launchForce);
        liftText.text = "Lift:" + verticalLift.ToString("n2");
        bunnyCountText.text = "Bunnies left:" + bunnyCount;
    }
    void Launch()
    {
        characterRb.isKinematic = false;
        characterRb.transform.parent = null;
        Vector3 launchDirection = turret.forward + Vector3.up * verticalLift;
        characterRb.AddForce(launchDirection.normalized * launchForce, ForceMode.Impulse);
        armAnimator.SetTrigger("Launch");
    }


    void ResetCatapult()
    {
        if (bunnyCount == 0) return;
        bunnyCount -= 1;
        characterRb.isKinematic = true;
        characterRb.transform.parent = launchPosition;
        characterRb.transform.position = launchPosition.position;
        characterRb.transform.rotation = initialBunnyRotation;

        bunnyExploder.hasExploded = false;
        bunnyExploder.UpdateButton();
    }

    void HandleRotation()
    {
        float rotation = Input.GetAxis("Horizontal");
        turret.Rotate(Vector3.up, rotation * rotationSpeed * Time.deltaTime);
        if (characterRb.isKinematic)
        {
            characterRb.transform.position = launchPosition.position;
            characterRb.transform.rotation = launchPosition.rotation * initialBunnyRotation;
        }

    }


}


