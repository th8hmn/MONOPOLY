using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;

public static class JsonLoad
{

    public static string GetJsonData(string jsonText)
    {
        string jsonData;
        JsonNode json = JsonNode.Parse(jsonText);

        Debug.Log(json["info"].Get<string>());

        JsonNode detail = json["detail"];

        string user_name = detail["user_name"].Get<string>();
        int space_id = (int)detail["space_id"].Get<long>();

        Debug.Log("user_name: " + user_name + "space_id :" + space_id);

        jsonData = "user_name: " + user_name + ", space_id :" + space_id;

        return jsonData;
        //Debug.Log(detail["user_name"].Get<string>());
        //Debug.Log(detail["space_id"].Get<long>());
    }
}
