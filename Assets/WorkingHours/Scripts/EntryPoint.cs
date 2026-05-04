using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    private void Start()
    {
        Calendar.Instance.Initialized();
        ButtonActionInterface.Instance.Initialized();
    }
}
