using UnityEngine;

public class UpgradeLock : MonoBehaviour
{
    public int lockIndex;
    public UpgradeMenu upgradeMenu;

    public void Locked()
    {
        upgradeMenu.lockPopup.SetActive(true);
        upgradeMenu.description.text = upgradeMenu.lockedText[lockIndex];
    }
}
