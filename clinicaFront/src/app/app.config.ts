import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import {provideHttpClient, withInterceptors, withFetch} from '@angular/common/http';
import { authInterceptor} from './interceptors/auth.interceptors';


export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
   provideHttpClient(withInterceptors([authInterceptor]))
  ]
};
