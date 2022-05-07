using UnityEngine;
using Photon.Chat;
using Photon.Pun;
using ExitGames.Client.Photon;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour,IChatClientListener
{
    [SerializeField] private Text _chatText;
    [SerializeField] private InputField _textMessage;
    [SerializeField] private MoveCharacterWithButtons _moveCharacterWithButtons;

    private ChatClient _chatClient;

    private void Start()
    {
        _chatClient = new ChatClient(this);
        if (PhotonNetwork.NickName == "")
        {
            PhotonNetwork.NickName = "Player" + Random.Range(1, 1000);
        }
        _chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, PhotonNetwork.AppVersion, new AuthenticationValues(PhotonNetwork.NickName));
       
    }

    private void Update()
    {
        _chatClient.Service();
    }

    public void SendButton()
    {
        _chatClient.PublishMessage("Chat", _textMessage.text);
        _moveCharacterWithButtons.enabled = true;
    }

    public void DebugReturn(DebugLevel level, string message)
    {
        Debug.Log($"{level},{message}");
    }

    public void OnChatStateChange(ChatState state)
    {
        Debug.Log(state);
    }

    public void OnConnected()
    {
        _chatText.text += "\nВы подключились к чату";
        _chatClient.Subscribe("Chat");

    }

    public void OnDisconnected()
    {
        _chatClient.Unsubscribe(new string[] {"Chat" });
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        for (int i = 0; i < senders.Length; i++)
        {
            _chatText.text += $"\n{senders[i]}: {messages[i]}";
        }
    }

    public void OnUserSubscribed(string channel, string user)
    {
        _chatText.text += $"Пользователь {user} подключился к чату ";
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        _chatText.text += $"Пользователь {user} отключился от чата ";
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
    }

    public void OnUnsubscribed(string[] channels)
    {
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
    }

   
}
