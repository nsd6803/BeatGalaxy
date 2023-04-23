using UnityEngine;
using UnityEngine.UI; // ��������� ������������ ���� ��� ������ � UI ����������
using TMPro;
using System.Collections;

public class CoinManager : MonoBehaviour
{

    public int coinCount = 0;
    public float timerDuration = 2.0f;
    private float timer = 0.0f;
    public int price = 5;

    public TMP_Text coinText; // ���� ��� �������� ������ �� ������� Text

    private void Start()
    {
        coinText = GetComponentInChildren<TMP_Text>(); // �������������� ���� coinText � ������� ������ GetComponentInChildren
        CoinStatus();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timerDuration)
        {
            coinCount += 5;
            timer = 0.0f;
            coinText.text = coinCount.ToString();
        }
    }

    public void CoinStatus()
    {
        coinText.text = coinCount.ToString();
    }
}