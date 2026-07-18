using System;
using UnityEngine;
using UnityEngine.EventSystems;

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

public class Ball : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private int point;

    [SerializeField]
    private BallColor color;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(point);
        GameManager.instance.PlayerScore += point;
        Destroy(gameObject);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
