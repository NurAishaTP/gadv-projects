using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public int bricks = 20;
    public float resetDelay = 1f;
    public Text livesText;
    public GameObject gameOver;
    public GameObject youWon;
    public GameObject bricksPrefab;
    public GameObject paddlePrefab;
    public GameObject deathParticle;
    public static GameManager instance = null;
    //Access the GameManager via the class and not the instance of the class.
    //There is no need to create a new class or instantiate of the class. 

    private GameObject clonePaddle; 


    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        // this is a good habit to have, when there is multiple levels or multiple layers to the game.
        Setup();
    }

    public void Setup()
    {
        //instantiate the paddle from the paddle Prefab, according to the GameObj Position with no rotation (Quaternion.identity). 
        clonePaddle = Instantiate(paddlePrefab, transform.position, Quaternion.identity) as GameObject;
        Instantiate(bricksPrefab, transform.position, Quaternion.identity);
    }

    void CheckGameOver()
    {
        if (bricks < 1)
        {
            youWon.SetActive(true);
            Time.timeScale = 0.25f;
            Invoke("Reset", resetDelay);
        }
        if (lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0.25f;
            Invoke("Reset", resetDelay);
        }
    }

    void Reset()
    {
        Time.timeScale = 1f;
        // This is the new SceneManager to load the single scene of the game, everytime there is a reset to the game, compare to the obselete ( Application.LoadLevel(Application.loadedLevel);).
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void LoseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives;
        Instantiate(deathParticle, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);
        Invoke("SetupPaddle", resetDelay);
        CheckGameOver();
    }

    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddlePrefab, transform.position, Quaternion.identity) as GameObject;
    }

    public void DestroyBrick()
    {
        bricks--;
        CheckGameOver();
    }
}
