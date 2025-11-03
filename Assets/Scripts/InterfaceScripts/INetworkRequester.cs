using System;
using System.Collections.Generic;
using UnityEngine;

public interface INetworkRequester
{
    public Dictionary<int, Action> requests { get; set; }

    public void UpLoadCode();

    public void AddAction(int code);
    
    public void RemoveCode(int code);
}