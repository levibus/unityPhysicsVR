using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

/*
* Author: Ivan Cheah
* Description: Causes the arduino to be triggered when a button in the UI is pushed.
*/

public class ArduinoCommunication : MonoBehaviour
{
    private const string ipAddress = "10.65.182.71"; //Arduino IP address, (changes daily)
    private const int port = 1234;                      // run ipaddress sketch and update

    private TcpClient client;
    private StreamWriter writer;
    private bool isConnected = false;
    // private UserAlert alertScript;
    // [SerializeField] private GameObject alertObject;

    private void Start()
    {
        // alertScript = alertObject.GetComponent<UserAlert>();
    }

    public async void SendSignal()
    {
        if (!isConnected)
        {
            await ConnectToArduino();
        }

        if (isConnected)
        {
            try
            {
                writer.WriteLine("activate");
                writer.Flush();
            }
            catch (Exception e)
            {
                Debug.LogError("Error sending signal: " + e.Message);
                // alertScript.displayMessage("Error sending signal: " + e.Message);
            }
        }
    }

    private async Task ConnectToArduino()
    {
        try
        {
            client = new TcpClient();
            //Connect to Arduino
            await client.ConnectAsync(ipAddress, port);
            NetworkStream stream = client.GetStream();
            writer = new StreamWriter(stream, Encoding.ASCII);
            isConnected = true;
            Debug.Log("Connected to Arduino");
            // alertScript.displayMessage("Connected to Arduino");
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to connect to Arduino: " + e.Message);
            // alertScript.displayMessage("Failed to connect to Arduino: " + e.Message);
        }
    }

    private void OnDestroy()
    {
        if (isConnected)
        {
            //Close writer and client connection
            writer.Close();
            client.Close();
        }
    }
}