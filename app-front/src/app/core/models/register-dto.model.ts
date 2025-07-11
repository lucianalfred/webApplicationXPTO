export interface RegisterDTO {
  nome: string;
  email: string;
  password: string;
  dataNascimento: string;          
  morada?: string;
  genero?: string;
  urlDaFotografia?: string | null;
  estadoDoUtilizador?: boolean | null;
  papel: 'Utente' | 'Administrativo' | 'Administrador';
}

