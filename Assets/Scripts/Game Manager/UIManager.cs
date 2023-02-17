using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{

    [SerializeField] public TextField ScoreText { get; set; }
    


    // Start is called before the first frame update
    void Start()
    {
        ScoreText.value = "0";
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.value = $"{GameManager.Instance.Score}";
    }
}
