using UnityEngine;

public class CheckIfDefendDone : MonoBehaviour
{
    public bool PlayerNoLongerNeedDefending()
    {
        if (PlayerNeedDefendingDecision.isMiddleMouseButtonClicked)
        {
            PlayerDefendedNowShootDecision.defending = false;
            return true;
        }
        return false;
    }
}