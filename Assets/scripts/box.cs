using UnityEngine;


public class box : MonoBehaviour
{
    private bool hasScored = false;
    private int score = 0;

    void OnCollisionEnter(Collision collision)
    {
        if (!hasScored && collision.gameObject.CompareTag("Ground"))
        {
            hasScored = true;
            ScoreManager.Instance.AddScore(10);
        }
    }
}
