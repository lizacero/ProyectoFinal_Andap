using UnityEngine;

public class Follow : MonoBehaviour
{
    RectTransform rect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            Vector3 playerPosScreen = Camera.main.WorldToScreenPoint(playerObj.transform.position);
            playerPosScreen.y -=110f;
            rect.position = playerPosScreen;
        }
    }
}
