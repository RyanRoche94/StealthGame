using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public event System.Action OnReachedEndOfLevel;

    

    public float moveSpeed = 7;
    public float smoothMoveTime = .1f;
    public float turnSpeed = 8;
    public int itemNum;
    public int PointScore = 1;
    public int TotalScore = 0;
    public int newTotalScore = 0;
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI Winscoretext;
    public GameObject WinMenu;

    float angle;
    float smoothInputMagnitude;
    float smoothMoveVelocity;
    Vector3 velocity;

    new Rigidbody rigidbody;
    bool disabled;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Guard.OnGuardHasSpottedPlayer += Disable;
       
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 inputDirection = Vector3.zero;
        
        if (!disabled)
        {
            inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
            
        }
     



        float inputMagnitude = inputDirection.magnitude;
        smoothInputMagnitude = Mathf.SmoothDamp(smoothInputMagnitude, inputMagnitude, ref smoothMoveVelocity, smoothMoveTime);

        float targetAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg;
        angle = Mathf.LerpAngle(angle, targetAngle, Time.deltaTime * turnSpeed * inputMagnitude);

        velocity = transform.forward * moveSpeed * smoothInputMagnitude;
        
    }



    void OnTriggerEnter(Collider hitCollider)
    {
        if(hitCollider.tag == "Finish")
        {
            Won();
            Disable();
            if (OnReachedEndOfLevel != null)
            {

               
                OnReachedEndOfLevel();
                
            }
        }

        if(hitCollider.tag == "Item")
        {
            Destroy(hitCollider.gameObject);
            itemNum+=1;
            newTotalScore = TotalScore + PointScore;
            TotalScore = newTotalScore;
            scoretext.text = ("Score = " + newTotalScore).ToString();
        }
    }

    void Disable()
    {
        disabled = true;
    }

    void FixedUpdate()
    {
        rigidbody.MoveRotation(Quaternion.Euler(Vector3.up * angle));
        rigidbody.MovePosition(rigidbody.position + velocity * Time.deltaTime);
    }

    void OnDestroy()
    {
        Guard.OnGuardHasSpottedPlayer -= Disable;
    }

    public void Won()
    {
        WinMenu.SetActive(true);
        Winscoretext.text = ("Score = " + newTotalScore).ToString();

    }
}
