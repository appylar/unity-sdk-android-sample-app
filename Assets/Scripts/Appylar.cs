using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AppylarSdkWrapper;
using TMPro;

public class AppylarSample: MonoBehaviour, AppylarInitializationListener, AppylarInterstitialListener, AppylarBannerListener {

  public TextMeshProUGUI textMeshProUGUI;

  // Start is called before the first frame update
  void Start() {
    Initialize();
    textMeshProUGUI.text = "GABOR";
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
  }

  public void onBannerShown(int height) {
    print("onBannerShown " + height);
  }

  public void onInitialized() {
    print("onInitialized");
  }

  public void onError(string message) {
    print($"onError : {message}");
  }

  public void onNoInterstitial() {
    print("onNoInterstitial ");
  }

  public void onInterstitialShown() {
    print("onInterstitialShown");
  }

  public void onInterstitialClosed() {
    print("onInterstitialClosed ");
  }
  #endregion

}