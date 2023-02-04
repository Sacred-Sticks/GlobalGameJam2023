using System.Text;
using UnityEngine;

public class Safe : MonoBehaviour
{
    [SerializeField] private string combination;
    private StringBuilder keyedEntry = new StringBuilder();

    public void Press(char key)
    {
        keyedEntry.Append(key);
    }

    public void ClearEntry()
    {
        keyedEntry.Clear();
    }

    public bool CanOpen
    {
        get
        {
            return keyedEntry.ToString().EndsWith(combination);
        }
    }
}
