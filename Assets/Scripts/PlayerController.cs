using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    
    
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        
        Vector3 currentPosition = transform.position;
        
        Vector3 newPosition = currentPosition + new Vector3(horizontal, 0f, 0f) * (moveSpeed * Time.deltaTime);
        
        transform.position = newPosition;
        
    }
}
