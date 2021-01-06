using UnityEngine ;
using UnityEngine.UI ;

public class MainMenuUI : MonoBehaviour {
   [Header ("UI References :")]
   [SerializeField] private Button uiSettingsButton ;

   [Header ("Settings UI")]
   [SerializeField] private SettingsUI settingsUI ;


   private void Start () {
      //Add listener
      uiSettingsButton.onClick.AddListener (() => settingsUI.Open ()) ;

      // Test Settings Events:
      Settings.OnVibrationChanged += OnVibChange ;
      Settings.OnLanguageChanged += OnLangChange ;
   }


   private void OnVibChange (bool value) {
      Debug.Log ("Vibration changed: " + value) ;
   }

   private void OnLangChange (int index) {
      Debug.Log ("Language changed: " + index) ;
   }


   private void OnDestroy () {
      //Remove listener
      uiSettingsButton.onClick.RemoveAllListeners () ;

      Settings.OnVibrationChanged -= OnVibChange ;
      Settings.OnLanguageChanged -= OnLangChange ;
   }
}
