import { CapacitorConfig } from '@capacitor/cli';

const config: CapacitorConfig = {
  appId: 'com.leonMora',
  appName: 'LeonMora-2023',
  webDir: 'www',
  server: {
    androidScheme: 'https'
  },
  plugins: {
    SplashScreen: {
      launchAutoHide: false,
      launchFadeOutDuration: 0,
      androidSplashResourceName: "splash",
      iosSpinnerStyle: "small",
      splashFullScreen: true,
    },
    "Camera": {
      "cameraUsageDescription": "This app needs access to your camera to take photos."
    },
    PushNotifications: {
      presentationOptions: ["badge", "sound", "alert"]
    }
  }
};

export default config;
