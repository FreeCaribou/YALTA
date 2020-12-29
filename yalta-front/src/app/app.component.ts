import { Component } from '@angular/core';

import { Platform, ToastController } from '@ionic/angular';
import { SplashScreen } from '@ionic-native/splash-screen/ngx';
import { StatusBar } from '@ionic-native/status-bar/ngx';
import { LanguageCommunicationService } from './shared/services/communication/language.communication.service';
import { LoaderCommunicationService } from './shared/services/communication/loader.communication.service';
import { ErrorCommunicationService } from './shared/services/communication/error.communication.service';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss']
})
export class AppComponent {
  constructor(
    public platform: Platform,
    public splashScreen: SplashScreen,
    public statusBar: StatusBar,
    public languageCommunication: LanguageCommunicationService,
    public loaderCommunication: LoaderCommunicationService,
    public toastController: ToastController,
    public errorCommunication: ErrorCommunicationService
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

    this.errorCommunication.errorOccurs.subscribe(data => {
      console.error('error occurs', data);
      this.presentToast(this.errorCommunication.buildErrorMessage(data));
    });
  }

  async presentToast(message) {
    const toast = await this.toastController.create({
      message: message,
      color: 'danger',
      buttons: [
        {
          role: 'Cancel',
          icon: 'close',
        }
      ]
    });
    toast.present();
  }
}
