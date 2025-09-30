using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Checkpoint : MonoBehaviour
{
    public int index = 0;              // order along the level
    public Transform spawnPoint;       // optional, defaults to this transform

    void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var pc = other.GetComponent<CheckPoint1>();
            if (pc == null) return;

            // Only update if this checkpoint is further than the one we had
            if (index > pc.currentIndex)
            {
                pc.currentIndex = index;
                pc.respawnPoint = spawnPoint ? spawnPoint.position : transform.position;
                // (Optional) play a sound, flash, or UI here
            }
        }
    }
}
