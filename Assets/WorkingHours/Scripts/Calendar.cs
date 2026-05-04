using System;
using UnityEngine;

public class Calendar : MonoBehaviour
{
    public static Calendar Instance { get; private set; }

    [SerializeField] private float TimeHour;
    [SerializeField] private float TimeMinute;
    [SerializeField] private int Day;
    [SerializeField] private int Month;
    [SerializeField] private int Year;

    private void Awake()
    {
        Instance = this;
    }

    public void Initialized()
    {
        Year = DateTime.Now.Year;
        Month = DateTime.Now.Month;
        Day = DateTime.Now.Day;
    }

    private void Update()
    {
        TimeHour = DateTime.Now.Hour;
        TimeMinute = DateTime.Now.Minute;
    }
}
