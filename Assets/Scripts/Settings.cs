using UnityEngine ;
using UnityEngine.Events ;


public static class Settings {
   //Settings Events:
   public static UnityAction<bool> OnVibrationChanged ;
   public static UnityAction<float> OnMusicVolumeChanged ;
   public static UnityAction<float> OnSoundsVolumeChanged ;
   public static UnityAction<int> OnLanguageChanged ;
   public static UnityAction<string> OnPlayerNameChanged ;


   // private fields to hold data :
   private static bool _vibrationEnabled ;
   private static float _musicVolume ;
   private static float _soundsVolume ;
   private static int _selectedLang ;
   private static string _playerName ;


   // public properties :
   public static bool VibrationEnabled {
      get{ return _vibrationEnabled ; }
      set {
         _vibrationEnabled = value ;
         PlayerPrefs.SetInt ("VibrationEnabled", (value ? 1 : 0)) ;
         FireEvent (OnVibrationChanged, value) ;
      }
   }

   public static float MusicVolume {
      get{ return _musicVolume ; }
      set {
         _musicVolume = value ;
         PlayerPrefs.SetFloat ("MusicVolume", value) ;
         FireEvent (OnMusicVolumeChanged, value) ;
      }
   }

   public static float SoundsVolume {
      get{ return _soundsVolume ; }
      set {
         _soundsVolume = value ;
         PlayerPrefs.SetFloat ("SoundsVolume", value) ;
         FireEvent (OnSoundsVolumeChanged, value) ;
      }
   }


   public static int SelectedLanguage {
      get{ return _selectedLang ; }
      set {
         _selectedLang = value ;
         PlayerPrefs.SetInt ("SelectedLanguage", value) ;
         FireEvent (OnLanguageChanged, value) ;
      }
   }

   public static string PlayerName {
      get{ return _playerName ; }
      set {
         _playerName = value ;
         PlayerPrefs.SetString ("PlayerName", value) ;
         FireEvent (OnPlayerNameChanged, value) ;
      }
   }

   private static void FireEvent<T> (UnityAction<T> action, T value) {
      if (action != null)
         action.Invoke (value) ;
   }

   // Get saved data when the game runs for the first time
   //this static constructor will execute only once at the very beginning
   static Settings () {
      _vibrationEnabled = (PlayerPrefs.GetInt ("VibrationEnabled", 0) == 0 ? false : true) ;
      _musicVolume = PlayerPrefs.GetFloat ("MusicVolume", 1) ;
      _soundsVolume = PlayerPrefs.GetFloat ("SoundsVolume", 1) ;
      _selectedLang = PlayerPrefs.GetInt ("SelectedLanguage", 0) ;
      _playerName = PlayerPrefs.GetString ("PlayerName", "") ;
   }
}