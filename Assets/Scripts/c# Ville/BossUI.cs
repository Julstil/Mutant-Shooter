using UnityEngine;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    [Header("Health")]
    public int[] health = new int[3];
    int maxHealth = 300;
    public Text[] healthNumber = new Text[3];


    [Header("Slider")]
    public Slider[] healthbar = new Slider[3];
    public Image[] fill = new Image[3];
    public Color bossHealth;
    public Image[] background = new Image[3];
    public Color backgroundHealth;
    Boss boss;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Boss>();
        for (int i = 0; i < health.Length; i++)
        {
            maxHealth = health[i];
        }

        for (int i = 0; i < healthbar.Length; i++)
        {
            healthbar[i].maxValue = maxHealth;
            healthbar[i].value = maxHealth;
        }

        for (int i = 0; i < fill.Length; i++)
        {
            fill[i].color = bossHealth;
        }

        for (int i = 0; i < background.Length; i++)
        {
            background[i].color = backgroundHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        healthNumber[0].text = "Mutant Heart:" + health[0];
        healthNumber[1].text = "Mutant Heart:" + health[1];
        healthNumber[2].text = "Mutant Heart:" + health[2];
       
        for (int i = 0; i < healthbar.Length; i++)
        {
            healthbar[i].value = boss.healths[i];
        }

    }

    

}
