using UnityEngine;

public class Lock : MonoBehaviour
{
    public int lockIndex;
    public ShopMenu shopMenu;

    public void Locked()
    {
        shopMenu.lockPopup.SetActive(true);
        shopMenu.description.text = shopMenu.lockedText[lockIndex];
    }
}
