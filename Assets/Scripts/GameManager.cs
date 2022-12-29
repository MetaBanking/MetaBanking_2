using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 점수와 게임 오버 여부, 게임 UI를 관리하는 게임 매니저
public class GameManager : MonoBehaviourPunCallbacks
{
    public string[] items = { "Bottle_Endurance", "Bottle_Health", "Bottle_Mana" };
    static int itemNum = 30;
    public static int character;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 randomSpawnPos = Random.insideUnitSphere * 5f;
        randomSpawnPos.y = 1f;
        if (character == 1)
            PhotonNetwork.Instantiate("Female1", randomSpawnPos, Quaternion.identity);
        else if (character == 2)
            PhotonNetwork.Instantiate("Female2", randomSpawnPos, Quaternion.identity);
        else if (character == 3)
            PhotonNetwork.Instantiate("Female3", randomSpawnPos, Quaternion.identity);
        else if (character == 4)
            PhotonNetwork.Instantiate("Female4", randomSpawnPos, Quaternion.identity);
        // PhotonNetwork.Instantiate("Player", randomSpawnPos, Quaternion.identity);
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
