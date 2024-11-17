using UnityEngine;

public class CheckIfNeedTacticalShoot : MonoBehaviour
{
    public bool PlayerNeedsTacticalShoot()
    {
        if (PlayerNeedTacticalShoot.isRightClicked)
        {
            return true;
        } 
        return false;
    }
}