using UnityEngine;

public class CheckIfTacticalDone : MonoBehaviour
{
    public bool PlayerNoLongerNeedTacticalShoot()
    {
        if (!PlayerNeedTacticalShoot.isRightClicked)
        {
            return true;
        }

        return false;
    }
}