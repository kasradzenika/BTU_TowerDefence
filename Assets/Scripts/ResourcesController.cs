using UnityEngine;
using UnityEngine.UI;

public class ResourcesController : MonoBehaviour
{
    public Text moneyText;
    public int initialMoney = 500;

    private int _money;
    public int Money
    {
        get
        {
            return _money;
        }
        set
        {
            _money = value;
            moneyText.text = _money.ToString();
        }
    }

    public static ResourcesController instance;

    private void Awake()
    {
        instance = this;
        Money = initialMoney;
    }
}
