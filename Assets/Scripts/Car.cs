using System;
using UnityEngine;
//using DG.Tweening;
using System.Collections.Generic;
using System.Collections;

public class Car : MonoBehaviour
{
    [SerializeField] private Vector3 angle = new Vector3 (360f, 0f, 0f);
    [SerializeField] private float _timeMove= 6f;
    [SerializeField] private float timeComplete= 2f;

    //private Tween _rotate;
    //private Tween _move;

    void Start()
    {
    }

    public void Move(Transform endPoint)
    {
        Vector3 pointToMove = new Vector3(endPoint.position.x, endPoint.position.y, endPoint.position.z );
        StartCoroutine(MoveTo(pointToMove, _timeMove));
        //_move = this.gameObject.transform.DOMove(pointToMove,_timeMove);
    }

    private void OnDestroy()
    {
        //move.Kill();
    }

    private IEnumerator MoveTo (Vector3 pointToMove, float duration)
    {
        Vector3 vector3 = (pointToMove - transform.position);
        float dist = vector3.magnitude;
        Vector3 direction = vector3.normalized;
        float speed = dist / duration;
        float wait = 0;
        while (wait < duration)
        {
            transform.position += direction * speed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
