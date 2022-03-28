using UnityEngine;
using System.Data;
using UnityEngine.UI;

public class AtributeInitialization : MonoBehaviour // initialization of 4 indicators
{
    public AudioSource sceneAudioSource; // scene opening sound effect
    public int delay = 4; // sound effect delay, 4 sec (didn't work)
    public Text show_current_day; // text field with current day number
    public Text show_current_health; // textbox for "Health" value
    public Text show_current_progress; // text field for value "Knowledge"
    public Text show_current_money; // text field for value "Money"
    public Text show_current_mental; // text field for the value "Mental health"
    public Button button_mental; // button to go to the question on the topic "mental health"
    public Button button_health; // button to go to the question on the topic "physical health"
    public Button button_progress; // button to go to the question on the topic "progress"
    public Button button_money; // button to go to the question on the topic "money"

    public void Start()
    {
        // fetching player parameters from the "Player" table
        DataTable questionData = MyDataBase.GetTable("SELECT * FROM Player WHERE ID_player = 1;");
        // get current parameter values
        int current_day = int.Parse(questionData.Rows[0][1].ToString());
        int current_mental = int.Parse(questionData.Rows[0][2].ToString());
        int current_health = int.Parse(questionData.Rows[0][3].ToString());
        int current_progress = int.Parse(questionData.Rows[0][4].ToString());
        int current_money = int.Parse(questionData.Rows[0][5].ToString());

        // if there are buttons to go to the question, perform actions
        if (button_mental != null || button_health != null || 
            button_progress != null || button_money != null)
        {
            // get data about blocked parameters
            int block_mental = int.Parse(questionData.Rows[0][6].ToString());
            int block_health = int.Parse(questionData.Rows[0][7].ToString());
            int block_progress = int.Parse(questionData.Rows[0][8].ToString());
            int block_money = int.Parse(questionData.Rows[0][9].ToString());

            // block button according to data
            if (block_mental == 1)
            {
                button_mental.interactable = false;
            }
            if (block_health == 1)
            {
                button_health.interactable = false;
            }
            if (block_progress == 1)
            {
                button_progress.interactable = false;
            }
            if (block_money == 1)
            {
                button_money.interactable = false;
            }
        }
        
        // show current parameter values
        show_current_day.text = current_day.ToString();
        show_current_mental.text = current_mental.ToString();
        show_current_health.text = current_health.ToString();
        show_current_progress.text = current_progress.ToString();
        show_current_money.text = current_money.ToString();

        // delayed sound effect playback
        sceneAudioSource.PlayDelayed(delay);
    }

}
