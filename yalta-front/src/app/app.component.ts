import { Component } from '@angular/core';

import { Platform } from '@ionic/angular';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';
import { LanguageCommunicationService } from './shared/services/communication/language.communication.service';
import { LoaderCommunicationService } from './shared/services/communication/loader.communication.service';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss']
})
export class AppComponent {
  constructor(
    private platform: Platform,
    private splashScreen: SplashScreen,
    private statusBar: StatusBar,
    private languageCommunication: LanguageCommunicationService,
    private loaderCommunication: LoaderCommunicationService
  ) {
    this.initializeApp();
  }

  initializeApp() {
    console.log('the user platform', this.platform.platforms());
    this.languageCommunication.init();
    this.platform.ready().then(() => {
      this.statusBar.styleDefault();
      this.splashScreen.hide();
    });
  }
}
