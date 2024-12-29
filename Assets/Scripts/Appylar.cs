using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AppylarSdkWrapper;
using TMPro;

public class AppylarSample: MonoBehaviour, AppylarInitializationListener, AppylarInterstitialListener, AppylarBannerListener {

  public TextMeshProUGUI textMeshProUGUI;
 
  // Start is called before the first frame update
  void Start() {
    if (textMeshProUGUI == null){
      textMeshProUGUI = GameObject.Find("status_text").GetComponent<TextMeshProUGUI>();
      textMeshProUGUI.text = "Initializing the SDK, please wait...";
    }
    Initialize();
  }

  public void Initialize() {
    Appylar.Initialize(
      "<YOUR_ANDROID_APP_KEY>", new AdType[] {
        AdType.INTERSTITIAL, AdType.BANNER
      }, true, this
    );
  }

  public void Interstitial() {
    Appylar.ShowInterstitial(" ", this);
  }

  public void ShowBanner() {
    Appylar.ShowBanner(BannerPosition.BOTTOM, " ", this);
  }

  public void HideBanner() {
    Appylar.HideBanner();
  }

  #region Interface Implementations
  public void onNoBanner() {
    print("onNoBanner");
    textMeshProUGUI.text = "No more banners in the buffer,\nplease retry again after a minute.";
  }

  public void onBannerShown(int height) {
    print("onBannerShown " + height);
    textMeshProUGUI.text = "";
  }

  public void onInitialized() {
    print("onInitialized");
    textMeshProUGUI.text = "The SDK is initialized.";
  }

  public void onError(string message) {
    print($"onError : {message}");
    textMeshProUGUI.text = $"Error : {message}";
  }

  public void onNoInterstitial() {
    print("onNoInterstitial ");
    textMeshProUGUI.text = "No more interstitials in the buffer,\nplease retry again after a minute.";
  }

  public void onInterstitialShown() {
    print("onInterstitialShown");
    textMeshProUGUI.text = "";
  }

  public void onInterstitialClosed() {
    print("onInterstitialClosed ");
    textMeshProUGUI.text = "";
  }
  #endregion

}