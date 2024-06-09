using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerMove
{
    void Move(float direction);
    void Jump();
}
