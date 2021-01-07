using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Public value to store the player's health
    public int health = 5;
    //Field to sotre health text ui
    public Text healthText;
    //Field to store the value of the x axis
    private float horizontalMovement;
    //Field to store the rigidbody component
    private Rigidbody rb;
    //Public value to store the player's score
    private int score = 0;
    //Field to sotre score text ui
    public Text scoreText;
    //Public value to store the player's speed movement
    public float speed;
    //Field to store the value of the z axis
    private float verticalMovement;
    //Field to sotre the winlose image object
    public GameObject winLoseBG;
    //Field to store the winlose text ui
    public Text winLoseText;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (health == 0)
        {
            SetGameOverText();
            StartCoroutine(LoadScene(3));
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("menu");
    }

    /// <summary>
    /// It is called every fixed frame-rate frame
    /// </summary>
    private void FixedUpdate()
    {
        Movement();
    }

    /// <summary>
    /// Allows the player to move with arrow keys or w, a, s, d keys
    /// </summary>
    private void Movement()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * speed;
        verticalMovement = Input.GetAxis("Vertical") * speed;
        rb.velocity = new Vector3(horizontalMovement, 0f, verticalMovement);
    }

    /// <summary>
    /// Happens on the FixedUpdate function when two GameObjects collide
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            score++;
            other.gameObject.SetActive(false);
            SetScoreText();
        }

        if (other.CompareTag("Trap"))
        {
            health--;
            SetHealthText();
        }

        if (other.CompareTag("Goal"))
        {
            SetWinText();
            StartCoroutine(LoadScene(3));
        }
    }

    /// <summary>
    /// Displays the score value
    /// </summary>
    private void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    /// <summary>
    /// Displays the health value
    /// </summary>
    private void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }

    /// <summary>
    /// Displays the win text when player wins
    /// </summary>
    private void SetWinText()
    {
        winLoseText.text = "You Win!";
        winLoseText.color = Color.black;
        winLoseBG.GetComponent<Image>().color = Color.green;
        winLoseBG.SetActive(true);
    }

    /// <summary>
    /// Displays th game over text when the player lose
    /// </summary>
    private void SetGameOverText()
    {
        winLoseText.text = "Game Over!";
        winLoseText.color = Color.white;
        winLoseBG.GetComponent<Image>().color = Color.red;
        winLoseBG.SetActive(true);
    }

    /// <summary>
    /// Waits for 3 seconds before load the scene
    /// </summary>
    /// <param name="seconds"></param>
    /// <returns></returns>
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(0);
    }
}
