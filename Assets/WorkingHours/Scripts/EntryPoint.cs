using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    private void Start()
    {
        WHData.Instance.Initialized();
        ButtonActionInterface.Instance.Initialized();
        PreferencesAdd.Instance.Initilized();
        Calendar.Instance.Initialized();
    }
}
