using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FinishLine") && !GameManager.hasGameOver)
        {
            LevelCompleted();
        }
    }

    private void LevelCompleted()
    {
        GameManager.hasGameOver = true;
        UIController.Instance.LevelCompleted();
    }

    private void GameOver()
    {
        //Time.timeScale = 0;
        GetComponent<PlayerMovement>().enabled = false;
        UIController.Instance.GameOver();
        CinemachineShake.Instance.ShakeCamera();
    }
}
