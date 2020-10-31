using UnityEngine;

namespace Buriola.Gameplay.Animations
{
    [RequireComponent(typeof(Animator))]
    [DisallowMultipleComponent]
    public class AnimationController : MonoBehaviour
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayAnimation(int animationHash)
        {
            _animator.Play(animationHash);
        }

        public void StopAnimation()
        {
            _animator.StopPlayback();
        }
    }
}
