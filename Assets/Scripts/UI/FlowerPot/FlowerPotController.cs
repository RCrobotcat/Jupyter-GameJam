using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlowerPotController : MonoBehaviour
{
    public Text flowerTips;
    public LogData_SO raiseFlowerLog;
    bool isFlowerRaised = false;

    public GameObject flower;

    void Update()
    {
        if (GameManager.Instance.raiseFlower && !isFlowerRaised)
        {
            flowerTips.text = "������ֲ�ɹ���";
            if (raiseFlowerLog != null)
                LogManager.Instance.AddLogData(raiseFlowerLog);
            isFlowerRaised = true;
        }

        if (SceneManager.GetActiveScene().name != "Room_childhood")
        {
            if (isFlowerRaised)
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
    }
}
