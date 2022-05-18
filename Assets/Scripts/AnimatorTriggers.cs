using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTriggers : MonoBehaviour
{
    public Animator animator;

    public void EnableBool(string name) => animator.SetBool(name, true);

    public void DisableBool(string name) => animator.SetBool(name, false);
}
