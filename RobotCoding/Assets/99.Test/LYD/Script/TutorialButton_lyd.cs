using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialButton_lyd : MonoBehaviour
{
    public List<GameObject> images;
    public int num;
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < images.Count; i++)
        {
            images[i].SetActive(false);

        }
        images[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickBtn() //�ƹ����� Ŭ���ص� �ǵ��� �Ƹ� ������Ʈ������ Ŭ���ؾ��ҰŰ���
    {
    
        if (num < images.Count -1)
        {
            images[num].SetActive(false);
            images[num + 1].SetActive(true);
        }
           
    if(num == images.Count -1)
    {
        images[num].SetActive(false);
        btn.gameObject.SetActive(false);
        Debug.Log("dddd");
    }


        num++;
    }
}
