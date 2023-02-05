using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField] private StatusObject gameStatus;

    private SceneHandler sceneHandler;

    private int activeScene;
    private int targetScene;

    private const int GRANDMAHOUSE = 0;
    private const int TPHOUSE = 1;
    private const int BAR = 2;

    private void Awake() {
        sceneHandler = GetComponent<SceneHandler>();
        activeScene = SceneManager.GetActiveScene().buildIndex;
    }

    //private void Update() {
    //    CheckStatus();
    //    if (activeScene != targetScene) {
    //        sceneHandler.CreateTransition(targetScene);
    //    }
    //}

    private void UpdateStatus() {
        switch (gameStatus.level) {
            case StatusObject.Level.Menu1:
                gameStatus.level = StatusObject.Level.TeenageYears;
                break;
            case StatusObject.Level.TeenageYears:
                gameStatus.level = StatusObject.Level.Menu2;
                break;
            case StatusObject.Level.Menu2:
                gameStatus.level = StatusObject.Level.AdultYears;
                break;
            case StatusObject.Level.AdultYears:
                gameStatus.level = StatusObject.Level.Menu3;
                break;
            case StatusObject.Level.Menu3:
                gameStatus.level = StatusObject.Level.Menu3;
                break;
            case StatusObject.Level.FightLostMenu:
                gameStatus.level = StatusObject.Level.Menu2;
                break;
            default:
                break;
        }
    }

    public void NextLevel() {
        UpdateStatus();
        int nextLevel = 0;
        switch (gameStatus.level) {
            case StatusObject.Level.Menu1:
                nextLevel = 0;
                break;
            case StatusObject.Level.TeenageYears:
                nextLevel = 1;
                break;
            case StatusObject.Level.Menu2:
                nextLevel = 0;
                break;
            case StatusObject.Level.AdultYears:
                nextLevel = 2;
                break;
            case StatusObject.Level.Menu3:
                nextLevel = 0;
                break;
            default:
                break;
        }
        sceneHandler.CreateTransition(targetScene);
    }
}