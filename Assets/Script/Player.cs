using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float limitX = 2.5f;

    void Update()
    {
#if UNITY_EDITOR
        float input = Input.GetAxis("Horizontal");
#else
        float input = Input.acceleration.x;
#endif

        Vector3 pos = transform.position;
        pos.x += input * moveSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -limitX, limitX);

        transform.position = pos;
    }
}