using System;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// GameManager - Controls the game
/// </summary>
public class GameManager : MonoBehaviour
{
    int score = 0;
    [SerializeField] public GameObject gameOver;
    public bool isGameOver = false;

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
        score = 0;
        Time.timeScale = 0;
        GameOver();
    }
}
