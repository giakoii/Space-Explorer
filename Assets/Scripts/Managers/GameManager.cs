using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
/// <summary>
/// GameManager - Controls the game
/// </summary>
public class GameManager : MonoBehaviour
{
    public static int score;
    public static int highestScore;
    public static int playerScore;
    [SerializeField] public GameObject gameOver;
    [SerializeField] public TextMeshProUGUI scoreText;
    public bool isGameOver = false;
    public int flag = 0;

    public static GameManager instance;
    public float minValue = -6f;
    public float maxValue = 7f;
    public float babyTreeDestroyTime = 7f;
    
    [Header("Explosion Effect")]
    public GameObject explosionEffect;
    
    [Header("Flash Effect")]
    public GameObject flashEffect;
    
    [Header("Baby Tree")]
    public GameObject babyTreePrefab;
    
    [Header("After Burner")]
    public GameObject afterBurner;
    // [Header("After Burner")]
    // public GameObject afterBurner;

    private void Start()
    {
        InvokeRepeating("InstantiateBabyTree", 1f, 5f);
        instance = this;
        UpdateScore(); 
    }

    void InstantiateBabyTree()
    {
        Vector3 babyTreePost = new Vector3(Random.Range(minValue, maxValue), 6f);
        GameObject babyTree = Instantiate(babyTreePrefab, babyTreePost, Quaternion.Euler(0f, 0f, 0f));
        Destroy(babyTree, babyTreeDestroyTime);
    }
    
    public void InstatiateExplosion(GameObject gameObject, Transform transform)
    {
        Instantiate(GameManager.instance.explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject, 2f); 
    }
    
    // public void InstatiateAfterBurner(GameObject gameObject ,Transform transform)
    // {
    //     Instantiate(GameManager.instance.afterBurner, transform.position, transform.rotation);
    //     Destroy(gameObject, 2f);
    // }

    public void GameOver()
    {
        isGameOver = true;
        playerScore = score;
        score = 0;
        Time.timeScale = 1;
      // GameOver();
        SceneManager.LoadScene("GameOver");

        GameOverManager gameOverManager = FindObjectOfType<GameOverManager>();
        if (gameOverManager != null)
        {
            gameOverManager.UpdateScore();
        }
    }
    public void AddScore(int points)
    {
        score += points;
        highestScore = Math.Max(highestScore, score);
        UpdateScore();
    }
    public void UpdateScore()
    {
        scoreText.text = score.ToString();
        if (score >= 10 && flag == 0)
        {
            flag = 1;
            isGameOver = true;

            SceneManager.LoadScene("Gamplay2");
        }
    }


}
