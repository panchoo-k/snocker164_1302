using System;
using UnityEngine;

public enum BallColor
{
    white,
    red,
    yellow,
    green,
    brown,
    blue,
    pink,
    black
}

public class Ball : MonoBehaviour
{
    [SerializeField]
    private int point;

    [SerializeField]
    private BallColor color;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
