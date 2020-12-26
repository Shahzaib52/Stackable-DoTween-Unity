using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[DisallowMultipleComponent]
public class _DoColor : _tween
{
    public Image _image;
    public Color _target;

    // Start is called before the first frame update
    public override void Start()
    {
        _myTween = this._image.DOColor(_target, _tweenParameters._duration);

        base.Start();
    }
}
