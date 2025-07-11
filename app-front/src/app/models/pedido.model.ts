export interface ActoClinico {
  tipo: string;
  subSistema: string;
  profissional?: string;
}

export interface PedidoDeMarcacao {
  numeroUtente: string;
  fotografia: File | null;
  nomeCompleto: string;
  dataNascimento: string;
  genero: string;
  telemovel: string;
  email: string;
  morada: string;
  actosClinicos: ActoClinico[];
  intervaloDatas: string;
  horario: string;
  observacoes: string;
}
