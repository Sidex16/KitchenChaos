using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartCountdownUI : MonoBehaviour
{
    private const string NUMBER_POPUP = "NumberPopup";

    [SerializeField]
    private TextMeshProUGUI countdowmText;

    private Animator animator;

    private int previousNumber;

    private void Awake()
    {
        animator = GetComponent<Animator>();    
    }

    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
        Hide();
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsCountdownToStartActive())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Update()
    {
        if (GameManager.Instance.IsCountdownToStartActive())
        {
            int countdownNumber = Mathf.CeilToInt(GameManager.Instance.GetCountdownTimer());
            countdowmText.text = countdownNumber.ToString();

            if (countdownNumber != previousNumber) 
            {
                previousNumber = countdownNumber;
                animator.SetTrigger(NUMBER_POPUP);

                SoundManager.Instance.PlayCountdownSound();
            }
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

}
