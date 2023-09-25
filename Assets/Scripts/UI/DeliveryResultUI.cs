using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryResultUI : MonoBehaviour
{
    private const string POPUP = "Popup";

    [SerializeField]
    private Image background;
    [SerializeField]
    private Image IconImage;
    [SerializeField]
    private TextMeshProUGUI messageText;
    [SerializeField]
    private Color successColor;
    [SerializeField] 
    private Color failureColor;
    [SerializeField]
    private Sprite successSprite;
    [SerializeField]
    private Sprite failureSprite;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        DeliveryManager.Instance.OnRecipeCompleted += DeliveryManager_OnRecipeCompleted;
        DeliveryManager.Instance.OnRecipeFailed += DeliveryManager_OnRecipeFailed;

        gameObject.SetActive(false);
    }

    private void DeliveryManager_OnRecipeFailed(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
        background.color = failureColor;
        IconImage.sprite = failureSprite;
        messageText.text = "Delivery\nFailed";
        animator.SetTrigger(POPUP);
    }

    private void DeliveryManager_OnRecipeCompleted(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
        background.color = successColor;
        IconImage.sprite = successSprite;
        messageText.text = "Delivery\nSuccess";
        animator.SetTrigger(POPUP);
    }
}
