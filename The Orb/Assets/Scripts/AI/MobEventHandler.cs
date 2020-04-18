using System;
using UnityEngine;

public delegate void MobEventHandler(object sender, MobEventArgs e);

public class MobEventArgs : EventArgs
{
    public Vector3 Position { get; }

    public MobEventArgs(Vector3 position)
    {
        Position = position;
    }
}
