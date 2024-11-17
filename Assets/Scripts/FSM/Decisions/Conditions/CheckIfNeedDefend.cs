using UnityEngine;

public class CheckIfNeedDefend : MonoBehaviour
{
    public bool PlayerNeedDefending()
    {
        if (PlayerNeedDefendingDecision.isMiddleMouseButtonClicked && PlayerDefendedNowShootDecision.defending)
        {
            PlayerNeedDefendingDecision.isMiddleMouseButtonClicked = false;
            return true;
        }
        return false;
    }
}