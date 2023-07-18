using UnityEngine;

public class Lock : MonoBehaviour
{
    public int lockIndex;
    public LockInfo lockInfo;

    public void Locked()
    {
        lockInfo.background.SetActive(true);
        lockInfo.description.text = lockInfo.lockedText[lockIndex];
    }
}
