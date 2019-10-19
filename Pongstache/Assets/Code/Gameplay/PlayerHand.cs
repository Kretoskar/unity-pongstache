using Game.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    [SerializeField]
    private GameObject _arm = null;
    [SerializeField]
    private GameObject _hand = null;

    private GameObject _ball = null;
    private float _armRotationModifier = 90;

    private void Start()
    {
        _ball = FindObjectOfType<Ball>().gameObject;
    }

    private void Update()
    {
        RotateArm();
    }

    private void RotateArm()
    {
        float lookAtBallPos = transform.position.x - _ball.transform.position.x;
        float zRot = lookAtBallPos * _armRotationModifier;

        if (zRot > _armRotationModifier)
            zRot = _armRotationModifier;
        else if (zRot < -_armRotationModifier)
            zRot = -_armRotationModifier;

        Quaternion armRotation = Quaternion.Euler(0, 0, zRot + 90);
        Quaternion handRotation = Quaternion.Euler(0, 0, 90);
        _arm.transform.rotation = armRotation;
        _hand.transform.rotation = handRotation;
    }
}
