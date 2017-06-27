using UnityEngine;

public class EnemyMaster : MonoBehaviour
{
    public Transform destination;

    public static EnemyMaster theMaster;

    void Start ()
    {
        theMaster = this;
    }
}
