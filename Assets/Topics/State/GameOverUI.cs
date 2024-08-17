using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameEnderTrigger _gameEnder;
    [SerializeField] private GameObject _gameOverUI;

    private void Awake()
    {
        _gameEnder.GameOver += OnGameOver;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnGameOver()
    {
        _gameOverUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }
}