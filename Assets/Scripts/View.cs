using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    [SerializeField]
    PlayerStats myStats;

    [SerializeField]
    Image healthBarImage;

    // Update is called once per frame
    void Update()
    {
        healthBarImage.fillAmount = myStats.health / myStats.maxHealth;
    }
}
