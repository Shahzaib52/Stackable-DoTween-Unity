using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

[DisallowMultipleComponent]
public class _DoMove : _tween
{
    public Transform _target;

    // Start is called before the first frame update
    public override void Start()
    {
        _myTween = this.transform.DOMove(_target.position, _tweenParameters._duration);
        base.Start();
    }

}
