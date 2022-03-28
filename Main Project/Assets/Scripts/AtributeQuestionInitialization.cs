using UnityEngine;
using System.Data;
using UnityEngine.UI;

public class AtributeQuestionInitialization : MonoBehaviour
{
    public Text show_question; // question text field
    public Text show_question_category; // text field with question category

    public Text show_yes_mental; // text field for "Mental health" value of "yes" answer
    public Text show_yes_health; // text field for "Health" value of "yes" answer
    public Text show_yes_progress; // text field for "Knowledge" value of "yes" answer
    public Text show_yes_money; // text field for value "Money" answer "yes"

    public Text show_no_mental; // text field for "Mental health" value of answer "no"
    public Text show_no_health; // text field for "Health" value of answer "no"
    public Text show_no_progress; // text field for value "Knowledge" answer "no"
    public Text show_no_money; // text field for value "Money" answer "no"
    public int get_question_category_int; // question category numerical value

    // Start is called before the first frame update
    void Start()
    {
        // question category numerical value
        int question_category = get_question_category_int;

        // get the maximum and minimum id of questions of the selected category
        DataTable selectIDmin = MyDataBase.GetTable("SELECT min(ID_question) FROM Question " +
                                                    "WHERE question_category = " + question_category + ";");
        DataTable selectIDmax = MyDataBase.GetTable("SELECT max(ID_question) FROM Question " +
                                                    "WHERE question_category = " + question_category + ";");
        int IDmin = int.Parse(selectIDmin.Rows[0][0].ToString());
        int IDmax = int.Parse(selectIDmax.Rows[0][0].ToString()) + 1;

        // selection of a random id between the maximum and minimum id of questions of the selected category
        System.Random randomDirection = new System.Random();
        int question_id = randomDirection.Next(IDmin, IDmax);

        // get a random question with the parameters of the selected category
        DataTable questionData = MyDataBase.GetTable("SELECT * FROM Question " +
                                                        "WHERE ID_question = " + question_id +
                                                        " AND question_category = " + question_category + ";");

        // display the received question with parameters
        show_question.text = questionData.Rows[0][2].ToString();
        show_question_category.text = question_category.ToString();

        show_yes_mental.text = questionData.Rows[0][3].ToString();
        show_yes_health.text = questionData.Rows[0][4].ToString();
        show_yes_progress.text = questionData.Rows[0][5].ToString();
        show_yes_money.text = questionData.Rows[0][6].ToString();

        show_no_mental.text = questionData.Rows[0][7].ToString();
        show_no_health.text = questionData.Rows[0][8].ToString();
        show_no_progress.text = questionData.Rows[0][9].ToString();
        show_no_money.text = questionData.Rows[0][10].ToString();
    }
}
