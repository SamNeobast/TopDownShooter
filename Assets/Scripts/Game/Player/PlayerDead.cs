using UnityEngine;
using System.Collections;

public class PlayerDead : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        Events.OnDeadedPlayer += PlayerDeadStopGame;
        Events.OnDeadedPlayer += PlayerDeadAnimation;
        Events.OnDeadedPlayer += PlayerDeadShutDownMove;
        Events.OnDeadedPlayer += PlayerShutDownReDead;
    }

    private void PlayerShutDownReDead()
    {
        gameObject.tag = "Untagged";

    }
    private void PlayerDeadStopGame()
    {
        StartCoroutine(PlayerDeadStopGameCorotina());

        IEnumerator PlayerDeadStopGameCorotina()
        {
            yield return new WaitForSeconds(2);
            Time.timeScale = 0;
        }
    }

    private const string NameFirstDeadAnimation = "DeadFirst";
    private const string NameSecondDeadAnimation = "DeadSecond";
    private void PlayerDeadAnimation()
    {
        int randomChoseAnimation = Random.Range(1, 3);
        if (randomChoseAnimation == 1)
        {
            anim.Play(NameFirstDeadAnimation);
        }
        else if (randomChoseAnimation == 2)
        {
            anim.Play(NameSecondDeadAnimation);
        }
    }

    private void PlayerDeadShutDownMove()
    {
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerRotation>().enabled = false;
    }
    private void OnDestroy()
    {
        Events.OnDeadedPlayer -= PlayerDeadStopGame;
        Events.OnDeadedPlayer -= PlayerDeadAnimation;
        Events.OnDeadedPlayer -= PlayerDeadShutDownMove;
        Events.OnDeadedPlayer -= PlayerShutDownReDead;
    }
}
