using System;
using UnityEngine;
using DG.Tweening;
using NUnit.Framework;
using System.Collections.Generic;

public class Car : MonoBehaviour
{
    [SerializeField] private Vector3 angle = new Vector3 (360f, 0f, 0f);
    [SerializeField] private float _timeMove= 6f;
    [SerializeField] private float timeComplete= 2f;

    private Tween _rotate;
    private Tween _move;

    void Start()
    {
    }

    public void Move(Transform endPoint)
    {
        Vector3 pointToMove = new Vector3(endPoint.position.x, endPoint.position.y, endPoint.position.z );
        _move = this.gameObject.transform.DOMove(pointToMove,_timeMove);
    }

    private void OnDestroy()
    {
        _move.Kill();
    }
}
