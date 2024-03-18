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
        "1�� �׽�Ʈ",
        "2�� �׽�Ʈ",
        "3�� �׽�Ʈ"
    };

    public float typingSpeed = 0.15f;

    private bool isEnd = false; // Ÿ������ ����
    
    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(_typing());
    }

    // Update is called once per frame
    void Update()
    {
        //ȭ���� Ŭ������ �� �״��� �۾��� ������ �Ѵ�.
        if (Input.GetMouseButtonDown(0))
        {
            isEnd = false;
            StartCoroutine(Typing());
            //   if(isEnd && )
        }
        //ȭ�� Ŭ�� �� Ÿ���� �ǰ� �ִ� �۾��� ���߰� ��. �׸��� �ٽ� �� �� Ŭ�� �� ���� �ؽ�Ʈ�� �Ѿ

    }
    //ù��° ����
    //�ι�° ���� 
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
