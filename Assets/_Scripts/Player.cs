using RedHouseGames;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private bool isTriggered = false;

    [SerializeField]
    private Collider2D triggered = null;

    [SerializeField]
    private Loop loop = null;

    [Header("Set it in Editor")]
    [SerializeField]
    private AudioSource onTriggerHitNotifier = null;

    [Header("Set it in Editor")]
    [SerializeField]
    private AudioSource onTriggerMissNotifier = null;

    [Header("Set it in Editor")]
    [SerializeField]
    private GameObject onHitSFX = null;

    [SerializeField] private CameraShake shake;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTriggered = true;
        triggered = collision;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTriggered = false;
        triggered = null;
    }

    private void Update()
    {
        if
        (
            Input.GetKeyDown(KeyCode.RightArrow)
            && isTriggered
            && triggered != null
        )
        {
            Debug.LogFormat("Hit {0}", triggered.name);

            // Do search.
            if (loop == null)
            {
                loop = GetComponentInParent<Loop>();
            }

            // If you are successful
            if (loop != null && onTriggerHitNotifier != null)
            {
                // increase score
                GameManager.instance.score++;

                // camera shake
                shake.StartCoroutine(shake.Shake(0.15f, 0.5f));

                // Audio notification.
                onTriggerHitNotifier.Play();

                // Play transition animation.
                loop.Animator.SetTrigger("Next");
            }

            if (onHitSFX != null)
            {
                Instantiate(onHitSFX, transform.position, transform.rotation);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameManager gm = GameManager.instance;

            if (gm != null && gm.lives > 0 && onTriggerMissNotifier != null)
            {
                // Audio notification.
                onTriggerMissNotifier.Play();

                // Losing life.
                gm.lives--;

                // camera shake
                shake.StartCoroutine(shake.Shake(0.10f, 0.25f));
            }
        }
    }
}
