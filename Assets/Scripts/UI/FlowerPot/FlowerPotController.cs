using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlowerPotController : MonoBehaviour
{
    public Text flowerTips;
    public LogData_SO raiseFlowerLog;
    bool isFlowerGet = false;

    public LogData_SO cutFlowerLog;

    public GameObject flower;

    void Update()
    {
        if (GameManager.Instance.raiseFlower)
        {
            flowerTips.text = "������ֲ�ɹ���";
            if (raiseFlowerLog != null)
                LogManager.Instance.AddLogData(raiseFlowerLog);
        }

        if (GameManager.Instance.getFlower)
        {
            if (cutFlowerLog != null)
                LogManager.Instance.AddLogData(cutFlowerLog);
        }

        if (SceneManager.GetActiveScene().name != "Room_childhood")
        {
            if (!GameManager.Instance.getKnife)
            {
                if (GameManager.Instance.raiseFlower)
                {
                    flowerTips.text = "��Ư��������������";
                    if (flower != null)
                        flower.SetActive(true);
                    flowerTips.color = Color.magenta;
                }
                else
                {
                    if (flower != null)
                        flower.SetActive(false);
                    flowerTips.color = Color.black;
                    flowerTips.text = "���������ʲô��û��";
                }
            }
            else
            {
                if (GameManager.Instance.raiseFlower)
                {
                    if (!GameManager.Instance.getFlower)
                    {
                        flowerTips.text = "����һ������������";
                        if (flower != null)
                            flower.SetActive(true);
                        flowerTips.color = Color.magenta;
                    }
                    else
                    {
                        flowerTips.text = "��Ư��������������";
                        if (flower != null)
                            flower.SetActive(true);
                        flowerTips.color = Color.magenta;
                    }
                }
                else
                {
                    if (flower != null)
                        flower.SetActive(false);
                    flowerTips.color = Color.black;
                    flowerTips.text = "���������ʲô��û��";
                }
            }
        }
    }
}
