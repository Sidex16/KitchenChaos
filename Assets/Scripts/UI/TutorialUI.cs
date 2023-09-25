using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI moveUpKeyText;
    [SerializeField]
    private TextMeshProUGUI moveDownKeyText;
    [SerializeField]
    private TextMeshProUGUI moveLeftKeyText;
    [SerializeField]
    private TextMeshProUGUI moveRightKeyText;
    [SerializeField]
    private TextMeshProUGUI interactKeyText;
    [SerializeField]
    private TextMeshProUGUI interactAltKeyText;
    [SerializeField]
    private TextMeshProUGUI pauseKeyText;


    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
        GameInput.Instance.OnBindingRebind += GameInput_OnBindingRebind;

        UpdateVisual();
        Show();
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsCountdownToStartActive())
        {
            Hide();
        }
    }

    private void GameInput_OnBindingRebind(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }


    private void UpdateVisual()
    {
        moveUpKeyText.text = GameInput.Instance.GetBindingText(GameInput.Binding.MoveUp);
        moveDownKeyText.text = GameInput.Instance.GetBindingText(GameInput.Binding.MoveDown);
        moveLeftKeyText.text = GameInput.Instance.GetBindingText(GameInput.Binding.MoveLeft);
        moveRightKeyText.text = GameInput.Instance.GetBindingText(GameInput.Binding.MoveRight);
        interactKeyText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact);
        interactAltKeyText.text = GameInput.Instance.GetBindingText(GameInput.Binding.InteractAlt);
        pauseKeyText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);
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
