using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 점수와 게임 오버 여부, 게임 UI를 관리하는 게임 매니저
public class GameManager : MonoBehaviourPunCallbacks
{
    public string[] items = { "Bottle_Endurance", "Bottle_Health", "Bottle_Mana" };
    static int itemNum = 30;
    public static string character;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 randomSpawnPos = Random.insideUnitSphere * 5f;
        randomSpawnPos.y = 1f;
        if (character == "Casual_Shirt_Blue_White")
            PhotonNetwork.Instantiate("Casual_Shirt_Blue_White", randomSpawnPos, Quaternion.identity);
        else if (character == "Casual_Shirt_Grey_Blue")
            PhotonNetwork.Instantiate("Casual_Shirt_Grey_Blue", randomSpawnPos, Quaternion.identity);
        else if (character == "Suit_Open_Shirt_Grey_Blue")
            PhotonNetwork.Instantiate("Suit_Open_Shirt_Grey_Blue", randomSpawnPos, Quaternion.identity);
        else if (character == "Suit_Shirt_Beige")
            PhotonNetwork.Instantiate("Suit_Shirt_Beige", randomSpawnPos, Quaternion.identity);
        else if (character == "Suit_Tie_Black")
            PhotonNetwork.Instantiate("Suit_Tie_Black", randomSpawnPos, Quaternion.identity);
        else if (character == "Suit_Top_Grey_Black")
            PhotonNetwork.Instantiate("Suit_Top_Grey_Black", randomSpawnPos, Quaternion.identity);
        else if (character == "Player")
            PhotonNetwork.Instantiate("Player", randomSpawnPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PhotonNetwork.LeaveRoom();
        }
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}
