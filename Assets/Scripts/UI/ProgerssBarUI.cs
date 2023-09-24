using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgerssBarUI : MonoBehaviour
{
    [SerializeField]
    private Image barImage;

    [SerializeField]
    private GameObject hasProgressGameObject;

    private IHasProgress hasProgress;

    private void Start()
    {
        hasProgress = hasProgressGameObject.GetComponent<IHasProgress>();
        if (hasProgress == null) 
        {
            Debug.LogError("Game Object " + hasProgressGameObject + " does not have a component that implements IHasProgress");
        }

        hasProgress.OnProgressChanged += hasProgress_OnProgressChanged;

        barImage.fillAmount = 0;

        Hide();
    }

    private void hasProgress_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        barImage.fillAmount = e.progress;

        if (e.progress < 1 && e.progress != 0)
        {
            Show();
        }
        else
        {
            Hide();
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
