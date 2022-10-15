using System;
using System.Text;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class CommunicateManager : MonoBehaviour
{
    [Serializable]
    private sealed class Data
    {
        public int space_id = 0;
        //public class BuySpace
        //{
        //    public int space_id = 0;
        //}
        //public int id = 25;
        //public string name = "roomA";
    }

    //private void Awake()
    //{
    //    var url = "https://httpbin.org/post";
    //    var data = new Data();
    //    var json = JsonUtility.ToJson(data);
    //    var postData = Encoding.UTF8.GetBytes(json);

    //    var request = new UnityWebRequest(url, UnityWebRequest.kHttpVerbPOST)
    //    {
    //        uploadHandler = new UploadHandlerRaw(postData),
    //        downloadHandler = new DownloadHandlerBuffer()
    //    };

    //    request.SetRequestHeader("Content-Type", "application/json");

    //    var operation = request.SendWebRequest();

    //    operation.completed += _ =>
    //    {
    //        Debug.Log(operation.isDone);
    //        Debug.Log(operation.webRequest.downloadHandler.text);
    //        Debug.Log(operation.webRequest.isHttpError);
    //        Debug.Log(operation.webRequest.isNetworkError);
    //        var response = request.GetRequestHeader("application/json");
    //        Debug.Log(response);
    //    };
    //}

    void Start()
    {
        var data = new Data();
        StartCoroutine(HttpPost(data));
        //StartCoroutine(HttpConnect());
    }
    IEnumerator HttpConnect()
    {
        string url = "http://127.0.0.1:8000/post";
        //Unity2018~
        UnityWebRequest uwr = UnityWebRequest.Get(url);
        yield return uwr.SendWebRequest();
        if (uwr.isHttpError || uwr.isNetworkError)
        {
            Debug.Log(uwr.error);
        }
        else
        {
            Debug.Log(uwr.downloadHandler.text);
        }
    }
    IEnumerator HttpPost(Data data)
    {
        var url = "http://localhost:8000/buy_space?user_name=sample_user&room_name=sample_room";
        //var data = new Data();
        var json = JsonUtility.ToJson(data);
        var postData = Encoding.UTF8.GetBytes(json);

        var request = new UnityWebRequest(url, UnityWebRequest.kHttpVerbPOST)
        {
            uploadHandler = new UploadHandlerRaw(postData),
            downloadHandler = new DownloadHandlerBuffer()
        };

        request.SetRequestHeader("Content-Type", "application/json");

        var operation = request.SendWebRequest();

        operation.completed += _ =>
        {
            Debug.Log(operation.isDone);
            Debug.Log(operation.webRequest.downloadHandler.text);
            Debug.Log(operation.webRequest.isHttpError);
            Debug.Log(operation.webRequest.isNetworkError);
            var response = request.GetRequestHeader("application/json");
            Debug.Log(response);
            request.Dispose();
        };
        yield return operation;
    }

    void Update()
    {
        if (Input.GetKeyUp("s"))
        {
            var data = new Data();
            data.space_id = 1;
            StartCoroutine(HttpPost(data));
        }
        if (Input.GetKeyUp("a"))
        {
            var data = new Data();
            data.space_id = 2;
            StartCoroutine(HttpPost(data));
        }

        //var url = "https://httpbin.org/post";
        //var request = new UnityWebRequest(url, UnityWebRequest.kHttpVerbGET)
        //{
        //    downloadHandler = new DownloadHandlerBuffer()
        //};
        //var operation = request.SendWebRequest();
        //operation.completed += _ =>
        //{
        //    Debug.Log(operation.webRequest.downloadHandler.text);
        //};
    }
}

//public class HttpController : MonoBehaviour
//{

//    void Start()
//    {
//        StartCoroutine(HttpConnect());
//    }
//    IEnumerator HttpConnect()
//    {
//        string url = "https://httpbin.org/get";
//        //Unity2018~
//        UnityWebRequest uwr = UnityWebRequest.Get(url);
//        yield return uwr.SendWebRequest();
//        if (uwr.isHttpError || uwr.isNetworkError)
//        {
//            Debug.Log(uwr.error);
//        }
//        else
//        {
//            Debug.Log(uwr.downloadHandler.text);
//        }
//    }
//}