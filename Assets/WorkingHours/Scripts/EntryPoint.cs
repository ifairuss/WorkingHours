using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    private void Start()
    {
        PreferencesAdd.Instance.Initilized();
        WHData.Instance.Initialized();
        StatisticAdd.Instance.Initialized();
        Calendar.Instance.Initialized();
        ButtonActionInterface.Instance.Initialized();
    }
}
