using UnityEngine;

public class CheckHealthPlayerForHealing : MonoBehaviour
{
    private GameObject playerObj;
    private Entity player;

    private void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<Entity>();
    }
    public bool PlayerNeedHealing()
    {
        if (player.currentHealth <= player.maxHealth / 2)
        {
            CheckHealthPlayerForStoppingHealing.alreadyUsed = true;
            return true;
        }

        return false;
    }
}