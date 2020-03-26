using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{

    public float lerpTime;
    public float playerSpeed;
    public float playerJumpHeight;
    private float playerDirection;

    public Text playerText;
    public string playerName;
    public Camera playerCamera;


    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        playerText = gameObject.AddComponent<Text>();
        playerText.text = playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        playerDirection = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().AddForce(Vector2.right*playerDirection*playerSpeed);

        if (Input.GetKeyDown("space"))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpHeight);
        }

        playerCamera.transform.position =
            new Vector3(
                Mathf.Lerp
                (playerCamera.transform.position.x, transform.position.x, lerpTime),
                Mathf.Lerp
                (playerCamera.transform.position.y, transform.position.y, lerpTime), -10);
    }

    private void LateUpdate()
    {

        playerText.rectTransform.position = 
            new Vector2(transform.position.x, transform.position.y);

        


    }
}
