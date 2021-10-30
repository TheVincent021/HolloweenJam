using Pathfinding;
using UnityEngine;

public class FollowerEventHandler : MonoBehaviour
{
    #region Fields
    FollowerHealth followerHealth;
    FollowerAnimator followerAnimator;
    FollowPlayer followPlayer;

    AIDestinationSetter aiDestination;
    #endregion

    #region Callbacks
    void Awake () {
        MakeReferences();
    }
    #endregion

    void MakeReferences () {
        followerHealth = GetComponent<FollowerHealth>();
        followerAnimator = GetComponentInChildren<FollowerAnimator>();
        followPlayer = GetComponent<FollowPlayer>();

        aiDestination = GetComponent<AIDestinationSetter>();
    }

    public void Damage () {
        followerAnimator.Damage();
        SoundManager.instance.Play("Follower_Pain");

        UIManager.instance.DamageFollower();
    }

    public void Die (bool sacrificed) {

        if (sacrificed) {
            UIManager.instance.RemoveAllFollowerHearts();
            followerAnimator.Impale();
            SoundManager.instance.Play("Sacrifice");
        } else {
            UIManager.instance.DamageFollower();
            followerAnimator.Die();
            SoundManager.instance.Play("Follower_Death");
        }

        Destroy(followerAnimator);
        Destroy(followPlayer);
        Destroy(followerHealth);
        Destroy(GetComponent<CircleCollider2D>());

        Destroy(this);
    }
}
