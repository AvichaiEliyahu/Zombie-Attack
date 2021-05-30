using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryCanvas : MonoBehaviour
{
    TextMeshProUGUI text;
    [SerializeField] string[] texts;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }    

    public void SetTextFromArray(int indexToSet)
    {
        StartCoroutine(SetText(indexToSet));
    }

    IEnumerator SetText(int indexToSet)
    {
        text.SetText(texts[indexToSet]);
        yield return new WaitForSeconds(5f);
        text.SetText("");
        
    }
}
