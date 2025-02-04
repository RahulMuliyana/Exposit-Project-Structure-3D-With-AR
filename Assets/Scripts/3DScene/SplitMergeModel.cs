using UnityEngine;
using UnityEngine.UI;

public class SplitMergeModel : MonoBehaviour
{
    public float splitDistance = 2f; // The distance each part will move away from the center
    public Transform[] parts;
    private Vector3[] originalPositions; // The original positions of the parts
    private bool isSplit = false;
    private float splitDuration = 40f; // Duration for the split/merge animation
    public Button SplitButton;
    public Button MergeButton;
   


    private float animationTime = 0.0f;
    void Start()
    {
        SplitButton.onClick.AddListener(() => SplitButtonClicked()); // Add listener to button click event
        MergeButton.onClick.AddListener(() => MergedButtonClicked()); // Add listener to button click event
        // Store the original positions of the parts
        originalPositions = new Vector3[parts.Length];

        for (int i = 0; i < parts.Length; i++)
        {
            originalPositions[i] = parts[i].localPosition;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Split();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Merge();
        }
        // Animate the split or merge
        animationTime += Time.deltaTime;
        float t = animationTime / splitDuration;

        for (int i = 0; i < parts.Length; i++)
        {
            Vector3 direction = (parts[i].localPosition - transform.localPosition).normalized;
            Vector3 targetPosition = isSplit && gameObject.activeInHierarchy == true ? originalPositions[i] + direction * splitDistance : originalPositions[i];
            parts[i].localPosition = Vector3.Lerp(parts[i].localPosition, targetPosition, t);

            if(gameObject.activeInHierarchy == false)
            {
                SplitButton.gameObject.SetActive(true);
                MergeButton.gameObject.SetActive(false);
                Merge();
            }
        }

        if (animationTime >= splitDuration)
        {
            animationTime = splitDuration; // Clamp to split duration
            MergeButton.gameObject.SetActive(true);
        }
    }

    public void Split()
    {
        isSplit = true;
        animationTime = 0.0f;
    }

    public void Merge()
    {
        isSplit = false;
        animationTime = 0.0f;
    }
    public void SplitButtonClicked()
    {
        Split();
        SplitButton.gameObject.SetActive(false);
        MergeButton.gameObject.SetActive(true);
    }
    public void MergedButtonClicked()
    {
        Merge();
        SplitButton.gameObject.SetActive(true);
        MergeButton.gameObject.SetActive(false);
    }
}
