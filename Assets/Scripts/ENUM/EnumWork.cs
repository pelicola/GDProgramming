using UnityEngine;

public class EnumWork : MonoBehaviour
{
    public enum CharacterType
    {
        Player,
        Enemy,
        NPC 
    }

    // Variable to store the character type
    public CharacterType characterType;

    // Start is called before the first frame update
    void Start()
    {
        // Example of using the enum
        if (characterType == CharacterType.Player)
        {
            Debug.Log("This is a player character.");
        }
        else if (characterType == CharacterType.Enemy)
        {
            Debug.Log("This is an enemy character.");
        }
        else if (characterType == CharacterType.NPC)
        {
            Debug.Log("This is an NPC character.");
        }
    }
}