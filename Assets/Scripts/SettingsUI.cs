using UnityEngine ;
using UnityEngine.UI ;

public class SettingsUI : MonoBehaviour {
   [Header ("UI References :")]
   [SerializeField] private GameObject uiCanvas ;
   [SerializeField] private Button uiCloseButton ;
   [Space]
   [SerializeField] private Toggle uiVibrationToggle ;
   [SerializeField] private Slider uiMusicSlider ;
   [SerializeField] private Slider uiSoundsSlider ;
   [SerializeField] private Dropdown uiLanguagesDropDown ;
   [SerializeField] private InputField uiPlayerNameInputField ;


   private void Awake () {
      //Add Listeners:
      uiCloseButton.onClick.AddListener (Close) ;

      //Settings closed by default:
      Close () ;

      //Update UI with saved values in player prefs:--------------------------------------
      uiVibrationToggle.isOn = Settings.VibrationEnabled ;
      uiMusicSlider.value = Settings.MusicVolume ;
      uiSoundsSlider.value = Settings.SoundsVolume ;
      uiLanguagesDropDown.value = Settings.SelectedLanguage ;
      uiPlayerNameInputField.text = Settings.PlayerName ;

      // Add UI elements listeners :------------------------------------------------------
      uiVibrationToggle.onValueChanged.AddListener (OnVibrationToggleChange) ;
      uiMusicSlider.onValueChanged.AddListener (OnMusicSliderChange) ;
      uiSoundsSlider.onValueChanged.AddListener (OnSoundsSliderChange) ;
      uiLanguagesDropDown.onValueChanged.AddListener (OnLanguagesDropDownChange) ;
      uiPlayerNameInputField.onValueChanged.AddListener (OnPlayerNameInputFieldChange) ;
   }


   // UI Events: -------------------------------------------------------------------------
   private void OnVibrationToggleChange (bool value) {
      Settings.VibrationEnabled = value ;
   }

   private void OnMusicSliderChange (float value) {
      Settings.MusicVolume = value ;
   }

   private void OnSoundsSliderChange (float value) {
      Settings.SoundsVolume = value ;
   }

   private void OnLanguagesDropDownChange (int value) {
      Settings.SelectedLanguage = value ;
   }

   private void OnPlayerNameInputFieldChange (string value) {
      Settings.PlayerName = value ;
   }


   // -------------------------------------------------------------------------------------
   public void Open () {
      uiCanvas.SetActive (true) ;
   }

   public void Close () {
      uiCanvas.SetActive (false) ;
   }




   // -------------------------------------------------------------------------------------
   private void OnDestroy () {
      //Remove Listeners:
      uiCloseButton.onClick.RemoveListener (Close) ;

      // Remove UI elements listeners :
      uiVibrationToggle.onValueChanged.RemoveListener (OnVibrationToggleChange) ;
      uiMusicSlider.onValueChanged.RemoveListener (OnMusicSliderChange) ;
      uiSoundsSlider.onValueChanged.RemoveListener (OnSoundsSliderChange) ;
      uiLanguagesDropDown.onValueChanged.RemoveListener (OnLanguagesDropDownChange) ;
      uiPlayerNameInputField.onValueChanged.RemoveListener (OnPlayerNameInputFieldChange) ;
   }
}
