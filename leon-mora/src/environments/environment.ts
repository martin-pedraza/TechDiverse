// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  fcmUrl: 'https://fcm.googleapis.com/fcm/send',
  fcmServerKey:
    //eslint-disable-next-line max-len
    'AAAAX2qTm58:APA91bGa14cPo94__GaK_buPH5pm2bbFOlFS3al2BGIeDYtuqCMLICBiPlAE88QzpVLGEpEg5C0O3iq01eIe4Cczr_LGuDwHNBaMdglOG_pePg332DjdPatbGjohY2Mc9AJ5vcvgkkhh',
  firebaseConfig: {
    apiKey: "AIzaSyD1f4fnJLPycnH4EhxNAXoZoKurNJdH8ho",
    authDomain: "leonmora2023pps.firebaseapp.com",
    projectId: "leonmora2023pps",
    storageBucket: "leonmora2023pps.appspot.com",
    messagingSenderId: "409809951647",
    appId: "1:409809951647:web:8d37a4ae56a680bf5d7baa"
  },
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
