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
            flowerTips.text = "花朵种植成功！";
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
                    flowerTips.text = "很漂亮的紫罗兰花朵";
                    if (flower != null)
                        flower.SetActive(true);
                    flowerTips.color = Color.magenta;
                }
                else
                {
                    if (flower != null)
                        flower.SetActive(false);
                    flowerTips.color = Color.black;
                    flowerTips.text = "这个花盆里什么都没有";
                }
            }
            else
            {
                if (GameManager.Instance.raiseFlower)
                {
                    if (!GameManager.Instance.getFlower)
                    {
                        flowerTips.text = "割下一朵紫罗兰花朵";
                        if (flower != null)
                            flower.SetActive(true);
                        flowerTips.color = Color.magenta;
                    }
                    else
                    {
                        flowerTips.text = "很漂亮的紫罗兰花朵";
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
                    flowerTips.text = "这个花盆里什么都没有";
                }
            }
        }
    }
}
