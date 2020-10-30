using UnityEngine;

namespace Buriola.Gameplay.Animations
{
    [RequireComponent(typeof(Animation))]
    [DisallowMultipleComponent]
    public class AnimationController : MonoBehaviour
    {
        private Animation _animation;

        private void Start()
        {
             _animation = GetComponent<Animation>();
        }

        public void PlayAnimation(string animationName)
        {
            AnimationClip clip = _animation.GetClip(animationName);
            if (clip != null)
            {
                _animation.clip = clip;
                _animation.Play();
            }
            else
            {
                Debug.LogError($"Couldn't find animation with name {animationName}");
            }
        }

        public void SetAnimationClip(string animationName)
        {
            AnimationClip clip = _animation.GetClip(animationName);
            if (clip != null)
            {
                _animation.clip = clip;
            }
            else
            {
                Debug.LogError($"Couldn't find animation with name {animationName}");
            }
        }

        public void SetAnimationClip(AnimationClip clip)
        {
            if (clip != null)
            {
                _animation.clip = clip;
            }
            else
            {
                Debug.LogError($"Couldn't set clip to null, please provide a valid animation clip");
            }
        }

        public void StopAnimation()
        {
            _animation.Stop();
        }

        public bool IsPlayingAnimation()
        {
            return _animation.isPlaying;
        }

        public float GetCurrentAnimationLength()
        {
            return _animation.clip.length;
        }
    }
}
