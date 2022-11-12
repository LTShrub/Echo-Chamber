using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public GameObject titleScreen;
    public GameObject endScreen;
    public GameObject choiceScreen;
    public bool gameActive;
    public int dayCount;
    public TextMeshProUGUI question;
    public TextMeshProUGUI choiceOne;
    public TextMeshProUGUI choiceTwo;
    public TextMeshProUGUI choiceThree;
    public TextMeshProUGUI choiceFour;
    public GameObject openBox;
    public GameObject closedBox;
    public GameObject questionAnswer;
    public GameObject ending1;
    public GameObject ending2;
    public GameObject ending3;
    public GameObject ending4;
    private bool opened = false;
    public int day = 0;
    private int optionTotal = 0;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        titleScreen.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(optionTotal > 1 && optionTotal < 6){
            ending4.gameObject.SetActive(false);
        }
        if(optionTotal >= 6 && optionTotal < 9){
            ending3.gameObject.SetActive(true);
            ending4.gameObject.SetActive(true);
        }
        if(optionTotal >= 9 && optionTotal < 12){
            ending2.gameObject.SetActive(true);
            ending4.gameObject.SetActive(true);
        }
        if(optionTotal >= 12 && optionTotal < 17){
            ending1.gameObject.SetActive(true);
            ending4.gameObject.SetActive(true);
        }

        //Repeat as many days as needed (for whatever reason).
        if (Input.GetKeyDown(KeyCode.E) && opened == false)
        {
            titleScreen.gameObject.SetActive(false);
            openBox.gameObject.SetActive(true);
            closedBox.gameObject.SetActive(false);
            opened = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && opened == true)
        {
            openBox.gameObject.SetActive(false);
            closedBox.gameObject.SetActive(true);
            opened = false;
        }

        AnswerQuestion();
    }

    public void AnswerQuestion(){
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            questionAnswer.gameObject.SetActive(false);
            optionTotal += 4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            questionAnswer.gameObject.SetActive(false);
            optionTotal += 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            questionAnswer.gameObject.SetActive(false);
            optionTotal += 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            questionAnswer.gameObject.SetActive(false);
            optionTotal += 1;
        }
    }

    public void AskQuestion(int day){
        if (day == 0){
            question.text = "The new MyScreen is now said to be a must have by ConsumerIndex[]!";
            choiceOne.text = "(1) I do need a new addition!";
            choiceTwo.text = "(2) Maybe I do need a new phone.";
            choiceThree.text = "(3) I don't think I need this.";
            choiceFour.text = "(4) I definitely don't need this";
            questionAnswer.gameObject.SetActive(true);
        }
        else if (day == 1){
            question.text = "The latest MyBlongle is out now! the hottest new edition for MyHome";
            choiceOne.text = "(1) I will buy 2!";
            choiceTwo.text = "(2) I might buy it.";
            choiceThree.text = "(3) It is not really my thing.";
            choiceFour.text = "(4) I will not buy this.";
            questionAnswer.gameObject.SetActive(true);
        }
        else if (day == 2){
            question.text = "Last chance to get in on the MyProducts craze! Don't make a mistake you’ll regret.";
            choiceOne.text = "(1) I need more MyProducts to survive!!";
            choiceTwo.text = "(2) I'll pay for 2 more thing.";
            choiceThree.text = "(3) It's tempting, but I won't buy.";
            choiceFour.text = "(4) I never want to hear an Echo Ad Again!.";
            questionAnswer.gameObject.SetActive(true);
        }
    }
}
