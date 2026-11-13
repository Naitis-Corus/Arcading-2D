using UnityEngine;

public class OffScreenDestroyer : MonoBehaviour
{
[SerializeField]float lowerEdjes = 9f;
static Camera cameraMain;
    void Awake()
    {
        if (cameraMain == null)
        cameraMain = Camera.main;
    }
    void Update()
    {
        if(cameraMain.transform.position.y - lowerEdjes > transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}
