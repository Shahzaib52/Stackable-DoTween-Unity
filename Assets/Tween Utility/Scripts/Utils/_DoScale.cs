using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

[DisallowMultipleComponent]
public class _DoScale : _tween
{
    public Vector3 _target;

    // Start is called before the first frame update
    public override void Start()
    {
        _myTween = this.transform.DOScale(_target, _tweenParameters._duration);

        base.Start();
    }
}
