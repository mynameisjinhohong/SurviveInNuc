using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using KoreanTyper;
public class DioalogSystem_LYD : MonoBehaviour
{
    public TextMeshProUGUI textName;
    public TextMeshProUGUI textSentence;
    public float typingTime = 5f; //글씨 쳐지는 시간
    Queue<string> senctences = new Queue<string>();

    public GameObject dialogueImage;
    public DialogueTrigger_lyd trigger;
    private Coroutine coroutine;
    public bool isEnd;

    public Button skipBtn;
    bool isSkip;
    string s;
    public void Begin(Dialogue_lyd info)
    {
        senctences.Clear();

        textName.text = info.name;
        foreach(var sentence in info.sentences)
        {
            senctences.Enqueue(sentence);
        }
        Next();    
    }

    private void Next()
    {
        if(senctences.Count == 0)
        {
            End();
            return;
        }

        
       if(isEnd)
        {
            StopAllCoroutines();

            textSentence.text = s;
            isEnd = false;
        }
        else
        {
            textSentence.text = string.Empty;
            StopAllCoroutines();
            coroutine = StartCoroutine(TypeSentence(senctences.Dequeue()));
        }

          
       
          

        


    }
    public void End()
    {
        while (senctences.Count > 0)
        {
            senctences.Dequeue();
        }
        textSentence.text = string.Empty;
        StopAllCoroutines();
        dialogueImage.SetActive(false);
        skipBtn.gameObject.SetActive(false);
        Debug.Log("end");
    }
    public void SkipBtn()//업데이트문 중복 클릭 방지
    {
        isSkip = true;
    }

    public void Update()
    {
            if (Input.GetMouseButtonDown(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                if (!trigger.isClick)
                {
                    trigger.Trigger();

                }
                else
                {
                    Next();
                }
            }
                    
            }
        
    }

    public IEnumerator TypeSentence(string sentence)
    {
        isEnd = true;
        s = string.Empty;
        s = sentence;
        /* foreach(var letter in sentence)
         {
             textSentence.text += letter;

             yield return new WaitForSeconds(0.15f);
         }*/
        int typingLength = sentence.GetTypingLength();
        for(int index = 0; index <= typingLength; index++)
        {
            textSentence.text = sentence.Typing(index);
            yield return new WaitForSeconds(typingTime);
        }
        isEnd = false;
        Debug.Log("코루틴ㄲ릍");
    }
}
