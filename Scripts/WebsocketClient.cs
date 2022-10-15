using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using WebSocketSharp;
using WebSocketSharp.Net;

public class WebsocketClient : MonoBehaviour
{
    [SerializeField] private string _serverAddress = "localhost";
    [SerializeField] private int _serverPort = 8000;

    public Text debugText;
    private string buy_action;

    private WebSocket _webSocket = null;

    private string pre_data = "no_data";

    private void Start()
    {
        //_webSocket = new WebSocket($"ws://{_serverAddress}:{_serverPort}/ws?user_name=a&room_name=room");
        _webSocket = new WebSocket("ws://localhost:8000/ws?user_name=sample_user&room_name=sample_room");

        // Event handling.
        _webSocket.OnOpen += (sender, args) => { Debug.Log("WebSocket opened."); };
        _webSocket.OnMessage += (sender, args) => { Debug.Log("OnMessage"); };
        _webSocket.OnError += (sender, args) => { Debug.Log($"WebScoket Error Message: {args.Message}"); };
        _webSocket.OnClose += (sender, args) => { Debug.Log("WebScoket closed"); };

        _webSocket.Connect();
    }

    // Update is called once per frame
    void Update()
    {
        _webSocket.OnMessage += (sender, args) => { 
            Debug.Log(args.Data);
            string data = args.Data;
            if (pre_data != data)
            {
                buy_action = JsonLoad.GetJsonData(data);
            }
            pre_data = data;
        };
        debugText.text = buy_action;
    }
}
