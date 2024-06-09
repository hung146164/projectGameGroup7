using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerAnimation
{
    void SetMoveAnimation(float velocity);
    void SetJumpAnimation();
    void ResetJumpAnimation();
    void SetAttackAnimation(float state);
}
