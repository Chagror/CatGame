using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

public class GoogleSheetClient : MonoBehaviour
{
    #region Singleton
    public static GoogleSheetClient instance;
    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }
    #endregion

    [SerializeField] private string[] _scope = { SheetsService.Scope.Spreadsheets };
    [SerializeField] private string _credentialsPath = "GoogleSheet/Credentials/";
    [SerializeField] private string _credentialFile = "credentials.json";
    [SerializeField] private string _spreadSheetID = "1BYD4K95s4kIk_Dpzh56huXUC5o2ssNObrsuMScnkWjc";
    [SerializeField] private string _playerRange = "Players!A1";
    private SheetsService _service;
    public bool connected;

    [ContextMenu("Connect")]
    public async void Connect() 
    {
        await ConnectAsync();
    }
    [ContextMenu("TestRead")]
    public async void CellDataTest() 
        {
         await getCellData(_spreadSheetID, "Settings!A1");
        }
    [ContextMenu("TestWrite")]
    public async void CellDataWriteTest()
    {
        List<object> testList = new List<object>();
        testList.Add("Bob");
        testList.Add("Pierre");
        await WriteCollumnrList(_spreadSheetID, _playerRange, testList );
    }
    public async Task ConnectAsync()
    {
        string credentialDirectory = Path.Combine(Application.dataPath, _credentialsPath);
        string credentialPath = Path.Combine(credentialDirectory, _credentialFile);

        if (!Directory.Exists(credentialDirectory))
        {
            Directory.CreateDirectory(credentialDirectory);
        }
        UserCredential userCredential;
        GoogleClientSecrets secrets;
        Debug.Log($"token saved {credentialPath}");
        Debug.Log("get credential in local");
        using (FileStream stream = new FileStream(credentialPath, FileMode.Open, FileAccess.Read))
        {
            secrets = await GoogleClientSecrets.FromStreamAsync(stream);
        }

        string tokenLocation = Path.Combine(Application.persistentDataPath, _credentialsPath);
        Debug.Log("connecting");
        userCredential = await GoogleWebAuthorizationBroker.AuthorizeAsync(secrets.Secrets, _scope, "user", 
            CancellationToken.None, new FileDataStore(tokenLocation, true));
        Debug.Log($"token saved {tokenLocation}");
        _service = new SheetsService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = userCredential
        }); ;
        connected = true;
    }
    public async Task<string?> getCellData(string spreadSheetId, string range)
    {
        if (!connected)
        {
            await ConnectAsync();
        }
        var request = _service.Spreadsheets.Values.Get(spreadSheetId, range);
        
        ValueRange rep = await request.ExecuteAsync();

        IList<IList<object>> values = rep.Values;
        if (values != null && values.Count > 0 && values[0].Count > 0) 
        {
            Debug.Log(values[0][0].ToString());
            return values[0][0].ToString();
        }
        Debug.Log("no data read");
        return null;

    }
    public async Task WriteCollumnrList(string spreadSheetId, string range ,List<object> data) 
    {
        if (!connected)
        {
           await ConnectAsync();
        }
        ValueRange valueRange = new ValueRange();
        IList<IList<object>> values = new List<IList<object>> { new List<object>() };
        values[0] = data;
        valueRange.Values = values;

        var valueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;

        var request = _service.Spreadsheets.Values.Update(valueRange, spreadSheetId, range);
        request.ValueInputOption = valueInputOption;
        UpdateValuesResponse rep = await request.ExecuteAsync();
        return;
    }

    public async void WritePlayers() 
    {
        List<object> playerNames = PlayerManager.instance.GetPlayerName();
        for(int i = playerNames.Count; i < 48; i++)  //48 is the number of player max no time for a better way of cleaning players from previous game
        {                                            // when they were less player in the next one
            playerNames.Add("");
        }
       await WriteCollumnrList(_spreadSheetID, _playerRange, playerNames);
    }
    public async void ReadTimers(Game gameData) 
    {
        string timeJoin = await getCellData(_spreadSheetID, "Settings!B1");
        string timerToPlay = await getCellData(_spreadSheetID, "Settings!B2");
        if (timeJoin is null || timerToPlay is null)
            return;
        gameData.timerToJoin =int.Parse(await getCellData(_spreadSheetID, "Settings!B1"));
        gameData.timerForInputs = int.Parse(await getCellData(_spreadSheetID, "Settings!B2"));
    }
}
