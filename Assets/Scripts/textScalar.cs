using UnityEngine;
using TMPro;

public class TextScaler : MonoBehaviour
{
    public Transform playerCamera; 
    public float minScale = 0.5f;
    public float maxScale = 1.5f;
    public float minDistance = 1f;
    public float maxDistance = 5f;

    private TextMeshPro textMesh;
    private CanvasGroup canvasGroup;

    void Start()
    {
        textMesh = GetComponent<TextMeshPro>();
        canvasGroup = gameObject.AddComponent<CanvasGroup>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, playerCamera.position);

        float scale = Mathf.Lerp(maxScale, minScale, (distance - minDistance) / (maxDistance - minDistance));
        scale = Mathf.Clamp(scale, minScale, maxScale);
        transform.localScale = Vector3.one * scale;

        float alpha = Mathf.Lerp(1f, 0f, (distance - minDistance) / (maxDistance - minDistance));
        alpha = Mathf.Clamp01(alpha);
        canvasGroup.alpha = alpha;

        transform.LookAt(playerCamera);
        transform.rotation = Quaternion.LookRotation(transform.position - playerCamera.position);
    }
}
