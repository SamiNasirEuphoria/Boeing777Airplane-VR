using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading.Tasks;
using TMPro;
[RequireComponent(typeof(CanvasGroup))]
public class Quiz : MonoBehaviour
{
    // This script is responsible for handling Quiz
    public Button[] AnswerButton;
    public string[] MultipleChoiceOptions;
    public TMP_Text questionTextHolder;
    public string question;
    public GameObject AnswerPanel;
    public string correctAnswer = "Flammability";
    private CanvasGroup canvesGroup;
    private float time, resetAlpha=0f, setAlpha =1f;
    public float delayTime;
    private bool forward, reverse;
    // Start is called before the first frame update
    public void EnableQuiz()
    {
        if (!canvesGroup.blocksRaycasts)
        {
            time = resetAlpha;
            forward = true;
            reverse = false;
            canvesGroup.alpha = resetAlpha;
            canvesGroup.blocksRaycasts = true;
            ObjectReferenceContainer.Instance.CF2CanvesPanel.SetActive(false);
        } 
    }
    void Start()
    {
        questionTextHolder.text = question;
        canvesGroup = GetComponent<CanvasGroup>();
        canvasGroupForAnswer = AnswerPanel.GetComponent<CanvasGroup>();
        var count = AnswerButton.Length;
        for (int i = 0; i < count; i++)
        {
            int buttonIndex = i;
            AnswerButton[i].onClick.AddListener(() => CorrectAnswer(AnswerButton[buttonIndex].transform.GetChild(0).GetComponent<TMP_Text>().text));
        }
        for (int i = 0; i < AnswerButton.Length; i++)
        {
            var temp = i;
            AnswerButton[i].GetComponentInChildren<TMP_Text>().text = MultipleChoiceOptions[i];
        }
    }
    private void FixedUpdate()
    {
        if (forward)
        {
            time += Time.fixedDeltaTime / delayTime;
            canvesGroup.alpha = time;
            if (canvesGroup.alpha == 1)
            {
                forward = false;
            }
        }
        else if (reverse)
        {
            time -= Time.fixedDeltaTime / delayTime;
            canvesGroup.alpha = time;
            if (canvesGroup.alpha == 0)
            {
                reverse = false;
            }
        }
    }
    public async void CorrectAnswer(string answer)
    {
        if(answer.ToLower() == correctAnswer.ToLower())
        {
            AnswerPanel.GetComponentInChildren<TMP_Text>().text = "Correct";
            StartCoroutine(FadeInOut());
            await Task.Delay(1000);

            DisableQuiz();
        }
        else
        {
            AnswerPanel.GetComponentInChildren<TMP_Text>().text = "Incorrect";
            StartCoroutine(FadeInOut());
        } 
    }
    public void DisableQuiz()
    {
        if (canvesGroup.blocksRaycasts)
        {
            reverse = true;
            time = setAlpha;
            canvesGroup.alpha = setAlpha;
            canvesGroup.blocksRaycasts = false;
        }
        ObjectReferenceContainer.Instance.CF2CanvesPanel.SetActive(true);
        ObjectReferenceContainer.Instance.controlPanel.SetActive(true);
    }

    [Header("Answer Panel variables")]
    //now i want to implement functionality for answer quiz
    public float fadeInDuration = 0.5f;   // Duration for fade in (in seconds)
    public float fadeOutDuration = 0.5f;  // Duration for fade out (in seconds)
    public float delayBetweenFades = 0.05f; // Delay between fade in and fade out (in seconds)

    private CanvasGroup canvasGroupForAnswer;

    private IEnumerator FadeInOut()
    {
        canvasGroupForAnswer.blocksRaycasts = true;
        yield return StartCoroutine(FadeIn());
        yield return new WaitForSeconds(delayBetweenFades);
        yield return StartCoroutine(FadeOut());
        canvasGroupForAnswer.blocksRaycasts = false;
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeInDuration)
        {
            canvasGroupForAnswer.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        canvasGroupForAnswer.alpha = 1f; // Ensure alpha is exactly 1 at the end
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        
        while (elapsedTime < fadeOutDuration)
        {
            canvasGroupForAnswer.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeOutDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        canvasGroupForAnswer.alpha = 0f; // Ensure alpha is exactly 0 at the end
    }
}
