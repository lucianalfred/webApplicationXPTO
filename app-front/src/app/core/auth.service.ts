// src/app/core/auth.service.ts
import { Injectable, inject, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { RegisterDTO } from './models/register-dto.model';

type JwtPayload = {
  unique_name: string;
  nameid: string;
  role:  string;
  exp:   number;
};
@Injectable({ providedIn: 'root' })

export class AuthService {
  private http = inject(HttpClient);
  private api  = 'http://localhost:5026/api/auth';


  tokenSig = signal<string | null>(localStorage.getItem('token'));


  payload = signal<JwtPayload | null>(this.decode());

 
  userName = signal<string | null>(this.payload()?.unique_name ?? null);
  userId   = signal<number | null>(Number(this.payload()?.nameid ?? null));

  

  register(dto: RegisterDTO) {
    return this.http
      .post<{ token: string; user: any }>(`${this.api}/register`, dto)
      .pipe(tap(res => this.persistAuth(res)));
  }

  login(email: string, password: string) {
    return this.http
      .post<{ token: string; user: any }>(`${this.api}/login`, { email, password })
      .pipe(tap(res => this.persistAuth(res)));
  }

  returnUserId(): number {
    const token = this.token; 
    if (!token) return 0;

    const payload = JSON.parse(atob(token.split('.')[1]));
    console.log(payload);
    return +payload.id; 
  }


  private persistAuth(res: { token: string; user: any }) {
    this.saveToken(res.token);
    localStorage.setItem('user', JSON.stringify(res.user));
  }

 
  get token(): string | null {
    return this.tokenSig();
  }

  
  get user(): any | null {
    const raw = localStorage.getItem('user');
    return raw ? JSON.parse(raw) : null;
  }

  
  
  saveToken(t: string) {
    localStorage.setItem('token', t);
    this.tokenSig.set(t);
    this.payload.set(this.decode());
    this.userName.set(this.payload()?.unique_name ?? null);
    this.userId.set(Number(this.payload()?.nameid ?? null));
  }

  logout() {
    localStorage.clear();
    this.tokenSig.set(null);
    this.payload.set(null);
    this.userName.set(null);
    this.userId.set(null);
  }

  

  private decode() {
    const t = this.tokenSig();
    if (!t) return null;
    try { return JSON.parse(atob(t.split('.')[1])); }
    catch { return null; }
  }
}
