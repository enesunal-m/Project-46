using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LanguageManager
{
    public static Root getCardDatabaseWithLanguage()
    {
        string languageExtension = "";
        switch (GameManager.Instance.gameLanguage)
        {
            case Language.tr:
                languageExtension = "tr";
                break;
            case Language.en:
                languageExtension = "en";
                break;
            default:
                languageExtension = "en";
                break;
        }
        string cardDtabaseUrl = String.Format(Constants.URLConstants.cardDatabaseJsonBaseUrl, languageExtension);

        return JsonController.getJsonWithPath(cardDtabaseUrl);
    }
}
// JsonController.getJsonWithPath(@"/Assets/Database/CardDatabase.json")
