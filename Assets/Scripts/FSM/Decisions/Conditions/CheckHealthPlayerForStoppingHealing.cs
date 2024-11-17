using UnityEngine;

public class CheckHealthPlayerForStoppingHealing : MonoBehaviour
{
    static public bool alreadyUsed = false;
    
    private GameObject playerObj;
    private Entity player;

    private void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<Entity>();
    }
    public bool PlayerNoLongerNeedHealing()
    {
        if (player.currentHealth == player.maxHealth)
        {
            alreadyUsed = false;
            return true;
        }

        return false;
    }
}
