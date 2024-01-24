using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    Transform cam;
    Vector3 camStartPos;
    float distance;

    GameObject[] backGround;
    Material[] material;
    float[] backSpeed;

    float farthestBack;

    [Range(0.001f, 0.05f)]
    public float parallaxSpeed;
    
    void Start()
    {
        cam = Camera.main.transform;
        camStartPos = cam.position;

        int backCount = transform.childCount;
        material = new Material[backCount];
        backSpeed = new float[backCount];
        backGround = new GameObject[backCount];

        for(int i = 0; i < backCount; i++)
        {
            backGround[i] = transform.GetChild(i).gameObject;
            material[i] = backGround[i].GetComponent<Renderer>().material;
        }
         BackSpeedCalculate(backCount);
    }

   void BackSpeedCalculate(int backCount)
    {
        for(int i = 0; i < backCount; i++)
        {
            if ((backGround[i].transform.position.z - cam.position.z) > farthestBack)
            {
                farthestBack = backGround[i].transform.position.z - cam.position.z;
            }
        }

        for(int i = 0;i < backCount;i++)
        {
            backSpeed[i] = 1 + (backGround[i].transform.position.z - cam.position.z / farthestBack);
        }
    }
    private void LateUpdate()
    {
        distance = cam.position.x - camStartPos.x;
        transform.position = new Vector3(cam.position.x - 12, transform.position.y,0);
        for(int i = 0;i < backGround.Length; i++)
        {
            float speed = backSpeed[i] * parallaxSpeed;
            material[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed);
        }
    }
}
