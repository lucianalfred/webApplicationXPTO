export interface SessionData {
  token:   string;
  expires: number;        
  user: {
    id:    number;
    email: string;
    nome:  string;
    roles: string[];
  };
}

const KEY = 'xpto-session';

export function saveSession(data: SessionData) {
  localStorage.setItem(KEY, JSON.stringify(data));
}

export function getSession(): SessionData | null {
  const raw = localStorage.getItem(KEY);
  return raw ? JSON.parse(raw) : null;
}

export function clearSession() {
  localStorage.removeItem(KEY);
}
