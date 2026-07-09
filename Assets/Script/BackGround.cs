using UnityEngine;

public class BackGround : MonoBehaviour
{
     
     public float Speed;
     [SerializeField] 
     private Renderer bgRender;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bgRender.material.mainTextureOffset+= new Vector2(Speed*Time.deltaTime,0);
    }
}
