using UnityEngine;

public class Unparent : MonoBehaviour
{
    private void Awake()
    {
        transform.parent = null;
    }
}
