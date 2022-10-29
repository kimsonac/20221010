using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public event Action<bool> OnTimerState;
    public event Action<float> OnPlayerBoost;
    public event Action<bool> OnPlayerStop;

    [SerializeField] private GameObject player;
    [SerializeField] private Transform startPosition;
    private GameObject playerStern_VFX;
    private GameObject playerRespawn_VFX;

    [SerializeField] private GameObject obstacle_1;
    [SerializeField] private GameObject obstacle_2;
    [SerializeField] private GameObject item_1;
    [SerializeField] private GameObject item_2;

    [SerializeField] private GameObject goal;

    [SerializeField] private int maxTime;
    [SerializeField] private GameObject gameOver_UI;
    [SerializeField] private GameObject gameClear_UI;
    [SerializeField] private GameObject press_UI;

    private GameObject goalStar_VFX;
    private GameObject goal_VFX;

    private Quaternion startRotation = new Quaternion(0, 0, 0, 0);
    private float boost = 2;
    private bool start = true;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (start)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                press_UI.SetActive(false);
                ChangTimerState(true);
                OnPlayerStop(false);
                start = false;
            }
        }
    }
    private void Start()
    {
        playerStern_VFX = player.transform.GetChild(2).gameObject;
        playerRespawn_VFX = player.transform.GetChild(3).gameObject;
        goal_VFX = goal.transform.GetChild(0).gameObject;
        goalStar_VFX = goal.transform.GetChild(1).gameObject;
    }
    public void RespawnPlayer()
    {
        OnPlayerStop(true);
        playerStern_VFX.SetActive(true);
        StartCoroutine(_RespawnPlayer());
    }

    public int GetTimerMaxtime()
    {
        return maxTime;
    }
    private IEnumerator _RespawnPlayer()
    {
        yield return new WaitForSeconds(1f);
        playerStern_VFX.SetActive(false);
        player.transform.position = startPosition.position;
        player.transform.rotation = startRotation;
        playerRespawn_VFX.SetActive(true);
        OnPlayerStop(false);
        yield return new WaitForSeconds(1f);
        playerRespawn_VFX.SetActive(false);
    }

    public void PlayerBoost()
    {
        OnPlayerBoost(boost);
    }

    public void SetItem(int order)
    {
        switch (order)
        {
            case 1: item_1.SetActive(true);
                break;

            case 2: item_2.SetActive(true);
                break;

            default: break;
        }
    }

    public void ChangTimerState(bool state)
    {
        OnTimerState(state);
    }

    public void StartInterrubt(int order)
    {
        switch (order)
        {
            case 1: 
                obstacle_1.SetActive(true);
                break;

            case 2:
                obstacle_2.SetActive(true);
                break;

            default: break;
        }
    }

    public void GameEnd()
    {
        ChangTimerState(false);
        OnPlayerStop(true);
        goal_VFX.SetActive(false);
        goal.GetComponent<Collider>().enabled = false;
        goalStar_VFX.SetActive(true); 
        gameClear_UI.SetActive(true);
    }

    public void GameFail()
    {
        ChangTimerState(false);
        OnPlayerStop(true);
        gameOver_UI.SetActive(true);
    }
}
