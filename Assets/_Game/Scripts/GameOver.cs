using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private bool isGameOver;
    [SerializeField] private GameObject gameOverCanvas;

    // Update is called once per frame
    void Update()
    {
        if(!isGameOver)
        {
            if(GameManager.Instance.state == GameState.END)
            {
                gameOverCanvas.SetActive(true);
                Cursor.visible = true;
                isGameOver = true;
            }
        }
    }
}
