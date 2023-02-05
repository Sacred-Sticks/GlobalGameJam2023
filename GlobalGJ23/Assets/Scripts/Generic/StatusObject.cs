using UnityEngine;

[CreateAssetMenu(fileName = "Status", menuName = "Game Status/Status")]
public class StatusObject : ScriptableObject
{
    [SerializeField] private Level CurrentLevel;
    public Level level {
        get => CurrentLevel; 
        set {
            CurrentLevel = value;
        } 
    }

    [System.Serializable] public enum Level {
        Menu1,
        TeenageYears,
        Menu2,
        AdultYears,
        Menu3,
        FightLostMenu
    }
}
