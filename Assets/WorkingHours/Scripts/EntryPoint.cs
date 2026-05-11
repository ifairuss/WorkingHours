using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    private void Start()
    {
        WHData.Instance.Initialized();
        Calendar.Instance.Initialized();
        ButtonActionInterface.Instance.Initialized();
    }
}
