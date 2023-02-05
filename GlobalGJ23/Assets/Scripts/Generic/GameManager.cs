using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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

    private void Update() {
        CheckStatus();
        if (activeScene != targetScene) {
            sceneHandler.CreateTransition(targetScene);
        }
    }

    private void CheckStatus() {
        switch (gameStatus.level) {
            case StatusObject.Level.Menu1:
                targetScene = GRANDMAHOUSE;
                break;
            case StatusObject.Level.TeenageYears:
                targetScene = TPHOUSE;
                break;
            case StatusObject.Level.Menu2:
                targetScene = GRANDMAHOUSE;
                break;
            case StatusObject.Level.AdultYears:
                targetScene = BAR;
                break;
            case StatusObject.Level.Menu3:
                targetScene = GRANDMAHOUSE;
                break;
            case StatusObject.Level.FightLostMenu:
                targetScene = GRANDMAHOUSE;
                break;
            default:
                break;
        }
    }
}
