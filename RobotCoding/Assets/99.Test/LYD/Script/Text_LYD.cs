using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Text_LYD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tx;
    [SerializeField] string[] texts = new string[]
    {
        "1번 테스트",
        "2번 테스트",
        "3번 테스트"
    };

    public float typingSpeed = 0.15f;

    private bool isEnd = false; // 타이핑이 끝난
    
    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(_typing());
    }

    // Update is called once per frame
    void Update()
    {
        //화면을 클릭했을 때 그다음 글씨로 나오게 한다.
        if (Input.GetMouseButtonDown(0))
        {
            isEnd = false;
            StartCoroutine(Typing());
            //   if(isEnd && )
        }
        //화면 클릭 시 타이핑 되고 있는 글씨를 멈추게 함. 그리고 다시 한 번 클릭 시 다음 텍스트로 넘어감

    }
    //첫번째 글자
    //두번째 글자 
    private IEnumerator Typing()
    {
        foreach(string text in texts)
        {
            tx.text = "";
            for (int i = 0; i <= texts.Length; i++)
            {
                tx.text = text.Substring(0, i);
                yield return new WaitForSeconds(typingSpeed);
            }
        }
       // yield return new WaitUntil(() => !isEnd);
    }


 

}
