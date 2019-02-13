using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof (Animator))]
public class PlayerController : MonoBehaviour {
    public Text timer;
    public Text gameOver;
    public float timeLeft = 120.0f;
    public Transform rightGunBone;
	public Transform leftGunBone;
	public Arsenal[] arsenal;
    public float turningSpeed;
    Animator animator;
    public int clickableLayerMask = 1 << 9; //Layer 9 is our physics layer for Clickable objects.

    private void Start()
    {
        animator = GetComponent<Animator>();
        SetTimerText();
    }

    void Awake() {
		animator = GetComponent<Animator> ();
		if (arsenal.Length > 0)
			SetArsenal (arsenal[0].name);
		}

	public void SetArsenal(string name) {
		foreach (Arsenal hand in arsenal) {
			if (hand.name == name) {
				if (rightGunBone.childCount > 0)
					Destroy(rightGunBone.GetChild(0).gameObject);
				if (leftGunBone.childCount > 0)
					Destroy(leftGunBone.GetChild(0).gameObject);
				if (hand.rightGun != null) {
					GameObject newRightGun = (GameObject) Instantiate(hand.rightGun);
					newRightGun.transform.parent = rightGunBone;
					newRightGun.transform.localPosition = Vector3.zero;
					newRightGun.transform.localRotation = Quaternion.Euler(90, 0, 0);
					}
				if (hand.leftGun != null) {
					GameObject newLeftGun = (GameObject) Instantiate(hand.leftGun);
					newLeftGun.transform.parent = leftGunBone;
					newLeftGun.transform.localPosition = Vector3.zero;
					newLeftGun.transform.localRotation = Quaternion.Euler(90, 0, 0);
				}
				animator.runtimeAnimatorController = hand.controller;
				return;
				}
		}
	}

    public void Update()
    {
        animator.SetFloat("Speed", Input.GetAxis("Vertical"));
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime);
        float yRot = transform.rotation.eulerAngles.y;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("Run", true);
        } else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("Run", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Jump", true);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("Squat", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("Squat", false);
        }
        
        if (timeLeft >= 0)
        {
            timeLeft -= Time.deltaTime;
        } else
        {
            gameOver.gameObject.SetActive(true);
        }
        SetTimerText();
        handleClicks();
    }

    void handleClicks()
    {
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out Hit, 10.0f, clickableLayerMask))
            {
                ClickableObject clickableObject = Hit.collider.GetComponent<ClickableObject>();
                if (clickableObject)
                {
                    clickableObject.Invoke("invokeOnClick", 0f);
                } else
                {
                    print("Error: object in Clickable layer does not have ClickableObject script");
                }
            }
        }
    }

    void SetTimerText()
    {
        timer.text = "Time remaining: " + Mathf.Round(timeLeft * 10f) / 10f;
    }


    [System.Serializable]
	public struct Arsenal {
		public string name;
		public GameObject rightGun;
		public GameObject leftGun;
		public RuntimeAnimatorController controller;
	}
}
