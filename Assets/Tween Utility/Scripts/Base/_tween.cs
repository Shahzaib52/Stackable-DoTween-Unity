using DG.Tweening;
using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class _tween : MonoBehaviour
{
    [System.Serializable]
    public class tweenParameter
    {
        public string _id;
        [Tooltip("attach this tween to")]
        public Transform _host;
        [Tooltip("Start this tween automatically")]
        public bool _autoplay = true;

        [Space(10)]
        public Ease _easeType;
        [Tooltip("lower is faster (in seconds)")]
        public float _duration = 1f;
        [Tooltip("delay before tween starts (in seconds)")]
        public float _delay = 0;

        [Space(10)]
        [Tooltip("-1 for infinite loop cycles")]
        public int _loopCycles = -1;
        [Tooltip("how a tween cycle will repeat in loop")]
        public LoopType _loopType = LoopType.Yoyo;

        [Space(10)]
        [Tooltip("invokes when tween starts (once)")]
        public UnityEvent _OnTweenStarted;
        [Tooltip("invokes when tween completes")]
        public UnityEvent _OnTweenCompleted;
        [Tooltip("invokes when tween completes a cycle (invokes each cycle in loop)")]
        public UnityEvent _OnTweenCycleCompleted;
        [Tooltip("invokes when tween updates (each frame)")]
        public UnityEvent _OnTweenUpdate;
    }

    public tweenParameter _tweenParameters;

    [Tooltip("reference of the started tween")]
    public Tween _myTween;

    private void Awake()
    {
        if (!_tweenParameters._host)
            _tweenParameters._host = this.transform;
    }

    // Start is called before the first frame update
    public virtual void Start()
    {
        _myTween.SetId(_tweenParameters._id).SetLink(_tweenParameters._host.gameObject).SetEase(_tweenParameters._easeType).SetDelay(_tweenParameters._delay).SetLoops(_tweenParameters._loopCycles, _tweenParameters._loopType);

        _myTween.OnStart(delegate
        {
            _tweenParameters._OnTweenStarted.Invoke();
        });

        _myTween.OnComplete(delegate
        {
            _tweenParameters. _OnTweenCompleted.Invoke();
        });

        _myTween.OnStepComplete(delegate
        {
            _tweenParameters._OnTweenCycleCompleted.Invoke();
        });

        _myTween.OnUpdate(delegate
        {
            _tweenParameters._OnTweenUpdate.Invoke();
        });

        if(_tweenParameters._autoplay)
            _myTween.Play();
    }

    public virtual void Play()
    {
        _myTween.Play();
    }

    public virtual void Pause()
    {
        _myTween.Pause();
    }

    public virtual void Stop()
    {
        _myTween.Kill();
    }

    public virtual void Restart()
    {
        _myTween.Restart();
    }

    //for events debugging
    public void _test(string _message)
    {
        Debug.Log(_message);
    }
}
