using UnityEngine;

public class PopupSpawner : MonoBehaviour
{
    [SerializeField] private Transform _popupParent;
    [SerializeField] private PopupController _popupPrefab;

    public void SpawnPopup()
    {
        Instantiate(_popupPrefab, _popupParent).PopupSpawner = this;
    }
}
