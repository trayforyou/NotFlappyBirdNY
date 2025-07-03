using UnityEngine;

public static class PlayerAnimatorData
{
    public static class Params
    {
        public static readonly int Jump = Animator.StringToHash(nameof(Jump));
        public static readonly int Fall = Animator.StringToHash(nameof(Fall));
    }
}
