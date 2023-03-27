using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using UnityEngine;

public class ArduinoBasic : MonoBehaviour
{
    private SerialPort arduinoStream; // 宣告SerialPort變數
    public string port; // 儲存要連接的COM Port
    private Thread readThread; // 宣告Thread變數
    static public string readMessage; // 儲存接收到的訊息
    bool isNewMessage; // 判斷是否有新的訊息

    void Start()
    {
        if (port != "") // 如果指定了COM Port
        {
            arduinoStream = new SerialPort(port, 9600); // 建立SerialPort
            arduinoStream.ReadTimeout = 10; // 設定讀取超時時間
            try
            {
                arduinoStream.Open(); // 開啟SerialPort
                readThread = new Thread(new ThreadStart(ArduinoRead)); // 建立新的Thread
                readThread.Start(); // 啟動Thread
                Debug.Log("SerialPort連接成功"); // 顯示訊息
            }
            catch
            {
                Debug.Log("SerialPort連接失敗"); // 顯示錯誤訊息
            }
        }
    }

    void Update()
    {
        if (isNewMessage) // 如果有新的訊息
        {
            Debug.Log(readMessage); // 顯示訊息
        }
    }

    private void ArduinoRead()
    {
        while (arduinoStream.IsOpen) // 當SerialPort仍然開啟
        {
            try
            {
                readMessage = arduinoStream.ReadLine(); // 讀取SerialPort的資料
                isNewMessage = true; // 設定為有新的訊息
            }
            catch (System.Exception e)
            {
                Debug.LogWarning(e.Message); // 顯示錯誤訊息
            }
        }
    }

    public void ArduinoWrite(string message) // 寫入SerialPort的資料
    {
        Debug.Log(message); // 顯示要寫入的資料
        try
        {
            arduinoStream.Write(message); // 寫入SerialPort
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message); // 顯示錯誤訊息
        }
    }

    void OnApplicationQuit() // 當應用程式關閉時
    {
        if (arduinoStream != null) // 如果SerialPort存在
        {
            if (arduinoStream.IsOpen) // 如果SerialPort開啟
            {
                arduinoStream.Close(); // 關閉SerialPort
            }
        }
    }
}
