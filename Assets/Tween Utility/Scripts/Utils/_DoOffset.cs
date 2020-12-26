using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

[DisallowMultipleComponent]
public class _DoOffset : _tween
{
    public Vector3 _startOffset;
    public Vector3 _target;

    // Start is called before the first frame update
    public override void Start()
    {
        _myTween = DOTween.To(() => _startOffset, x => _startOffset = x, _target, _tweenParameters._duration);
        base.Start();
    }

    public void OnTweenUpdate()
    {
        var pos = this.transform.position + _startOffset;
        this.transform.position = pos;
    }
}

