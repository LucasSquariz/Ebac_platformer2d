using DG.Tweening;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{
    [SerializeField, BoxGroup("Speed setup")] public Vector2 friction = new Vector2(-.1f, 0);
    [SerializeField, BoxGroup("Speed setup")] public float speed;
    [SerializeField, BoxGroup("Speed setup")] public float speedRun;
    [SerializeField, BoxGroup("Speed setup")] public float jumpForce = 25;

    [SerializeField, BoxGroup("Animation setup")] public float jumpScaleY = 1.5f;
    [SerializeField, BoxGroup("Animation setup")] public float jumpScaleX = .7f;
    [SerializeField, BoxGroup("Animation setup")] public float animationDuration = .3f;    
    [SerializeField, BoxGroup("Animation setup")] public Ease ease = Ease.OutBack;
    [SerializeField, BoxGroup("Animation setup")] public float playerSwipeDuration = .1f;
    
    public string boolRun = "Run";
    public string triggerOnDeath = "Death";
}
