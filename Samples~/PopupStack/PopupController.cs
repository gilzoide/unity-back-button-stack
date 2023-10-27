using Gilzoide.BackButtonStack;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : ABackButtonHandler
{
    public PopupSpawner PopupSpawner { get; set; }
    [SerializeField] private Text _title;

    private void Start()
    {
        string title = $"Popup {transform.GetSiblingIndex()}";
        name = title;
        _title.text = title;
    }

    public void PushPopup()
    {
        PopupSpawner.SpawnPopup();
    }

    public void Close()
    {
        Destroy(gameObject);
    }

    public override void HandleBackButton()
    {
        Close();
    }
}
