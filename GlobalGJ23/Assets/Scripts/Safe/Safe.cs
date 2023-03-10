using System.Text;
using UnityEngine;

public class Safe : MonoBehaviour
{
    [SerializeField] private string combination;
    private readonly StringBuilder keyedEntry = new StringBuilder();

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
            return combination.Equals(keyedEntry.ToString());
        }
    }
}
